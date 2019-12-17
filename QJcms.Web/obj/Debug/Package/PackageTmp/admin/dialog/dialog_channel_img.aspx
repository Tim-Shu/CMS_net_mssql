<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dialog_channel_img.aspx.cs" Inherits="QJcms.Web.admin.dialog.dialog_channel_img" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>频道封面窗口</title>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=mac"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <script type="text/javascript">
        //窗口API
        var api = frameElement.api, W = api.opener;
        api.button({
            name: '确定',
            focus: true,
            callback: function () {
                submitForm();
                return false;
            }
        }, {
            name: '取消'
        });
        $(function () {
            //初始化上传控件
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf", view: "#imgChannel" });
            });
            $("#txtImgUrl").change(function () {
                $("#imgChannel").attr("src", $(this).val());
            });
        });
        //提交表单处理
        function submitForm() {
            //组合参数
            var postData = {
                "channel_id": "<%=id %>",
                "channel_img": $("#txtImgUrl").val()
            };
            //发送AJAX请求
            sendAjaxUrl(api, postData, "../../tools/admin_ajax.ashx?action=edit_channel_img");
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="div-content">
        <dl>
            <dt>上传封面图片</dt>
            <dd>
                <asp:TextBox ID="txtImgUrl" runat="server" CssClass="input normal upload-path" />
                <div class="upload-box upload-img">
                </div>
            </dd>
        </dl>
        <dl>
            <dt>封面预览</dt>
            <dd>
                <img src="../skin/default/loadimg.gif" runat="server" id="imgChannel" alt="" class="img-view" /></dd>
        </dl>
    </div>
    </form>
</body>
</html>
