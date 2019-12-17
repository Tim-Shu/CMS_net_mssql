using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QJcms.Common;

namespace QJcms.Web.admin.users
{
    public partial class user_config : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindFun();
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("user_config", QJEnums.ActionEnum.View.ToString()); //检查权限
                ShowInfo();
            }
        }

        private void BindFun()
        {
            if (siteConfig.memberpointstatus == 0) { point_tab.Visible = false; point_content.Visible = false; }
            if (siteConfig.invitedstatus == 0) { invited_tab.Visible = false; invited_content.Visible = false; }
        }

        #region 赋值操作=================================
        private void ShowInfo()
        {
            regstatus.Items.Add(new ListItem("关闭注册", "0"));
            regstatus.Items.Add(new ListItem("开放注册", "1"));
            if (siteConfig.smsstatus == 1) { regstatus.Items.Add(new ListItem("手机短信", "2")); }
            if (siteConfig.mailstatus == 1) { regstatus.Items.Add(new ListItem("邮箱注册", "3")); }
            if (siteConfig.invitedstatus == 1) { regstatus.Items.Add(new ListItem("邀请码", "4")); }

            regverify.Items.Add(new ListItem("无验证", "0"));
            if (siteConfig.mailstatus == 1) { regverify.Items.Add(new ListItem("邮箱验证", "1")); }
            if (siteConfig.smsstatus == 1) { regverify.Items.Add(new ListItem("手机短信", "2")); }
            regverify.Items.Add(new ListItem("人工审核", "3"));
            regmsgstatus.Items.Add(new ListItem("不发送", "0"));
            regmsgstatus.Items.Add(new ListItem("站内消息", "1"));
            if (siteConfig.mailstatus == 1) { regmsgstatus.Items.Add(new ListItem("发送邮件", "2")); }
            if (siteConfig.smsstatus == 1) { regmsgstatus.Items.Add(new ListItem("手机短信", "3")); }

            BLL.userconfig bll = new BLL.userconfig();
            Model.userconfig model = bll.loadConfig();
            regstatus.SelectedValue = model.regstatus.ToString();
            regverify.SelectedValue = model.regverify.ToString();
            regmsgstatus.SelectedValue = model.regmsgstatus.ToString();
            regmsgtxt.Text = model.regmsgtxt;
            regkeywords.Text = model.regkeywords;
            regctrl.Text = model.regctrl.ToString();

            if (siteConfig.mailstatus == 1)
            {
                regemailexpired.Text = model.regemailexpired.ToString();
                if (model.regemailditto == 1) { regemailditto.Checked = true; }
                else { regemailditto.Checked = false; }
                if (model.emaillogin == 1) { emaillogin.Checked = true; }
                else { emaillogin.Checked = false; }
            }
            else
            {
                mailditto.Visible = false;
                mailexpired.Visible = false;
                maillogin.Visible = false;
            }
            if (model.regrules == 1) { regrules.Checked = true; }
            else { regrules.Checked = false; }
            regrulestxt.Text = model.regrulestxt;

            if (siteConfig.invitedstatus == 1)
            {
                invitecodeexpired.Text = model.invitecodeexpired.ToString();
                invitecodecount.Text = model.invitecodecount.ToString();
                invitecodenum.Text = model.invitecodenum.ToString();
            }
            if (siteConfig.memberpointstatus == 1)
            {
                pointcashrate.Text = model.pointcashrate.ToString();
                pointloginnum.Text = model.pointloginnum.ToString();
            }
            if (siteConfig.invitedstatus == 1 && siteConfig.memberpointstatus == 1)
            {
                pointinvitenum.Text = model.pointinvitenum.ToString();
            }
            else
            {
                dlInvitPoint.Visible = false;
            }
            if (siteConfig.smsstatus == 1)
            {
                regsmsexpired.Text = model.regsmsexpired.ToString();
                if (model.mobilelogin == 1) { mobilelogin.Checked = true; }
                else { mobilelogin.Checked = false; }
            }
            else
            {
                smsexpired.Visible = false;
                smslogin.Visible = false;
            }
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("user_config", QJEnums.ActionEnum.Edit.ToString()); //检查权限
            BLL.userconfig bll = new BLL.userconfig();
            Model.userconfig model = bll.loadConfig();
            try
            {
                model.regstatus = Utils.StrToInt(regstatus.SelectedValue, 0);
                model.regverify = Utils.StrToInt(regverify.SelectedValue, 0);
                model.regmsgstatus = Utils.StrToInt(regmsgstatus.SelectedValue, 0);
                model.regmsgtxt = regmsgtxt.Text;
                model.regkeywords = regkeywords.Text.Trim();
                model.regctrl = Utils.StrToInt(regctrl.Text.Trim(), 0);
                model.regemailexpired = Utils.StrToInt(regemailexpired.Text.Trim(), 0);
                if (regemailditto.Checked == true) { model.regemailditto = 1; }
                else { model.regemailditto = 0; }
                if (siteConfig.smsstatus == 1)
                {
                    if (mobilelogin.Checked == true) { model.mobilelogin = 1; }
                    else { model.mobilelogin = 0; }
                    model.regsmsexpired = Utils.StrToInt(regsmsexpired.Text.Trim(), 0);
                }
                if (emaillogin.Checked == true) { model.emaillogin = 1; }
                else { model.emaillogin = 0; }
                if (regrules.Checked == true) { model.regrules = 1; }
                else { model.regrules = 0; }
                model.regrulestxt = regrulestxt.Text;

                if (siteConfig.invitedstatus == 1)
                {
                    model.invitecodeexpired = Utils.StrToInt(invitecodeexpired.Text.Trim(), 0);
                    model.invitecodecount = Utils.StrToInt(invitecodecount.Text.Trim(), 0);
                    model.invitecodenum = Utils.StrToInt(invitecodenum.Text.Trim(), 0);
                }
                if (siteConfig.memberpointstatus == 1)
                {
                    model.pointcashrate = Utils.StrToDecimal(pointcashrate.Text.Trim(), 0);
                    model.pointloginnum = Utils.StrToInt(pointloginnum.Text.Trim(), 0);
                }
                if (siteConfig.invitedstatus == 1 && siteConfig.memberpointstatus == 1)
                {
                    model.pointinvitenum = Utils.StrToInt(pointinvitenum.Text.Trim(), 0);
                }
                bll.saveConifg(model);
                AddAdminLog(QJEnums.ActionEnum.Edit.ToString(), "修改用户配置信息"); //记录日志
                JscriptMsg("修改用户配置成功！", "user_config.aspx", "Success");
            }
            catch
            {
                JscriptMsg("文件写入失败，请检查是否有权限！", "", "Error");
            }
        }

    }
}