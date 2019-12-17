KindEditor.plugin('remoteimage', function (K) {
    var self = this, name = 'remoteimage';
    // 点击图标时执行
    self.clickToolbar(name, function () {

        $.ajax({
            type: "post",
            url: "../../tools/admin_ajax.ashx?action=auto_remote_image_save",
            data: { content: self.html() },
            dataType: "html",
            success: function (data, textStatus) {
                self.html(data)
            }
        });
    });
});