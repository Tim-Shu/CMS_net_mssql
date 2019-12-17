using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QJcms.Common;

namespace QJcms.Web.admin.settings
{
    public partial class sys_config : Web.UI.ManagePage
    {
        string defaultpassword = "0|0|0|0"; //默认显示密码
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("sys_config", QJEnums.ActionEnum.View.ToString()); //检查权限
                ShowInfo();
            }
        }

        #region 赋值操作=================================
        private void ShowInfo()
        {
            BLL.siteconfig bll = new BLL.siteconfig();
            Model.siteconfig model = bll.loadConfig();

            webcopyright.Text = model.webcopyright;
            webpath.Text = model.webpath;
            webmanagepath.Text = model.webmanagepath;
            staticstatus.SelectedValue = model.staticstatus.ToString();
            staticextension.Text = model.staticextension;

            if (model.logstatus == 1) { logstatus.Checked = true; }
            else { logstatus.Checked = false; }
            if (model.webstatus == 1) { webstatus.Checked = true; }
            else { webstatus.Checked = false; }
            #region 会员功能
            if (model.memberstatus == 1) { memberstatus.Checked = true; }
            else { memberstatus.Checked = false; }
            if (model.membergroupstatus == 1) { membergroupstatus.Checked = true; }
            else { membergroupstatus.Checked = false; }
            if (model.memberpointstatus == 1) { memberpointstatus.Checked = true; }
            else { memberpointstatus.Checked = false; }
            if (model.commentstatus == 1) { commentstatus.Checked = true; }
            else { commentstatus.Checked = false; }
            if (model.memberlevelstatus == 1) { memberlevelstatus.Checked = true; }
            else { memberlevelstatus.Checked = false; }
            if (model.memberamountstatus == 1) { memberamountstatus.Checked = true; }
            else { memberamountstatus.Checked = false; }
            if (model.memberavatarstatus == 1) { memberavatarstatus.Checked = true; }
            else { memberavatarstatus.Checked = false; }
            if (model.memberoauthstatus == 1) { memberoauthstatus.Checked = true; }
            else { memberoauthstatus.Checked = false; }
            #endregion
            #region 高级功能权限
            //短信平台
            smsnavtxt.Text = model.smsnavtxt;
            if (model.smsstatus == 1) { smsstatus.Checked = true; }
            else { smsstatus.Checked = false; }
            //邮件服务
            mailnavtxt.Text = model.mailnavtxt;
            if (model.mailstatus == 1) { mailstatus.Checked = true; }
            else { mailstatus.Checked = false; }
            //订单
            ordernavtxt.Text = model.ordernavtxt;
            if (model.orderstatus == 1) { orderstatus.Checked = true; }
            else { orderstatus.Checked = false; }
            //在线支付
            paymentnavtxt.Text = model.paymentnavtxt;
            if (model.paymentstatus == 1) { paymentstatus.Checked = true; }
            //提交留言到邮箱
            feedbackmailtxt.Text = model.feedbackmailtxt;
            if (model.feedbackmailstatus == 1) { feedbackmailstatus.Checked = true; }
            feedbackmailtitle.Text = model.feedbackmailtitle;
            feedbacktemplate.Text = model.feedbacktemplate;
            //邀请码
            if (model.invitedstatus == 1) { invitedstatus.Checked = true; }
            else { invitedstatus.Checked = false; }
            //图片水印
            if (model.watermarkstatus == 1) { watermarkstatus.Checked = true; }
            else { watermarkstatus.Checked = false; }
            #endregion
            webclosereason.Text = model.webclosereason;
            filepath.Text = model.filepath;
            filesave.SelectedValue = model.filesave.ToString();
            fileextension.Text = model.fileextension;
            attachsize.Text = model.attachsize.ToString();
            imgsize.Text = model.imgsize.ToString();
            imgmaxheight.Text = model.imgmaxheight.ToString();
            imgmaxwidth.Text = model.imgmaxwidth.ToString();
            thumbnailheight.Text = model.thumbnailheight.ToString();
            thumbnailwidth.Text = model.thumbnailwidth.ToString();
        }
        #endregion

        /// <summary>
        /// 保存配置信息
        /// </summary>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("sys_config", QJEnums.ActionEnum.Edit.ToString()); //检查权限
            BLL.siteconfig bll = new BLL.siteconfig();
            Model.siteconfig model = bll.loadConfig();
            BLL.navigation navbll = new BLL.navigation();//导航菜单
            try
            {
                model.webcopyright = webcopyright.Text;

                model.webpath = webpath.Text;
                model.webmanagepath = webmanagepath.Text;
                model.staticstatus = Utils.StrToInt(staticstatus.SelectedValue, 0);
                model.staticextension = staticextension.Text;
                
                if (logstatus.Checked == true)
                {
                    model.logstatus = 1;
                    //显示后台导航菜单
                    navbll.UpdateField("manager_log", "is_lock=0");
                }
                else
                {
                    model.logstatus = 0;
                    //隐藏后台导航菜单
                    navbll.UpdateField("manager_log", "is_lock=1");
                }
                if (webstatus.Checked == true) { model.webstatus = 1; }
                else { model.webstatus = 0; }
                #region 会员功能配置
                if (memberstatus.Checked == true)
                {
                    model.memberstatus = 1;
                    //显示后台导航菜单
                    navbll.UpdateField("sys_users", "is_lock=0");
                }
                else
                {
                    model.memberstatus = 0;
                    //隐藏后台导航菜单
                    navbll.UpdateField("sys_users", "is_lock=1");
                }
                //会员组
                if (membergroupstatus.Checked == true)
                {
                    model.membergroupstatus = 1;
                    //显示后台导航菜单
                    navbll.UpdateField("user_group", "is_lock=0");
                }
                else
                {
                    model.membergroupstatus = 0;
                    //隐藏后台导航菜单
                    navbll.UpdateField("user_group", "is_lock=1");
                }
                //会员积分
                if (memberpointstatus.Checked == true)
                {
                    model.memberpointstatus = 1;
                    //显示后台导航菜单
                    navbll.UpdateField("user_point_log", "is_lock=0");
                }
                else
                {
                    model.memberpointstatus = 0;
                    //隐藏后台导航菜单
                    navbll.UpdateField("user_point_log", "is_lock=1");
                }
                //会员等级
                if (memberlevelstatus.Checked == true) { model.memberlevelstatus = 1; }
                else { model.memberlevelstatus = 0; }
                //账户余额
                if (memberamountstatus.Checked == true)
                {
                    model.memberamountstatus = 1;
                    //显示后台导航菜单
                    navbll.UpdateField("user_amount_log", "is_lock=0");
                }
                else
                {
                    model.memberamountstatus = 0;
                    //隐藏后台导航菜单
                    navbll.UpdateField("user_amount_log", "is_lock=1");
                }
                //会员头像
                if (memberavatarstatus.Checked == true) { model.memberavatarstatus = 1; }
                else { model.memberavatarstatus = 0; }
                //账户余额
                if (memberoauthstatus.Checked == true)
                {
                    model.memberoauthstatus = 1;
                    //显示后台导航菜单
                    navbll.UpdateField("user_oauth", "is_lock=0");
                }
                else
                {
                    model.memberoauthstatus = 0;
                    //隐藏后台导航菜单
                    navbll.UpdateField("user_oauth", "is_lock=1");
                }
                //评论审核
                if (commentstatus.Checked == true) { model.commentstatus = 1; }
                else { model.commentstatus = 0; }
                #endregion
                #region 高级功能权限
                //短信平台
                model.smsnavtxt = smsnavtxt.Text.Trim();
                if (smsstatus.Checked == true)
                {
                    model.smsstatus = 1;
                    //显示后台导航菜单
                    navbll.UpdateField("user_sms", "is_lock=0");
                    navbll.UpdateField(smsnavtxt.Text.Trim(), "is_lock=0");
                }
                else
                {
                    model.smsstatus = 0;
                    //隐藏后台导航菜单
                    navbll.UpdateField("user_sms", "is_lock=1");
                    navbll.UpdateField(smsnavtxt.Text.Trim(), "is_lock=1");
                }
                //邀请码
                if (invitedstatus.Checked == true) { model.invitedstatus = 1; }
                else { model.invitedstatus = 0; }
                //图片水印
                if (watermarkstatus.Checked == true) { model.watermarkstatus = 1; }
                else { model.watermarkstatus = 0; }
                //邮件服务
                model.mailnavtxt = mailnavtxt.Text.Trim();
                if (mailstatus.Checked == true)
                {
                    model.mailstatus = 1;
                    //显示后台导航菜单
                    navbll.UpdateField(mailnavtxt.Text.Trim(), "is_lock=0");
                }
                else
                {
                    model.mailstatus = 0;
                    //隐藏后台导航菜单
                    navbll.UpdateField(mailnavtxt.Text.Trim(), "is_lock=1");
                }
                //订单
                model.ordernavtxt = ordernavtxt.Text.Trim();
                if (orderstatus.Checked == true)
                {
                    model.orderstatus = 1;
                    //显示后台导航菜单
                    navbll.UpdateField(ordernavtxt.Text.Trim(), "is_lock=0");
                }
                else
                {
                    model.orderstatus = 0;
                    //隐藏后台导航菜单
                    navbll.UpdateField(ordernavtxt.Text.Trim(), "is_lock=1");
                }
                //在线支付
                model.paymentnavtxt = paymentnavtxt.Text.Trim();
                if (paymentstatus.Checked == true)
                {
                    model.paymentstatus = 1;
                    //显示后台导航菜单
                    navbll.UpdateField(paymentnavtxt.Text.Trim(), "is_lock=0");
                }
                else
                {
                    model.paymentstatus = 0;
                    //隐藏后台导航菜单
                    navbll.UpdateField(paymentnavtxt.Text.Trim(), "is_lock=1");
                }
                //提交留言到邮箱
                model.feedbackmailtxt = feedbackmailtxt.Text.Trim();
                if (feedbackmailstatus.Checked == true) { model.feedbackmailstatus = 1; }
                else { model.feedbackmailstatus = 0; }
                model.feedbackmailtitle = feedbackmailtitle.Text;
                model.feedbacktemplate = feedbacktemplate.Text;
                #endregion

                model.webclosereason = webclosereason.Text;

                model.filepath = filepath.Text;
                model.filesave = Utils.StrToInt(filesave.SelectedValue, 2);
                model.fileextension = fileextension.Text;
                model.attachsize = Utils.StrToInt(attachsize.Text.Trim(), 0);
                model.imgsize = Utils.StrToInt(imgsize.Text.Trim(), 0);
                model.imgmaxheight = Utils.StrToInt(imgmaxheight.Text.Trim(), 0);
                model.imgmaxwidth = Utils.StrToInt(imgmaxwidth.Text.Trim(), 0);
                model.thumbnailheight = Utils.StrToInt(thumbnailheight.Text.Trim(), 0);
                model.thumbnailwidth = Utils.StrToInt(thumbnailwidth.Text.Trim(), 0);

                bll.saveConifg(model);
                AddAdminLog(QJEnums.ActionEnum.Edit.ToString(), "修改系统配置信息"); //记录日志
                JscriptMsg("修改系统配置成功！", "sys_config.aspx", "Success", "parent.loadMenuTree");
            }
            catch
            {
                JscriptMsg("文件写入失败，请检查是否有权限！", "", "Error");
            }
        }

    }
}