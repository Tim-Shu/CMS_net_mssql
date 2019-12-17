using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QJcms.Common;

namespace QJcms.Web.admin.settings
{
    public partial class site_config : Web.UI.ManagePage
    {
        string defaultpassword = "0|0|0|0"; //默认显示密码
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("site_config", QJEnums.ActionEnum.View.ToString()); //检查权限
                ShowInfo();
            }
        }

        #region 赋值操作=================================
        private void ShowInfo()
        {
            BLL.siteconfig bll = new BLL.siteconfig();
            Model.siteconfig model = bll.loadConfig();

            webname.Text = model.webname;
            weburl.Text = model.weburl;
            weblogo.Text = model.weblogo;
            webcompany.Text = model.webcompany;
            webaddress.Text = model.webaddress;
            webtel.Text = model.webtel;
            webfax.Text = model.webfax;
            webmail.Text = model.webmail;
            webcrod.Text = model.webcrod;
            
            #region 邮件服务
            if (model.mailstatus == 1)
            {
                emailsmtp.Text = model.emailsmtp;
                emailport.Text = model.emailport.ToString();
                emailfrom.Text = model.emailfrom;
                emailusername.Text = model.emailusername;
                if (!string.IsNullOrEmpty(model.emailpassword))
                {
                    emailpassword.Attributes["value"] = defaultpassword;
                }
                emailnickname.Text = model.emailnickname;
            }
            else
            {
                mail_tab.Visible = false;
                mail_content.Visible = false;
            }
            #endregion
            #region 短信平台
            if (model.smsstatus == 1)
            {
                smsusername.Text = model.smsusername;
                if (!string.IsNullOrEmpty(model.smspassword))
                {
                    smspassword.Attributes["value"] = defaultpassword;
                }
                labSmsCount.Text = GetSmsCount(); //取得短信数量
            }
            else
            {
                sms_tab.Visible = false;
                sms_content.Visible = false;
            }
            #endregion
            #region 图片水印设置
            if (siteConfig.watermarkstatus == 1)
            {
                watermarktype.SelectedValue = model.watermarktype.ToString();
                watermarkposition.Text = model.watermarkposition.ToString();
                watermarkimgquality.Text = model.watermarkimgquality.ToString();
                watermarkpic.Text = model.watermarkpic;
                watermarktransparency.Text = model.watermarktransparency.ToString();
                watermarktext.Text = model.watermarktext;
                watermarkfont.SelectedValue = model.watermarkfont;
                watermarkfontsize.Text = model.watermarkfontsize.ToString();
            }
            else
            {
                watermark_tab.Visible = false;
                watermark_content.Visible = false;
            }
            #endregion
        }
        #endregion

        #region 获取短信数量=================================
        private string GetSmsCount()
        {
            string code = string.Empty;
            int count = new BLL.sms_message().GetAccountQuantity(out code);
            if (code == "115")
            {
                return "查询出错：请完善账户信息";
            }
            else if (code != "100")
            {
                return "错误代码：" + Utils.DropHTML(code);
            }
            return count + " 条";
        }
        #endregion

        /// <summary>
        /// 保存配置信息
        /// </summary>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("site_config", QJEnums.ActionEnum.Edit.ToString()); //检查权限
            BLL.siteconfig bll = new BLL.siteconfig();
            Model.siteconfig model = bll.loadConfig();
            try
            {
                model.webname = webname.Text;
                model.weburl = weburl.Text;
                model.weblogo = weblogo.Text;
                model.webcompany = webcompany.Text;
                model.webaddress = webaddress.Text;
                model.webtel = webtel.Text;
                model.webfax = webfax.Text;
                model.webmail = webmail.Text;
                model.webcrod = webcrod.Text;

                #region 邮件服务
                if (model.mailstatus == 1)
                {
                    model.emailsmtp = emailsmtp.Text;
                    model.emailport = Utils.StrToInt(emailport.Text.Trim(), 25);
                    model.emailfrom = emailfrom.Text;
                    model.emailusername = emailusername.Text;
                    //判断密码是否更改
                    if (emailpassword.Text.Trim() != defaultpassword)
                    {
                        model.emailpassword = DESEncrypt.Encrypt(emailpassword.Text, model.sysencryptstring);
                    }
                    model.emailnickname = emailnickname.Text;
                }
                #endregion
                #region 短信平台
                if (model.smsstatus == 1)
                {
                    model.smsusername = smsusername.Text;
                    //判断密码是否更改
                    if (smspassword.Text.Trim() != "" && smspassword.Text.Trim() != defaultpassword)
                    {
                        model.smspassword = Utils.MD5(smspassword.Text.Trim());
                    }
                }
                #endregion
                #region 图片水印设置
                if (siteConfig.watermarkstatus == 1)
                {
                    model.watermarktype = Utils.StrToInt(watermarktype.SelectedValue, 0);
                    model.watermarkposition = Utils.StrToInt(watermarkposition.Text.Trim(), 9);
                    model.watermarkimgquality = Utils.StrToInt(watermarkimgquality.Text.Trim(), 80);
                    model.watermarkpic = watermarkpic.Text;
                    model.watermarktransparency = Utils.StrToInt(watermarktransparency.Text.Trim(), 5);
                    model.watermarktext = watermarktext.Text;
                    model.watermarkfont = watermarkfont.Text;
                    model.watermarkfontsize = Utils.StrToInt(watermarkfontsize.Text.Trim(), 12);
                }
                #endregion

                bll.saveConifg(model);
                AddAdminLog(QJEnums.ActionEnum.Edit.ToString(), "修改站点配置信息"); //记录日志
                JscriptMsg("修改站点配置成功！", "site_config.aspx", "Success");
            }
            catch
            {
                JscriptMsg("文件写入失败，请检查是否有权限！", "", "Error");
            }
        }
    }
}