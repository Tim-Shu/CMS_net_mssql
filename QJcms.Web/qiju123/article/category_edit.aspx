<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="category_edit.aspx.cs" Inherits="QJcms.Web.admin.article.category_edit" ValidateRequest="false" %>

<%@ Import Namespace="QJcms.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑类别</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=mac"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.queue.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/lang/zh_CN.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <script type="text/javascript" src="../js/pinyin.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        //设置参数
        var isWater = false;
        var isThumbnail = false;
        var fileSize = "<%=upImgSize %>";

        $(function () {
            //赋值参数
            if ("<%=isWater %>" == "Ture") {
                isWater = true;
            }
            if ("<%=isThumbnail %>" == "Ture") {
                isThumbnail = true;
            }
            //初始化表单验证
            $("#form1").initValidform();

            $("#btnVarAdd").click(function () {
                varHtml = createVarHtml();
                $("#tr_box").append(varHtml);

            });
            //初始化上传控件
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ channelid: "<%=channel_id %>", sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf" });
            });
            $(".upload-album").each(function () {
                $(this).InitSWFUpload({ btntext: "批量上传", btnwidth: 66, single: false, water: isWater, thumbnail: isThumbnail, filesize: fileSize, channelid: "<%=channel_id %>", sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf", filetypes: "*.jpg;*.jpge;*.png;*.gif;" });
            });
            //初始化编辑器
            var editorMini = KindEditor.create('#txtContent', {
                width: '98%',
                height: '250px',
                resizeType: 1,
                uploadJson: '../../tools/upload_ajax.ashx?action=EditorFile&IsWater=1&channel_id=<%=channel_id %>',
                items: [
				'source', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
				'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
				'insertunorderedlist', '|', 'image', 'link', 'fullscreen']
            });
            //设置封面图片的样式
            $(".photo-list ul li .img-box img").each(function () {
                if ($(this).attr("src") == $("#hidFocusPhoto").val()) {
                    $(this).parent().addClass("selected");
                }
            });
        });

        function change2cn(en, cninput) {
            if (cninput.value == "") {
                cninput.value = getSpell(en, "");
            }
        }
   
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="category_list.aspx" class="back"><i></i><span>返回列表页</span></a> <a href="../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow"></i><a href="category_list.aspx"><span>内容类别</span></a> <i class="arrow"></i><span>编辑分类</span>
    </div>
    <div class="line10">
    </div>
    <!--/导航栏-->
    <!--内容-->
    <div class="content-tab-wrap">
        <div id="floatHead" class="content-tab">
            <div class="content-tab-ul-wrap">
                <ul>
                    <li><a href="javascript:;" onclick="tabs(this);">基本信息</a></li>
                    <li runat="server" id="tab_into"><a href="javascript:;" onclick="tabs(this);">类别描述</a></li>
                    <li runat="server" id="tab_seo"><a href="javascript:;" onclick="tabs(this);">SEO选项</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="tab-content">
        <dl runat="server" id="dlParent">
            <dt>所属父类别</dt>
            <dd>
                <div class="rule-single-select">
                    <asp:DropDownList ID="ddlParentId" runat="server">
                    </asp:DropDownList>
                </div>
            </dd>
        </dl>
        <dl>
            <dt>排序数字</dt>
            <dd>
                <asp:TextBox ID="txtSortId" runat="server" CssClass="input small" datatype="n" sucmsg=" ">99</asp:TextBox>
                <span class="Validform_checktip">*数字，越小越向前</span>
            </dd>
        </dl>
        <dl>
            <dt>类别名称</dt>
            <dd>
                <asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*1-100" sucmsg=" "></asp:TextBox>
                <span class="Validform_checktip">*类别中文名称，100字符内</span></dd>
        </dl>
        <dl>
            <dt>副标题</dt>
            <dd>
                <asp:TextBox ID="txtSubTitle" runat="server" CssClass="input normal" datatype="*0-100" sucmsg=" "></asp:TextBox>
                <span class="Validform_checktip">*类别副标题 可为空，100字符内</span></dd>
        </dl>
		<dl runat="server" id="dlSystem">
            <dt>系统内容</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="cbIsSys" runat="server" />
                </div>
                <span class="Validform_checktip">*开启后内容不可删除</span>
            </dd>
        </dl>
        <dl runat="server" id="dlCall">
            <dt>调用别名</dt>
            <dd>
                <asp:TextBox ID="txtCallIndex" runat="server" CssClass="input normal" datatype="/^\s*$|^[a-zA-Z0-9\-\_]{2,50}$/" errormsg="请填写正确的别名" sucmsg=" " ajaxurl="../../tools/admin_ajax.ashx?action=category_call_validate"></asp:TextBox>
                <span class="Validform_checktip">一经填写，不可更改。类别的调用别名，只允许字母、数字、下划线</span>
            </dd>
        </dl>
        <dl runat="server" id="dlLink">
            <dt>URL链接</dt>
            <dd>
                <asp:TextBox ID="txtLinkUrl" runat="server" MaxLength="255" CssClass="input normal" />
                <span class="Validform_checktip">填写后直接跳转到该网址</span>
            </dd>
        </dl>
        <dl runat="server" id="dlImg">
            <dt>显示图片</dt>
            <dd>
                <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input normal upload-path" />
                <div class="upload-box upload-img">
                </div>
            </dd>
        </dl>
        <dl runat="server" id="dlAlbums">
            <dt>图片相册</dt>
            <dd>
                <div class="upload-box upload-album">
                </div>
                <input type="hidden" name="hidFocusPhoto" id="hidFocusPhoto" runat="server" class="focus-photo" />
                <div class="photo-list">
                    <ul>
                        <asp:Repeater ID="rptAlbumList" runat="server">
                            <ItemTemplate>
                                <li>
                                    <input type="hidden" name="hid_photo_name" value="<%#Eval("id")%>|<%#Eval("original_path")%>|<%#Eval("thumb_path")%>" />
                                    <input type="hidden" name="hid_photo_remark" value="<%#Eval("remark")%>" />
                                    <div class="img-box" onclick="setFocusImg(this);">
                                        <img src="<%#Eval("thumb_path")%>" bigsrc="<%#Eval("original_path")%>" />
                                        <span class="remark"><i>
                                            <%#Eval("remark").ToString() == "" ? "暂无描述..." : Eval("remark").ToString()%></i></span>
                                    </div>
                                    <a href="javascript:;" onclick="setRemark(this);">描述</a> <a href="javascript:;" onclick="delImg(this);">删除</a> </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </dd>
        </dl>
    </div>
    <div class="tab-content" runat="server" id="content_into">
        <dl>
            <dt>类别介绍</dt>
            <dd>
                <textarea id="txtContent" class="editor" style="visibility: hidden;" runat="server"></textarea>
            </dd>
        </dl>
    </div>
    <div class="tab-content" runat="server" id="content_seo">
        <dl>
            <dt>SEO标题</dt>
            <dd>
                <asp:TextBox ID="txtSeoTitle" runat="server" MaxLength="255" CssClass="input normal" datatype="s0-100" sucmsg=" " />
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
