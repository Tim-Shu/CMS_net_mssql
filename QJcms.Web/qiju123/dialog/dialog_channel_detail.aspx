<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dialog_channel_detail.aspx.cs" Inherits="QJcms.Web.admin.dialog.dialog_channel_detail" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>频道描述窗口</title>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=mac"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../editor/lang/zh_CN.js"></script>
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
            var editor = KindEditor.create('.editor', {
                width: '98%',
                height: '350px',
                resizeType: 1,
                uploadJson: '../../tools/upload_ajax.ashx?action=EditorFile&IsWater=1&channel_id=<%=id %>',
                fileManagerJson: '../../tools/upload_ajax.ashx?action=ManagerFile',
                allowFileManager: true,
                afterBlur: function () {//编辑器失去焦点时直接同步，可以取到值
                    this.sync();
                }
            });
        });
        //提交表单处理
        function submitForm() {
            //组合参数
            var postData = {
                "channel_id": "<%=id %>",
                "channel_detail": $("#txtContent").val()
            };
            //发送AJAX请求
            sendAjaxUrl(api, postData, "../../tools/admin_ajax.ashx?action=edit_channel_detail");
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="div-content">
        <dl>
            <dt>栏目描述</dt>
            <dd>
                  <textarea id="txtContent" class="editor" style="visibility: hidden;" runat="server"></textarea></dd>
        </dl>
    </div>
    </form>
</body>
</html>
