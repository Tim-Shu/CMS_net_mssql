<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="seo_edit.aspx.cs" Inherits="QJcms.Web.admin.settings.seo_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑优化关键词</title>
    <link type="text/css" rel="stylesheet" href="../skin/default/style.css" />
    <script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
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
        <a href="link_list.aspx" class="back"><i></i><span>返回列表页</span></a> <a href="../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow"></i><span>系统管理</span> <i class="arrow"></i><span>优化关键词</span> <i class="arrow"></i><span>编辑关键词</span>
    </div>
    <div class="line10">
    </div>
    <!--/导航栏-->
    <!--内容-->
    <div class="content-tab-wrap">
        <div id="floatHead" class="content-tab">
            <div class="content-tab-ul-wrap">
                <ul>
                    <li><a href="javascript:;" onclick="tabs(this);" class="selected">编辑优化关键词</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="tab-content">
        <dl>
            <dt>标题名称</dt>
            <dd>
                <asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" "></asp:TextBox></dd>
        </dl>
        <dl>
            <dt>调用别名</dt>
            <dd>
                <asp:TextBox ID="txtCallIndex" runat="server" CssClass="input normal" datatype="/^\s*$|^[a-zA-Z0-9\-\_]{2,50}$/" errormsg="请填写正确的别名" sucmsg=" "></asp:TextBox>
                <span class="Validform_checktip">类别的调用别名，只允许字母、数字、下划线</span>
            </dd>
        </dl>
        <dl>
            <dt>SEO标题</dt>
            <dd>
                <asp:TextBox ID="txtSeoTitle" runat="server" MaxLength="255" CssClass="input normal" datatype="*0-100" sucmsg=" " />
                <span class="Validform_checktip">255个字符以内</span>
            </dd>
        </dl>
        <dl>
            <dt>SEO关健字</dt>
            <dd>
                <asp:TextBox ID="txtSeoKeywords" runat="server" CssClass="input" TextMode="MultiLine"></asp:TextBox>
                <span class="Validform_checktip">以“,”逗号区分开，255个字符以内</span>
            </dd>
        </dl>
        <dl>
            <dt>SEO描述</dt>
            <dd>
                <asp:TextBox ID="txtSeoDescription" runat="server" CssClass="input" TextMode="MultiLine"></asp:TextBox>
                <span class="Validform_checktip">255个字符以内</span>
            </dd>
        </dl>
    </div>
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
