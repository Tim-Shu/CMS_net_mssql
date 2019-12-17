<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="distribution_edit.aspx.cs" Inherits="QJcms.Web.admin.order.distribution_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>配送范围</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=mac"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function loadCity(id) {
            $("#provinceList li").removeClass("on");
            $(".provinceLI-" + id).addClass("on");
            $("#districtList").html('<li class="distrbution-title">市/县辖市</li>');
            //发送AJAX请求 加载城市列表
            $.ajax({
                type: "post",
                url: "../../tools/admin_ajax.ashx?action=get_city_list",
                data: { province_id: id },
                dataType: "html",
                success: function (data, textStatus) {
                    //将得到的数据插件到页面中
                    $("#cityList").html(data);
                    $("#cityList .rule-single-checkbox").ruleSingleCheckbox();
                    checkCityLock();
                }
            });
        }
        function loadDistrict(id) {
            $("#cityList li").removeClass("on");
            $(".cityLI-" + id).addClass("on");
            //发送AJAX请求 加载城市列表
            $.ajax({
                type: "post",
                url: "../../tools/admin_ajax.ashx?action=get_district_list",
                data: { city_id: id },
                dataType: "html",
                success: function (data, textStatus) {
                    //将得到的数据插件到页面中
                    $("#districtList").html(data);
                    $("#districtList .rule-single-checkbox").ruleSingleCheckbox();
                    checkDistrictLock();
                }
            });
        }
        $(function () {
            $("#provinceList .option-lock a").click(function () {
                //发送AJAX请求 设置省份开关
                $.ajax({
                    type: "post",
                    url: "../../tools/admin_ajax.ashx?action=set_province_lock",
                    data: { province_id: $($(this).next()).attr("id") },
                    dataType: "html",
                    success: function (data, textStatus) {                        
                    }
                });
            });
        });
        function checkCityLock() {
            $("#cityList .option-lock a").bind("click",function () {
                //发送AJAX请求 设置省份开关
                $.ajax({
                    type: "post",
                    url: "../../tools/admin_ajax.ashx?action=set_city_lock",
                    data: { city_id: $($(this).next()).attr("id") },
                    dataType: "html"
                });
            });
        }
        function checkDistrictLock() {
            $("#districtList .option-lock a").bind("click", function () {
                //发送AJAX请求 设置县级开关
                $.ajax({
                    type: "post",
                    url: "../../tools/admin_ajax.ashx?action=set_district_lock",
                    data: { district_id: $($(this).next()).attr("id") },
                    dataType: "html"
                });
            });
        }
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a> <a href="../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow"></i><span>配送范围</span>
    </div>
    <div class="line10">
    </div>
    <!--/导航栏-->
    <!--内容-->
    <div class="content-tab-wrap">
        <div id="floatHead" class="content-tab">
            <div class="content-tab-ul-wrap">
                <ul>
                    <li><a href="javascript:;" onclick="tabs(this);">设置配送范围</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="tab-content" style="display:block;">
        <div class="distrbution-list">
            <ul id="provinceList" runat="server">
            <li class="distrbution-title">省/直辖市</li>
            </ul>
            <ul id="cityList">
            <li class="distrbution-title">地级市</li>
            </ul>
            <ul id="districtList">
            <li class="distrbution-title">市/县辖市</li>
            </ul>
        </div>
    </div>
    <!--/内容-->
    <!--工具栏-->
    <div class="page-footer">
        <div class="btn-list">
            <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
        </div>
        <div class="clear">
        </div>
    </div>
    <!--/工具栏-->
    </form>
</body>
</html>
