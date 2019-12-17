<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sys_config.aspx.cs" Inherits="QJcms.Web.admin.settings.sys_config" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>系统参数设置</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=mac"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
        });
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a> <a href="../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow"></i><span>系统参数设置</span>
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
                    <li><a href="javascript:;" onclick="tabs(this);">会员权限设置</a></li>
                    <li><a href="javascript:;" onclick="tabs(this);">高级功能配置</a></li>
                    <li><a href="javascript:;" onclick="tabs(this);">文件上传设置</a></li>
                </ul>
            </div>
        </div>
    </div>
    <!--网站基本信息-->
    <div class="tab-content">
        <dl>
            <dt>网站安装目录</dt>
            <dd>
                <asp:TextBox ID="webpath" runat="server" CssClass="input txt" datatype="*1-100" sucmsg=" " />
                <span class="Validform_checktip">*根目录输入“/”，其它输入“/目录名/”</span>
            </dd>
        </dl>
        <dl>
            <dt>后台管理目录</dt>
            <dd>
                <asp:TextBox ID="webmanagepath" runat="server" CssClass="input txt" datatype="*1-100" sucmsg=" " />
                <span class="Validform_checktip">*默认admin，其它请输入目录名，否则无法进入后台</span>
            </dd>
        </dl>
        <dl>
            <dt>URL重写开关</dt>
            <dd>
                <div class="rule-multi-radio">
                    <asp:RadioButtonList ID="staticstatus" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="0" Selected="True">关闭</asp:ListItem>
                        <asp:ListItem Value="1">伪URL重写</asp:ListItem>
                        <asp:ListItem Value="2">生成静态</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <span class="Validform_checktip">*URL配置规则，点击这里查看说明</span>
            </dd>
        </dl>
        <dl>
            <dt>静态URL后缀</dt>
            <dd>
                <asp:TextBox ID="staticextension" runat="server" CssClass="input small" datatype="*1-100" sucmsg=" " />
                <span class="Validform_checktip">*扩展名，不包括“.”，访问或生成时将会替换此值，如：aspx、html</span>
            </dd>
        </dl>
        <dl>
            <dt>网站版权信息</dt>
            <dd>
                <asp:TextBox ID="webcopyright" runat="server" CssClass="input" TextMode="MultiLine" />
                <span class="Validform_checktip">支持HTML</span>
            </dd>
        </dl>
        <dl>
            <dt>是否开启网站</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="webstatus" runat="server" />
                </div>
                <span class="Validform_checktip">*关闭后网站前台将不能访问</span>
            </dd>
        </dl>
        <dl>
            <dt>网站关闭原因</dt>
            <dd>
                <asp:TextBox ID="webclosereason" runat="server" CssClass="input" TextMode="MultiLine" />
                <span class="Validform_checktip">支持HTML</span>
            </dd>
        </dl>
    </div>
    <!--/网站基本信息-->
    <!--会员权限设置-->
    <div class="tab-content">
        <dl>
            <dt>开启会员功能</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="memberstatus" runat="server" />
                </div>
                <span class="Validform_checktip">*关闭后关联会员的内容将失效</span>
            </dd>
        </dl>
        <dl>
            <dt>开启会员组</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="membergroupstatus" runat="server" />
                </div>
                <span class="Validform_checktip">*关闭后会员组相关内容将失效</span>
            </dd>
        </dl>
        <dl>
            <dt>开启会员积分</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="memberpointstatus" runat="server" />
                </div>
                <span class="Validform_checktip">*关闭后会员积分功能失效</span>
            </dd>
        </dl>
        <dl>
            <dt>开启会员等级</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="memberlevelstatus" runat="server" />
                </div>
                <span class="Validform_checktip">*关闭后会员无升级经验值</span>
            </dd>
        </dl>
        <dl>
            <dt>开启账户余额</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="memberamountstatus" runat="server" />
                </div>
                <span class="Validform_checktip">*关闭后会员不能使用余额交易</span>
            </dd>
        </dl>
        <dl>
            <dt>开启会员头像</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="memberavatarstatus" runat="server" />
                </div>
                <span class="Validform_checktip">*关闭后会员无头像显示</span>
            </dd>
        </dl>
        <dl>
            <dt>第三方登录</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="memberoauthstatus" runat="server" />
                </div>
                <span class="Validform_checktip">*关闭后会法使用第三方登录插件</span>
            </dd>
        </dl>
        <dl>
            <dt>开启评论审核</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="commentstatus" runat="server" />
                </div>
                <span class="Validform_checktip">*开启后评论将会审核才显示</span>
            </dd>
        </dl>
    </div>
    <!--/会员权限设置-->
    <!--高级功能配置-->
    <div class="tab-content">
        <dl>
            <dt>邮件服务</dt>
            <dd>
                <asp:TextBox ID="mailnavtxt" runat="server" CssClass="input txt" placeholder="导航菜单名称" title="导航菜单名称" />
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="mailstatus" runat="server" />
                </div>
                <span class="Validform_checktip">*关闭后邮件服务相关失效</span>
            </dd>
        </dl>
        <dl>
            <dt>短信平台</dt>
            <dd>
                <asp:TextBox ID="smsnavtxt" runat="server" CssClass="input txt" placeholder="导航菜单名称" title="导航菜单名称" />
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="smsstatus" runat="server" />
                </div>
                <span class="Validform_checktip">*关闭后手机短信相关失效</span>
            </dd>
        </dl>
        <dl>
            <dt>购物订单</dt>
            <dd>
                <asp:TextBox ID="ordernavtxt" runat="server" CssClass="input txt" placeholder="导航菜单名称" title="导航菜单名称" />
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="orderstatus" runat="server" />
                </div>
                <span class="Validform_checktip">*关闭后订单服务相关失效</span>
            </dd>
        </dl>
        <dl>
            <dt>在线支付</dt>
            <dd>
                <asp:TextBox ID="paymentnavtxt" runat="server" CssClass="input txt" placeholder="导航菜单名称" title="导航菜单名称" />
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="paymentstatus" runat="server" />
                </div>
                <span class="Validform_checktip">*关闭后无法在线支付</span>
            </dd>
        </dl>
        <dl>
            <dt>留言到邮箱</dt>
            <dd>
                <asp:TextBox ID="feedbackmailtxt" runat="server" CssClass="input txt" placeholder="指定的留言邮箱" title="指定的留言邮箱" />
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="feedbackmailstatus" runat="server" />
                </div>
                <span class="Validform_checktip">*关闭后留言提交到后台</span>
            </dd>
        </dl>      
        <dl>
            <dt>留言标题</dt>
            <dd>
                <asp:TextBox ID="feedbackmailtitle" runat="server" CssClass="input txt" placeholder="留言标题" title="留言标题" />
            </dd>
        </dl>
        <dl>
            <dt>留言模板</dt>
            <dd>
                <asp:TextBox ID="feedbacktemplate" runat="server" CssClass="input" TextMode="MultiLine" />
                <span class="Validform_checktip">支持HTML</span>
            </dd>
        </dl>
        <dl>
            <dt>邀请码</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="invitedstatus" runat="server" />
                </div>
                <span class="Validform_checktip">*关闭后无法申请邀请码，无法邀请注册</span>
            </dd>
        </dl>
        <dl>
            <dt>图片水印</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="watermarkstatus" runat="server" />
                </div>
                <span class="Validform_checktip">*关闭后图片水印设置无效</span>
            </dd>
        </dl>
        <dl>
            <dt>管理日志</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="logstatus" runat="server" />
                </div>
                <span class="Validform_checktip">*开启后将会记录管理员在后台的操作日志</span>
            </dd>
        </dl>
    </div>
    <!--/高级功能配置-->
    <!--上传配置-->
    <div class="tab-content">
        <dl>
            <dt>文件上传目录</dt>
            <dd>
                <asp:TextBox ID="filepath" runat="server" CssClass="input txt" datatype="*2-100" sucmsg=" " />
                <span class="Validform_checktip">*文件保存的目录名，自动创建根目录下</span>
            </dd>
        </dl>
        <dl>
            <dt>文件保存方式</dt>
            <dd>
                <div class="rule-single-select">
                    <asp:DropDownList ID="filesave" runat="server" datatype="*" sucmsg=" ">
                        <asp:ListItem Value="1">按年月日每天一个目录</asp:ListItem>
                        <asp:ListItem Value="2" Selected="True">按年月/日/存入不同目录</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </dd>
        </dl>
        <dl>
            <dt>文件上传类型</dt>
            <dd>
                <asp:TextBox ID="fileextension" runat="server" CssClass="input normal" datatype="*1-255" sucmsg=" " />
                <span class="Validform_checktip">*以英文的逗号分隔开，如：“zip,rar”</span>
            </dd>
        </dl>
        <dl>
            <dt>附件上传大小</dt>
            <dd>
                <asp:TextBox ID="attachsize" runat="server" CssClass="input small" datatype="n" sucmsg=" " />
                KB <span class="Validform_checktip">*超过设定的文件大小不予上传，0不限制</span>
            </dd>
        </dl>
        <dl>
            <dt>图片上传大小</dt>
            <dd>
                <asp:TextBox ID="imgsize" runat="server" CssClass="input small" datatype="n" sucmsg=" " />
                KB <span class="Validform_checktip">*超过设定的图片大小不予上传，0不限制</span>
            </dd>
        </dl>
        <dl>
            <dt>图片最大尺寸</dt>
            <dd>
                <asp:TextBox ID="imgmaxheight" runat="server" CssClass="input small" datatype="n" sucmsg=" " />
                ×
                <asp:TextBox ID="imgmaxwidth" runat="server" CssClass="input small" datatype="n" sucmsg=" " />
                px <span class="Validform_checktip">*左边高度，右边宽度，超出自动裁剪，0为不受限制</span>
            </dd>
        </dl>
        <dl>
            <dt>生成缩略图尺寸</dt>
            <dd>
                <asp:TextBox ID="thumbnailheight" runat="server" CssClass="input small" datatype="n" sucmsg=" " />
                ×
                <asp:TextBox ID="thumbnailwidth" runat="server" CssClass="input small" datatype="n" sucmsg=" " />
                px <span class="Validform_checktip">*左边高度，右边宽度，0为不生成缩略图</span>
            </dd>
        </dl>
    </div>
    <!--/上传配置-->
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
