using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QJcms.Common;
using System.Security.Cryptography;
using System.Text;

namespace QJcms.Web.admin
{
    public partial class qijudl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtUserName.Text = Utils.GetCookie("QJRememberName");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string userPwd = txtPassword.Text.Trim();
            string code = txtCode.Text.Trim();

            if (userName.Equals("") || userPwd.Equals(""))
            {
                msgtip.InnerHtml = "请输入用户名或密码";
                msgtip.Attributes.Add("class", "error");
                return;
            }
            if (code.Equals(""))
            {
                msgtip.InnerHtml = "请输入验证码";
                msgtip.Attributes.Add("class", "error");
                return;
            }
            if (Session[QJConst.SESSION_CODE] == null)
            {
                msgtip.InnerHtml = "验证码已失效";
                msgtip.Attributes.Add("class", "error");
                return;
            }
            if (code.ToLower() != Session[QJConst.SESSION_CODE].ToString().ToLower())
            {
                msgtip.InnerHtml = "验证码输入不正确";
                msgtip.Attributes.Add("class", "error");
                return;
            }
            if (Session["AdminLoginSun"] == null)
            {
                Session["AdminLoginSun"] = 1;
            }
            else
            {
                Session["AdminLoginSun"] = Convert.ToInt32(Session["AdminLoginSun"]) + 1;
            }
            //判断登录错误次数
            if (Session["AdminLoginSun"] != null && Convert.ToInt32(Session["AdminLoginSun"]) > 5)
            {
                msgtip.InnerHtml = "错误超过5次，关闭浏览器重新登录！";
                msgtip.Attributes.Add("class", "error");
                return;
            }
            BLL.manager bll = new BLL.manager();
            Model.manager model = bll.GetModel(userName, userPwd, true);
            if (model == null)
            {
                msgtip.InnerHtml = "用户名或密码有误，请重试！";
                msgtip.Attributes.Add("class", "error");
                return;
            }
            Session[QJConst.SESSION_ADMIN_INFO] = model;
            Session.Timeout = 45;
            //写入登录日志
            Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
            if (siteConfig.logstatus > 0)
            {
                new BLL.manager_log().Add(model.role_type, model.id, model.user_name, QJEnums.ActionEnum.Login.ToString(), "用户登录");
            }
            //写入Cookies
            Utils.WriteCookie("QJRememberName", model.user_name, 14400);
            Utils.WriteCookie("AdminName", "QJcms", model.user_name);
            Utils.WriteCookie("AdminPwd", "QJcms", model.password);
            Response.Redirect("index.aspx");
            return;
        }

    }
}