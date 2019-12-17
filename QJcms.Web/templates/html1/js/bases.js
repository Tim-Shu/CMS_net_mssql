//加入收藏 <a href="#" onclick="AddFavorite(window.location,document.title)">加入收藏</a>
function AddFavorite(sURL, sTitle) {
    sURL = encodeURI(sURL);
    try { window.external.addFavorite(sURL, sTitle); } catch (e) {
        try { window.sidebar.addPanel(sTitle, sURL, ""); } catch (e) { alert("加入收藏失败，请使用Ctrl+D进行添加,或手动在浏览器里进行设置."); }
    }
}
//设为首页 <a href="#" onclick="SetHome(this,window.location)">设为首页</a>
function SetHome(url) {
    if (document.all) {
        document.body.style.behavior = 'url(#default#homepage)';
        document.body.setHomePage(url);
    } else {
        alert("您好,您的浏览器不支持自动设置页面为首页功能,请您手动在浏览器里设置该页面为首页!");
    }
}
/*切换验证码*/
function ToggleCode(obj, codeurl) {
    $(obj).children("img").eq(0).attr("src", codeurl + "?time=" + Math.random());
    return false;
}

/*缩略图*/
function AutoResizeImage(maxWidth, maxHeight, objImg) {
    var img = new Image();
    img.src = objImg.src;
    var wRatio, hRatio;
    var Ratio = 1;
    var w = img.width;
    var h = img.height;
    wRatio = maxWidth / w;
    hRatio = maxHeight / h;
    if (maxWidth == 0 && maxHeight == 0) {
        Ratio = 1;
    }
    else if (maxWidth == 0) {
        if (hRatio < 1) Ratio = hRatio;
    }
    else if (maxHeight == 0) {
        if (wRatio < 1) Ratio = wRatio;
    }
    else if (wRatio < 1 || hRatio < 1) {
        Ratio = (wRatio <= hRatio ? wRatio : hRatio);
    }
    if (Ratio < 1) {
        w = w * Ratio;
        h = h * Ratio;
    }
    objImg.height = h;
    objImg.width = w;
}

/*日期显示*/
function initArray() {
    for (i = 0; i < initArray.arguments.length; i++)
        this[i] = initArray.arguments[i];
}
var isnMonths = new initArray("1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12");
var isnDays = new initArray("星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六", "星期日");
today = new Date();
hrs = today.getHours();
min = today.getMinutes();
sec = today.getSeconds();
clckh = "" + ((hrs > 12) ? hrs - 12 : hrs);
clckm = ((min < 10) ? "0" : "") + min; clcks = ((sec < 10) ? "0" : "") + sec;
clck = (hrs >= 12) ? "下午" : "上午";
var stnr = "";
var ns = "0123456789";
var a = "";
function getFullYear(d) {
    yr = d.getYear();
    if (yr < 1000)
        yr += 1900;
    return yr;
}


/*搜索查询*/
function SiteSearch(send_url, divTgs, channel_name) {
    var strwhere = "";
    if (channel_name !== undefined) {
        strwhere = "&channel_name=" + channel_name
    }
    var str = $.trim($(divTgs).val());
    if (str.length > 0 && str != "输入关健字") {
        window.location.href = send_url + "?keyword=" + encodeURI($(divTgs).val()) + strwhere;
    }
    return false;
}
/*表单AJAX提交封装(包含验证)*/
function AjaxInitForm(formId, btnId, isDialog, urlId) {
    var formObj = $('#' + formId);
    var btnObj = $("#" + btnId);
    var urlObj = $("#" + urlId);
    formObj.Validform({
        tiptype: 3,
        callback: function (form) {
            /*AJAX提交表单*/
            $(form).ajaxSubmit({
                beforeSubmit: formRequest,
                success: formResponse,
                error: formError,
                url: formObj.attr("url"),
                type: "post",
                dataType: "json",
                timeout: 60000
            });
            return false;
        }
    });

    /*表单提交前*/
    function formRequest(formData, jqForm, options) {
        btnObj.prop("disabled", true);
        btnObj.val("提交中...");
    }

    /*表单提交后*/
    function formResponse(data, textStatus) {
        if (data.status == 1) {
            btnObj.val("提交成功");
            /*是否提示，默认不提示*/
            if (isDialog == 1) {
                $.dialog.tips(data.msg, 2, "32X32/succ.png", function () {
                    if (data.url) {
                        location.href = data.url;
                    } else if (urlObj.length > 0 && urlObj.val() != "") {
                        location.href = urlObj.val();
                    } else {
                        location.reload();
                    }
                });
            } else {
                if (data.url) {
                    location.href = data.url;
                } else if (urlObj) {
                    location.href = urlObj.val();
                } else {
                    location.reload();
                }
            }
        } else {
            $.dialog.alert(data.msg);
            btnObj.prop("disabled", false);
            btnObj.val("再次提交");
        }
    }
    /*表单提交出错*/
    function formError(XMLHttpRequest, textStatus, errorThrown) {
        $.dialog.alert("状态：" + textStatus + "；出错提示：" + errorThrown);
        btnObj.prop("disabled", false);
        btnObj.val("再次提交");
    }
}

//链接下载
function downLink(point, linkurl) {
    if (point > 0) {
        $.dialog.confirm("下载需扣除" + point + "个积分<br />有效时间内重复下载不扣积分，继续吗？", function () {
            window.location.href = linkurl;
        });
    } else {
        window.location.href = linkurl;
    }
    return false;
}