using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;
using System.Text;
using QJcms.Web.UI;
using QJcms.Common;

namespace QJcms.Web.tools
{
    /// <summary>
    /// feedback_ajax 的摘要说明
    /// </summary>
    public class feedback_ajax : IHttpHandler, IRequiresSessionState
    {
        Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
        public void ProcessRequest(HttpContext context)
        {
            //取得处事类型
            string action = QJRequest.GetQueryString("action");

            switch (action)
            {
                case "add": //发布留言
                    feedback_add(context);
                    break;
            }

        }

        #region 发布留言================================
        private void feedback_add(HttpContext context)
        {
            //检查是否过快
            string cookie = Utils.GetCookie("user_feed_back_email");
            if (cookie == "send_feed_back")
            {
                context.Response.Write("{\"status\":0, \"msg\":\"您的申请我们已收到，请耐心等候我们与您联系！<br>如需重新申请，请与20分钟之后提交。}");
                return;
            }

            StringBuilder strTxt = new StringBuilder();

            string _name = QJRequest.GetFormString("name");
            string _tel = QJRequest.GetFormString("tel");
            string _mail = QJRequest.GetFormString("mail");
            string _msg = QJRequest.GetFormString("msg");

            #region 校检数据

            if (string.IsNullOrEmpty(_name))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请填写姓名！\"}");
                return;
            }
            if (string.IsNullOrEmpty(_tel))
            {
                context.Response.Write("{\"status\":0, \"msg\":\"对不起，请填写手机号码！\"}");
                return;
            }
            if (string.IsNullOrEmpty(_msg))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"对不起，请填写留言内容！\"}");
                return;
            }
            #endregion

            #region 发送邮件
            if (siteConfig.feedbackmailstatus == 1)
            {
                //接收邮箱
                string mail_to = siteConfig.feedbackmailtxt == "" ? siteConfig.webmail : siteConfig.feedbackmailtxt;
                //替换模板内容
                string mail_title = siteConfig.feedbackmailtitle;
                string mail_body = siteConfig.feedbacktemplate;

                mail_body = mail_body.Replace("{name}", _name);
                mail_body = mail_body.Replace("{tel}", _tel);
                mail_body = mail_body.Replace("{mail}", _mail);
                mail_body = mail_body.Replace("{msg}", _msg);
                //发送邮件
                try
                {
                    QJMail.sendMail(siteConfig.emailsmtp, siteConfig.emailusername, DESEncrypt.Decrypt(siteConfig.emailpassword), siteConfig.emailnickname, siteConfig.emailfrom, mail_to, mail_title, mail_body.ToString());
                }
                catch
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"对不起，提交申请发生错误！\"}");
                    return;
                }
            }
            #endregion
            context.Response.Write("{\"status\": 1, \"msg\": \"恭喜您，申请提交成功！\"}");
            Utils.WriteCookie("user_feed_back_email", "send_feed_back", 20); //20分钟内无重复发送
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