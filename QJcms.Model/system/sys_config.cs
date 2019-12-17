using System;
using System.Collections.Generic;
using System.Text;

namespace QJcms.Model
{
    /// <summary>
    /// 站点配置实体类
    /// </summary>
    [Serializable]
    public class siteconfig
    {
        public siteconfig()
        { }
        private string _webname = "";
        private string _weburl = "";
        private string _weblogo = "";
        private string _webcompany = "";
        private string _webaddress = "";
        private string _webtel = "";
        private string _webfax = "";
        private string _webmail = "";
        private string _webcrod = "";
        private string _webcopyright = "";

        private string _webpath = "";
        private string _webmanagepath = "";
        private int _staticstatus = 0;
        private string _staticextension = "";
        private int _memberstatus = 0;
        private int _membergroupstatus = 1;
        private int _memberpointstatus = 1;
        private int _memberlevelstatus = 1;
        private int _memberamountstatus = 1;
        private int _memberavatarstatus = 1;
        private int _memberoauthstatus = 0;
        private int _commentstatus = 0;
        private int _logstatus = 0;
        private int _webstatus = 1;
        private string _smsnavtxt = "";
        private int _smsstatus = 0;
        private string _paymentnavtxt = "";
        private int _paymentstatus = 0;
        private int _invitedstatus = 0;
        private int _watermarkstatus = 1;
        private int _mailstatus = 1;
        private string _mailnavtxt = "";
        private int _orderstatus = 1;
        private string _ordernavtxt = "";
        private string _webclosereason = "";
        private string _feedbackmailtxt = "";
        private int _feedbackmailstatus = 1;
        private string _feedbackmailtitle = "";
        private string _feedbacktemplate = "";

        private string _smsapiurl = "";
        private string _smsusername = "";
        private string _smspassword = "";

        private string _emailsmtp = "";
        private int _emailport = 25;
        private string _emailfrom = "";
        private string _emailusername = "";
        private string _emailpassword = "";
        private string _emailnickname = "";

        private string _filepath = "";
        private int _filesave = 1;
        private string _fileextension = "";
        private int _attachsize = 0;
        private int _imgsize = 0;
        private int _imgmaxheight = 0;
        private int _imgmaxwidth = 0;
        private int _thumbnailheight = 0;
        private int _thumbnailwidth = 0;
        private int _watermarktype = 0;
        private int _watermarkposition = 9;
        private int _watermarkimgquality = 80;
        private string _watermarkpic = "";
        private int _watermarktransparency = 10;
        private string _watermarktext = "";
        private string _watermarkfont = "";
        private int _watermarkfontsize = 12;

        private string _sysdatabaseprefix = "qj_";
        private string _sysencryptstring = "QJcms";

        #region 网站基本信息==================================
        /// <summary>
        /// 网站名称
        /// </summary>
        public string webname
        {
            get { return _webname; }
            set { _webname = value; }
        }
        /// <summary>
        /// 网站域名
        /// </summary>
        public string weburl
        {
            get { return _weburl; }
            set { _weburl = value; }
        }
        /// <summary>
        /// 网站LOGO
        /// </summary>
        public string weblogo
        {
            get { return _weblogo; }
            set { _weblogo = value; }
        }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string webcompany
        {
            get { return _webcompany; }
            set { _webcompany = value; }
        }
        /// <summary>
        /// 通讯地址
        /// </summary>
        public string webaddress
        {
            get { return _webaddress; }
            set { _webaddress = value; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string webtel
        {
            get { return _webtel; }
            set { _webtel = value; }
        }
        /// <summary>
        /// 传真号码
        /// </summary>
        public string webfax
        {
            get { return _webfax; }
            set { _webfax = value; }
        }
        /// <summary>
        /// 管理员邮箱
        /// </summary>
        public string webmail
        {
            get { return _webmail; }
            set { _webmail = value; }
        }
        /// <summary>
        /// 网站备案号
        /// </summary>
        public string webcrod
        {
            get { return _webcrod; }
            set { _webcrod = value; }
        }
        /// <summary>
        /// 网站版权信息
        /// </summary>
        public string webcopyright
        {
            get { return _webcopyright; }
            set { _webcopyright = value; }
        }
        #endregion

        #region 功能权限设置==================================
        /// <summary>
        /// 网站安装目录
        /// </summary>
        public string webpath
        {
            get { return _webpath; }
            set { _webpath = value; }
        }
        /// <summary>
        /// 网站管理目录
        /// </summary>
        public string webmanagepath
        {
            get { return _webmanagepath; }
            set { _webmanagepath = value; }
        }
        /// <summary>
        /// 是否开启生成静态
        /// </summary>
        public int staticstatus
        {
            get { return _staticstatus; }
            set { _staticstatus = value; }
        }
        /// <summary>
        /// 生成静态扩展名
        /// </summary>
        public string staticextension
        {
            get { return _staticextension; }
            set { _staticextension = value; }
        }
        /// <summary>
        /// 开启会员功能
        /// </summary>
        public int memberstatus
        {
            get { return _memberstatus; }
            set { _memberstatus = value; }
        }
        /// <summary>
        /// 开启会员组功能
        /// </summary>
        public int membergroupstatus
        {
            get { return _membergroupstatus; }
            set { _membergroupstatus = value; }
        }
        /// <summary>
        /// 开启会员积分功能
        /// </summary>
        public int memberpointstatus
        {
            get { return _memberpointstatus; }
            set { _memberpointstatus = value; }
        }
        /// <summary>
        /// 开启会员等级功能
        /// </summary>
        public int memberlevelstatus
        {
            get { return _memberlevelstatus; }
            set { _memberlevelstatus = value; }
        }
        /// <summary>
        /// 开启账户余额功能
        /// </summary>
        public int memberamountstatus
        {
            get { return _memberamountstatus; }
            set { _memberamountstatus = value; }
        }
        /// <summary>
        /// 开启会员头像上传功能
        /// </summary>
        public int memberavatarstatus
        {
            get { return _memberavatarstatus; }
            set { _memberavatarstatus = value; }
        }
        /// <summary>
        /// 开启第三方登录插件
        /// </summary>
        public int memberoauthstatus
        {
            get { return _memberoauthstatus; }
            set { _memberoauthstatus = value; }
        }
        /// <summary>
        /// 开启评论审核
        /// </summary>
        public int commentstatus
        {
            get { return _commentstatus; }
            set { _commentstatus = value; }
        }
        /// <summary>
        /// 后台管理日志
        /// </summary>
        public int logstatus
        {
            get { return _logstatus; }
            set { _logstatus = value; }
        }
        /// <summary>
        /// 是否关闭网站
        /// </summary>
        public int webstatus
        {
            get { return _webstatus; }
            set { _webstatus = value; }
        }
        /// <summary>
        /// 短信平台导航菜单名称
        /// </summary>
        public string smsnavtxt
        {
            get { return _smsnavtxt; }
            set { _smsnavtxt = value; }
        }
        /// <summary>
        /// 是否关闭短信平台
        /// </summary>
        public int smsstatus
        {
            get { return _smsstatus; }
            set { _smsstatus = value; }
        }
        /// <summary>
        /// 在线支付导航菜单名称
        /// </summary>
        public string paymentnavtxt
        {
            get { return _paymentnavtxt; }
            set { _paymentnavtxt = value; }
        }
        /// <summary>
        /// 是否关闭在线支付
        /// </summary>
        public int paymentstatus
        {
            get { return _paymentstatus; }
            set { _paymentstatus = value; }
        }
        /// <summary>
        /// 是否关闭邀请码发放
        /// </summary>
        public int invitedstatus
        {
            get { return _invitedstatus; }
            set { _invitedstatus = value; }
        }
        /// <summary>
        /// 是否关闭图片水印
        /// </summary>
        public int watermarkstatus
        {
            get { return _watermarkstatus; }
            set { _watermarkstatus = value; }
        }
        /// <summary>
        /// 是否关闭邮件服务
        /// </summary>
        public int mailstatus
        {
            get { return _mailstatus; }
            set { _mailstatus = value; }
        }
        /// <summary>
        /// 邮件服务导航菜单名称
        /// </summary>
        public string mailnavtxt
        {
            get { return _mailnavtxt; }
            set { _mailnavtxt = value; }
        }
        /// <summary>
        /// 是否关闭订单
        /// </summary>
        public int orderstatus
        {
            get { return _orderstatus; }
            set { _orderstatus = value; }
        }
        /// <summary>
        /// 订单服务导航菜单名称
        /// </summary>
        public string ordernavtxt
        {
            get { return _ordernavtxt; }
            set { _ordernavtxt = value; }
        }
        /// <summary>
        /// 关闭原因描述
        /// </summary>
        public string webclosereason
        {
            get { return _webclosereason; }
            set { _webclosereason = value; }
        }
        /// <summary>
        /// 留言指定的邮箱
        /// </summary>
        public string feedbackmailtxt
        {
            get { return _feedbackmailtxt; }
            set { _feedbackmailtxt = value; }
        }
        /// <summary>
        /// 开启留言到邮箱
        /// </summary>
        public int feedbackmailstatus
        {
            get { return _feedbackmailstatus; }
            set { _feedbackmailstatus = value; }
        }
        /// <summary>
        /// 留言标题
        /// </summary>
        public string feedbackmailtitle
        {
            get { return _feedbackmailtitle; }
            set { _feedbackmailtitle = value; }
        }
        /// <summary>
        /// 留言模板
        /// </summary>
        public string feedbacktemplate
        {
            get { return _feedbacktemplate; }
            set { _feedbacktemplate = value; }
        }
        #endregion

        #region 短信平台设置==================================
        /// <summary>
        /// 短信API地址
        /// </summary>
        public string smsapiurl
        {
            get { return _smsapiurl; }
            set { _smsapiurl = value; }
        }
        /// <summary>
        /// 短信平台登录账户名
        /// </summary>
        public string smsusername
        {
            get { return _smsusername; }
            set { _smsusername = value; }
        }
        /// <summary>
        /// 短信平台登录密码
        /// </summary>
        public string smspassword
        {
            get { return _smspassword; }
            set { _smspassword = value; }
        }
        #endregion

        #region 邮件发送设置==================================
        /// <summary>
        /// STMP服务器
        /// </summary>
        public string emailsmtp
        {
            get { return _emailsmtp; }
            set { _emailsmtp = value; }
        }
        /// <summary>
        /// SMTP端口
        /// </summary>
        public int emailport
        {
            get { return _emailport; }
            set { _emailport = value; }
        }
        /// <summary>
        /// 发件人地址
        /// </summary>
        public string emailfrom
        {
            get { return _emailfrom; }
            set { _emailfrom = value; }
        }
        /// <summary>
        /// 邮箱账号
        /// </summary>
        public string emailusername
        {
            get { return _emailusername; }
            set { _emailusername = value; }
        }
        /// <summary>
        /// 邮箱密码
        /// </summary>
        public string emailpassword
        {
            get { return _emailpassword; }
            set { _emailpassword = value; }
        }
        /// <summary>
        /// 发件人昵称
        /// </summary>
        public string emailnickname
        {
            get { return _emailnickname; }
            set { _emailnickname = value; }
        }
        #endregion

        #region 文件上传设置==================================
        /// <summary>
        /// 附件上传目录
        /// </summary>
        public string filepath
        {
            get { return _filepath; }
            set { _filepath = value; }
        }
        /// <summary>
        /// 附件保存方式
        /// </summary>
        public int filesave
        {
            get { return _filesave; }
            set { _filesave = value; }
        }
        /// <summary>
        /// 附件上传类型
        /// </summary>
        public string fileextension
        {
            get { return _fileextension; }
            set { _fileextension = value; }
        }
        /// <summary>
        /// 文件上传大小
        /// </summary>
        public int attachsize
        {
            get { return _attachsize; }
            set { _attachsize = value; }
        }
        /// <summary>
        /// 图片上传大小
        /// </summary>
        public int imgsize
        {
            get { return _imgsize; }
            set { _imgsize = value; }
        }
        /// <summary>
        /// 图片最大高度(像素)
        /// </summary>
        public int imgmaxheight
        {
            get { return _imgmaxheight; }
            set { _imgmaxheight = value; }
        }
        /// <summary>
        /// 图片最大宽度(像素)
        /// </summary>
        public int imgmaxwidth
        {
            get { return _imgmaxwidth; }
            set { _imgmaxwidth = value; }
        }
        /// <summary>
        /// 生成缩略图高度(像素)
        /// </summary>
        public int thumbnailheight
        {
            get { return _thumbnailheight; }
            set { _thumbnailheight = value; }
        }
        /// <summary>
        /// 生成缩略图宽度(像素)
        /// </summary>
        public int thumbnailwidth
        {
            get { return _thumbnailwidth; }
            set { _thumbnailwidth = value; }
        }
        /// <summary>
        /// 图片水印类型
        /// </summary>
        public int watermarktype
        {
            get { return _watermarktype; }
            set { _watermarktype = value; }
        }
        /// <summary>
        /// 图片水印位置
        /// </summary>
        public int watermarkposition
        {
            get { return _watermarkposition; }
            set { _watermarkposition = value; }
        }
        /// <summary>
        /// 图片生成质量
        /// </summary>
        public int watermarkimgquality
        {
            get { return _watermarkimgquality; }
            set { _watermarkimgquality = value; }
        }
        /// <summary>
        /// 图片水印文件
        /// </summary>
        public string watermarkpic
        {
            get { return _watermarkpic; }
            set { _watermarkpic = value; }
        }
        /// <summary>
        /// 水印透明度
        /// </summary>
        public int watermarktransparency
        {
            get { return _watermarktransparency; }
            set { _watermarktransparency = value; }
        }
        /// <summary>
        /// 水印文字
        /// </summary>
        public string watermarktext
        {
            get { return _watermarktext; }
            set { _watermarktext = value; }
        }
        /// <summary>
        /// 文字字体
        /// </summary>
        public string watermarkfont
        {
            get { return _watermarkfont; }
            set { _watermarkfont = value; }
        }
        /// <summary>
        /// 文字大小(像素)
        /// </summary>
        public int watermarkfontsize
        {
            get { return _watermarkfontsize; }
            set { _watermarkfontsize = value; }
        }
        #endregion

        #region 安装初始化设置================================
        /// <summary>
        /// 数据库表前缀
        /// </summary>
        public string sysdatabaseprefix
        {
            get { return _sysdatabaseprefix; }
            set { _sysdatabaseprefix = value; }
        }
        /// <summary>
        /// 加密字符串
        /// </summary>
        public string sysencryptstring
        {
            get { return _sysencryptstring; }
            set { _sysencryptstring = value; }
        }
        #endregion
    }
}
