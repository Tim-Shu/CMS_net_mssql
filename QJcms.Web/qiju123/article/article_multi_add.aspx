<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="article_multi_add.aspx.cs" Inherits="QJcms.Web.admin.article.article_multi_add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <title>批量上传</title>
  <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
  <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
  <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=mac"></script>
  <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
  <script type="text/javascript" src="../../scripts/swfupload/swfupload.queue.js"></script>
  <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
  <script type="text/javascript" src="../js/layout.js"></script>
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
      $(".upload-album").each(function () {
        $(this).InitSWFUpload({ btntext: "批量上传", btnwidth: 66, single: false, water: isWater, thumbnail: isThumbnail, filesize: fileSize, channelid: "<%=channel_id %>", sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf", filetypes: "*.jpg;*.jpge;*.png;*.gif;" });
          });
      //设置封面图片的样式
      $(".photo-list ul li .img-box img").each(function () {
        if ($(this).attr("src") == $("#hidFocusPhoto").val()) {
          $(this).parent().addClass("selected");
        }
      });
      $("input[name='rblManner'][checked]").change(function () {
        if ($(this).val() != "0") {
          $("#titleDL").hide(); $("#startDL").hide();
        }
        else {
          $("#titleDL").show(); $("#startDL").show();
        }
      })
    });
  </script>
</head>
<body class="mainbody">
  <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
      <a href="article_list.aspx?channel_id=<%=this.channel_id %>" class="back"><i></i><span>返回列表页</span></a> <a href="../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow"></i><a href="article_list.aspx?channel_id=<%=this.channel_id %>"><span>内容管理</span></a> <i class="arrow"></i><span>编辑信息</span>
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
          </ul>
        </div>
      </div>
    </div>
    <div class="tab-content">
      <dl runat="server" id="dlCategory">
        <dt>所属类别</dt>
        <dd>
          <div class="rule-single-select">
            <asp:DropDownList ID="ddlCategoryId" runat="server" datatype="*" sucmsg=" ">
            </asp:DropDownList>
          </div>
        </dd>
      </dl>
      <dl>
        <dt>命名方式</dt>
        <dd>
          <div class="rule-multi-radio">
            <asp:RadioButtonList ID="rblManner" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
              <asp:ListItem Value="0" Selected="True">自动编号</asp:ListItem>              
              <asp:ListItem Value="1">文件名</asp:ListItem>
            </asp:RadioButtonList>
          </div>
        </dd>
      </dl>
      <dl id="titleDL">
        <dt>命名规则</dt>
        <dd>
          <asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" Text="###" datatype="*2-100" sucmsg=" " />
          <span class="Validform_checktip">以#代替数字序列，例：### 代表三位数字。<b class="red">注：#符号为通配符，标题文字中不得出现#符号</b></span>
        </dd>
      </dl>
      <dl id="startDL">
        <dt>起始数字</dt>
        <dd>
          <asp:TextBox ID="txtStart" runat="server" CssClass="input small" datatype="n" sucmsg=" ">1</asp:TextBox>
          <span class="Validform_checktip">*数字</span>
        </dd>
      </dl>
      <dl>
        <dt>图片上传</dt>
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
    <!--/内容-->
    <!--工具栏-->
    <div class="page-footer">
      <div class="btn-list">
        <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
        <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
      </div>
      <div class="clear">
      </div>
    </div>
    <!--/工具栏-->
  </form>
</body>
</html>
