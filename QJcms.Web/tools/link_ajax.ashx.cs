using System;
using System.Collections.Generic;
using System.Web;
using QJcms.Common;
using System.Text;

namespace QJcms.Web.tools
{
    /// <summary>
    /// link_ajax 的摘要说明
    /// </summary>
    public class link_ajax : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //取得处事类型
            string action = context.Request.Params["action"];

            switch (action)
            {
                case "add": //添加链接
                    link_add(context);
                    break;
            }

        }

        #region 添加友情链接================================
        private void link_add(HttpContext context)
        {
            StringBuilder strTxt = new StringBuilder();
            BLL.link bll = new BLL.link();
            Model.link model = new Model.link();

            string _code = QJRequest.GetFormString("txtCode");
            string _title = QJRequest.GetFormString("txtTitle");
            string _user_name = QJRequest.GetFormString("txtUserName");
            string _user_tel = QJRequest.GetFormString("txtUserTel");
            string _email = QJRequest.GetFormString("txtEmail");
            string _site_url = QJRequest.GetFormString("txtSiteUrl");
            string _img_url = QJRequest.GetFormString("txtImgUrl");

            //校检验证码
            if (string.IsNullOrEmpty(_code))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请输入验证码！\"}");
                return;
            }
            if (context.Session[QJConst.SESSION_CODE] == null)
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，系验证码已过期！\"}");
                return;
            }
            if (_code.ToLower() != (context.Session[QJConst.SESSION_CODE].ToString()).ToLower())
            {
                context.Response.Write("{\"status\":0, \"msg\":\"验证码与系统的不一致！\"}");
                return;
            }
            if (string.IsNullOrEmpty(_title))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"对不起，请输入网站标题！\"}");
                return;
            }
            if (string.IsNullOrEmpty(_site_url))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"对不起，请输入网站网址！\"}");
                return;
            }

            model.title = Utils.DropHTML(_title);
            model.is_lock = 1;
            model.is_red = 0;
            model.user_name = Utils.DropHTML(_user_name);
            model.user_tel = Utils.DropHTML(_user_tel);
            model.email = Utils.DropHTML(_email);
            model.site_url = Utils.DropHTML(_site_url);
            model.img_url = Utils.DropHTML(_img_url);
            model.is_image = 1;
            if (string.IsNullOrEmpty(model.img_url))
            {
                model.is_image = 0;
            }
            if (bll.Add(model) > 0)
            {
                context.Response.Write("{\"status\": 1, \"msg\": \"恭喜您，提交成功！\"}");
                return;
            }
            context.Response.Write("{\"status\": 0, \"msg\": \"对不起，保存过程中发生错误！\"}");
            return;
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}