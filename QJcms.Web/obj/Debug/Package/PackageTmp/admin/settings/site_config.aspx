<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="site_config.aspx.cs" Inherits="QJcms.Web.admin.settings.site_config" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>站点配置</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=mac"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
            //初始化上传控件
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf" });
            });
        });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a> <a href="../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow"></i><span>网站参数配置</span>
    </div>
    <div class="line10">
    </div>
    <!--/导航栏-->
    <!--内容-->
    <div class="content-tab-wrap">
        <div id="floatHead" class="content-tab">
            <div class="content-tab-ul-wrap">
                <ul>
                    <li><a href="javascript:;" onclick="tabs(this);">网站基本信息</a></li>
                    <li runat="server" id="sms_tab"><a href="javascript:;" onclick="tabs(this);">短信平台设置</a></li>
                    <li runat="server" id="mail_tab"><a href="javascript:;" onclick="tabs(this);">邮件发送设置</a></li>
                    <li runat="server" id="watermark_tab"><a href="javascript:;" onclick="tabs(this);">图片水印设置</a></li>
                </ul>
            </div>
        </div>
    </div>
    <!--网站基本信息-->
    <div class="tab-content">
        <dl>
            <dt>网站名称</dt>
            <dd>
                <asp:TextBox ID="webname" runat="server" CssClass="input normal" datatype="*2-255" sucmsg=" " />
                <span class="Validform_checktip">*任意字符，控制在255个字符内</span>
            </dd>
        </dl>
        <dl>
            <dt>网站域名</dt>
            <dd>
                <asp:TextBox ID="weburl" runat="server" CssClass="input normal" datatype="url" sucmsg=" " />
                <span class="Validform_checktip">*以“http://”开头，不能绑定到频道分类</span>
            </dd>
        </dl>
        <dl>
            <dt>网站LOGO</dt>
            <dd>
                <asp:TextBox ID="weblogo" runat="server" CssClass="input normal upload-path" />
                <div class="upload-box upload-img">
                </div>
                <span class="Validform_checktip">*请勿随意上传更改！</span>
            </dd>
        </dl>
        <dl>
            <dt>英文名称</dt>
            <dd>
                <asp:TextBox ID="webcompany" runat="server" CssClass="input normal" />
            </dd>
        </dl>
        <dl>
            <dt>通讯地址</dt>
            <dd>
                <asp:TextBox ID="webaddress" runat="server" CssClass="input normal" />
            </dd>
        </dl>
        <dl>
            <dt>主号码</dt>
            <dd>
                <asp:TextBox ID="webtel" runat="server" CssClass="input normal" />
                <span class="Validform_checktip">*非必填，多为400或者固定电话</span>
            </dd>
        </dl>
        <dl>
            <dt>副号码</dt>
            <dd>
                <asp:TextBox ID="webfax" runat="server" CssClass="input normal" />
                <span class="Validform_checktip">*非必填，多为手机号码、传真或企业QQ</span>
            </dd>
        </dl>
        <dl>
            <dt>网站备案号</dt>
            <dd>
                <asp:TextBox ID="webcrod" runat="server" CssClass="input normal" />
            </dd>
        </dl>
    </div>
    <!--/网站基本信息-->
    <!--手机短信设置-->
    <div class="tab-content" runat="server" id="sms_content">
        <dl>
            <dt>短信剩余数量</dt>
            <dd>
                <asp:Label ID="labSmsCount" runat="server" />
                <span class="Validform_checktip">尚未申请？<a href="http://sms.qi-ju.com" target="_blank">请点击这里注册</a></span>
            </dd>
        </dl>
        <dl>
            <dt>平台登录账户</dt>
            <dd>
                <asp:TextBox ID="smsusername" runat="server" CssClass="input txt" />
                <span class="Validform_checktip">*短信平台注册的用户名</span>
            </dd>
        </dl>
        <dl>
            <dt>平台登录密码</dt>
            <dd>
                <asp:TextBox ID="smspassword" runat="server" CssClass="input txt" TextMode="Password" />
                <span class="Validform_checktip">*短信平台注册的密码</span>
            </dd>
        </dl>
        <dl>
            <dt>短信平台说明</dt>
            <dd>
                请不要使用系统默认账户test，因为它是公用的测试账号；<br />
                请在短信平台修改账户资料中绑定签名方可使用短信功能；<br />
                如果您尚未申请开通，<a href="http://sms.qi-ju.com" target="_blank">请点击这里注册</a>成功后填写您的用户名和密码均可正常使用。
            </dd>
        </dl>
    </div>
    <!--/手机短信设置-->
    <!--邮件发送设置-->
    <div class="tab-content" runat="server" id="mail_content">
        <dl>
            <dt>管理员邮箱</dt>
            <dd>
                <asp:TextBox ID="webmail" runat="server" CssClass="input normal" />
            </dd>
        </dl>
        <dl>
            <dt>SMTP服务器</dt>
            <dd>
                <asp:TextBox ID="emailsmtp" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " />
                <span class="Validform_checktip">*发送邮件的SMTP服务器地址</span>
            </dd>
        </dl>
        <dl>
            <dt>SMTP端口</dt>
            <dd>
                <asp:TextBox ID="emailport" runat="server" CssClass="input small" datatype="n" sucmsg=" " />
                <span class="Validform_checktip">*SMTP服务器的端口，大部分服务商都支持25端口</span>
            </dd>
        </dl>
        <dl>
            <dt>发件人地址</dt>
            <dd>
                <asp:TextBox ID="emailfrom" runat="server" CssClass="input normal" datatype="e" sucmsg=" " />
                <span class="Validform_checktip">*发件人的邮箱地址</span>
            </dd>
        </dl>
        <dl>
            <dt>邮箱账号</dt>
            <dd>
                <asp:TextBox ID="emailusername" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " />
                <span class="Validform_checktip">*</span>
            </dd>
        </dl>
        <dl>
            <dt>邮箱密码</dt>
            <dd>
                <asp:TextBox ID="emailpassword" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" " TextMode="Password" />
                <span class="Validform_checktip">*</span>
            </dd>
        </dl>
        <dl>
            <dt>发件人昵称</dt>
            <dd>
                <asp:TextBox ID="emailnickname" runat="server" CssClass="input normal" datatype="*0-50" sucmsg=" " />
                <span class="Validform_checktip">*对方收到邮件时显示的昵称</span>
            </dd>
        </dl>
    </div>
    <!--/邮件发送设置-->
    <!--图片水印设置-->
    <div class="tab-content" runat="server" id="watermark_content">
        <dl>
            <dt>图片水印类型</dt>
            <dd>
                <div class="rule-multi-radio">
                    <asp:RadioButtonList ID="watermarktype" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="0">关闭水印</asp:ListItem>
                        <asp:ListItem Value="1">文字水印</asp:ListItem>
                        <asp:ListItem Value="2">图片水印</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </dd>
        </dl>
        <dl>
            <dt>图片水印位置</dt>
            <dd>
                <div class="rule-multi-radio">
                    <asp:RadioButtonList ID="watermarkposition" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="1">左上</asp:ListItem>
                        <asp:ListItem Value="2">中上</asp:ListItem>
                        <asp:ListItem Value="3">右上</asp:ListItem>
                        <asp:ListItem Value="4">左中</asp:ListItem>
                        <asp:ListItem Value="5">居中</asp:ListItem>
                        <asp:ListItem Value="6">右中</asp:ListItem>
                        <asp:ListItem Value="7">左下</asp:ListItem>
                        <asp:ListItem Value="8">中下</asp:ListItem>
                        <asp:ListItem Value="9">右下</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </dd>
        </dl>
        <dl>
            <dt>图片生成质量</dt>
            <dd>
                <asp:TextBox ID="watermarkimgquality" runat="server" CssClass="input small" datatype="n" sucmsg=" " />
                <span class="Validform_checktip">*只适用于加水印的jpeg格式图片.取值范围 0-100, 0质量最低, 100质量最高, 默认80</span>
            </dd>
        </dl>
        <dl>
            <dt>图片水印文件</dt>
            <dd>
                <asp:TextBox ID="watermarkpic" runat="server" CssClass="input txt" datatype="s2-100" sucmsg=" " />
                <span class="Validform_checktip">*需存放在站点目录下，如图片不存在将使用文字水印</span>
            </dd>
        </dl>
        <dl>
            <dt>水印透明度</dt>
            <dd>
                <asp:TextBox ID="watermarktransparency" runat="server" CssClass="input small" datatype="n" sucmsg=" " />
                <span class="Validform_checktip">*取值范围1--10 (10为不透明)</span>
            </dd>
        </dl>
        <dl>
            <dt>水印文字</dt>
            <dd>
                <asp:TextBox ID="watermarktext" runat="server" CssClass="input txt" datatype="s2-100" sucmsg=" " />
                <span class="Validform_checktip">*文字水印的内容</span>
            </dd>
        </dl>
        <dl>
            <dt>文字字体</dt>
            <dd>
                <div class="rule-single-select">
                    <asp:DropDownList ID="watermarkfont" runat="server">
                        <asp:ListItem Value="Arial">Arial</asp:ListItem>
                        <asp:ListItem Value="Arial Black">Arial Black</asp:ListItem>
                        <asp:ListItem Value="Batang">Batang</asp:ListItem>
                        <asp:ListItem Value="BatangChe">BatangChe</asp:ListItem>
                        <asp:ListItem Value="Comic Sans MS">Comic Sans MS</asp:ListItem>
                        <asp:ListItem Value="Courier New">Courier New</asp:ListItem>
                        <asp:ListItem Value="Dotum">Dotum</asp:ListItem>
                        <asp:ListItem Value="DotumChe">DotumChe</asp:ListItem>
                        <asp:ListItem Value="Estrangelo Edessa">Estrangelo Edessa</asp:ListItem>
                        <asp:ListItem Value="Franklin Gothic Medium">Franklin Gothic Medium</asp:ListItem>
                        <asp:ListItem Value="Gautami">Gautami</asp:ListItem>
                        <asp:ListItem Value="Georgia">Georgia</asp:ListItem>
                        <asp:ListItem Value="Gulim">Gulim</asp:ListItem>
                        <asp:ListItem Value="GulimChe">GulimChe</asp:ListItem>
                        <asp:ListItem Value="Gungsuh">Gungsuh</asp:ListItem>
                        <asp:ListItem Value="GungsuhChe">GungsuhChe</asp:ListItem>
                        <asp:ListItem Value="Impact">Impact</asp:ListItem>
                        <asp:ListItem Value="Latha">Latha</asp:ListItem>
                        <asp:ListItem Value="Lucida Console">Lucida Console</asp:ListItem>
                        <asp:ListItem Value="Lucida Sans Unicode">Lucida Sans Unicode</asp:ListItem>
                        <asp:ListItem Value="Mangal">Mangal</asp:ListItem>
                        <asp:ListItem Value="Marlett">Marlett</asp:ListItem>
                        <asp:ListItem Value="Microsoft Sans Serif">Microsoft Sans Serif</asp:ListItem>
                        <asp:ListItem Value="MingLiU">MingLiU</asp:ListItem>
                        <asp:ListItem Value="MS Gothic">MS Gothic</asp:ListItem>
                        <asp:ListItem Value="MS Mincho">MS Mincho</asp:ListItem>
                        <asp:ListItem Value="MS PGothic">MS PGothic</asp:ListItem>
                        <asp:ListItem Value="MS PMincho">MS PMincho</asp:ListItem>
                        <asp:ListItem Value="MS UI Gothic">MS UI Gothic</asp:ListItem>
                        <asp:ListItem Value="MV Boli">MV Boli</asp:ListItem>
                        <asp:ListItem Value="Palatino Linotype">Palatino Linotype</asp:ListItem>
                        <asp:ListItem Value="PMingLiU">PMingLiU</asp:ListItem>
                        <asp:ListItem Value="Raavi">Raavi</asp:ListItem>
                        <asp:ListItem Value="Shruti">Shruti</asp:ListItem>
                        <asp:ListItem Value="Sylfaen">Sylfaen</asp:ListItem>
                        <asp:ListItem Value="Symbol">Symbol</asp:ListItem>
                        <asp:ListItem Value="Tahoma" Selected="True">Tahoma</asp:ListItem>
                        <asp:ListItem Value="Times New Roman">Times New Roman</asp:ListItem>
                        <asp:ListItem Value="Trebuchet MS">Trebuchet MS</asp:ListItem>
                        <asp:ListItem Value="Tunga">Tunga</asp:ListItem>
                        <asp:ListItem Value="Verdana">Verdana</asp:ListItem>
                        <asp:ListItem Value="Webdings">Webdings</asp:ListItem>
                        <asp:ListItem Value="Wingdings">Wingdings</asp:ListItem>
                        <asp:ListItem Value="仿宋_GB2312">仿宋_GB2312</asp:ListItem>
                        <asp:ListItem Value="宋体">宋体</asp:ListItem>
                        <asp:ListItem Value="新宋体">新宋体</asp:ListItem>
                        <asp:ListItem Value="楷体_GB2312">楷体_GB2312</asp:ListItem>
                        <asp:ListItem Value="黑体">黑体</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <asp:TextBox ID="watermarkfontsize" runat="server" CssClass="input small" datatype="n" sucmsg=" " />
                px <span class="Validform_checktip">*文字水印的字体和大小 </span>
            </dd>
        </dl>
    </div>
    <!--/图片水印设置-->
    <!--/内容-->
    <!--工具栏-->
    <div class="page-footer">
        <div class="btn-list">
            <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
            <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
        </div>
        <div class="clear">
        </div>
    </div>
    <!--/工具栏-->
    </form>
</body>
</html>
