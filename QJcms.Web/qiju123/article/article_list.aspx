<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="article_list.aspx.cs" Inherits="QJcms.Web.admin.article.article_list" %>

<%@ Import Namespace="QJcms.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>内容列表</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/jquery.lazyload.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=mac"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            imgLayout();
            $(window).resize(function () {
                imgLayout();
            });
            //图片延迟加载
            $(".pic img").lazyload({ load: AutoResizeImage, effect: "fadeIn" });
            //点击图片链接
            $(".pic img").click(function () {
                //$.dialog({ lock: true, title: "查看大图", content: "<img src=\"" + $(this).attr("src") + "\" />", padding: 0 });
                var linkUrl = $(this).parent().parent().find(".foot a").attr("href");
                if (linkUrl != "") {
                    location.href = linkUrl; //跳转到修改页面
                }
            });
            //频道封面编辑按钮
            $(".channel-img a").click(function () {
                var dialog = $.dialog({
                    title: '编辑栏目封面',
                    content: 'url:dialog/dialog_channel_img.aspx?id=<%=channel_id %>',
                    min: false,
                    max: false,
                    lock: true,
                    width: 650//,
                    //height: 500
                });
            });
            //频道描述编辑按钮
            $(".channel-desc a").click(function () {
                var dialog = $.dialog({
                    title: '编辑栏目描述',
                    content: 'url:dialog/dialog_channel_detail.aspx?id=<%=channel_id %>',
                    min: false,
                    max: false,
                    lock: true,
                    width: 850,
                    height: 220
                });
            });
        });
        //排列图文列表
        function imgLayout() {
            var imgWidth = $(".imglist").width();
            var lineCount = Math.floor(imgWidth / 222);
            var lineNum = imgWidth % 222 / (lineCount - 1);
            $(".imglist ul").width(imgWidth + Math.ceil(lineNum));
            $(".imglist ul li").css("margin-right", parseFloat(lineNum));
        }
        //等比例缩放图片大小
        function AutoResizeImage(e, s) {
            var img = new Image();
            img.src = $(this).attr("src")
            var w = img.width;
            var h = img.height;
            var wRatio = w / h;
            if ((220 / wRatio) >= 165) {
                $(this).width(220); $(this).height(220 / wRatio);
            } else {
                $(this).width(165 * wRatio); $(this).height(165);
            }
        }
    </script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <!--导航栏-->
    <div class="location">
        <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a> <a href="../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow"></i><span>内容列表</span>
    </div>
    <!--/导航栏-->
    <!--工具栏-->
    <div class="toolbar-wrap">
        <div id="floatHead" class="toolbar">
            <div class="l-list">
                <ul class="icon-list">
                  <li runat="server" id="tool_multi_add"><a class="add" href="article_multi_add.aspx?action=<%=QJEnums.ActionEnum.Add %>&channel_id=<%=this.channel_id %>"><i></i><span>批量上传</span></a></li>
                    <li runat="server" id="tool_add"><a class="add" href="article_edit.aspx?action=<%=QJEnums.ActionEnum.Add %>&channel_id=<%=this.channel_id %>"><i></i><span>新增</span></a></li>
                    <li>
                        <asp:LinkButton ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click"><i></i><span>保存</span></asp:LinkButton></li>
                    <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
                    <li runat="server" id="tool_del">
                        <asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" OnClick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
                </ul>
                <div class="menu-list">
                    <div class="rule-single-select" runat="server" id="divCategory">
                        <asp:DropDownList ID="ddlCategoryId" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategoryId_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="rule-single-select" runat="server" id="divProperty">
                        <asp:DropDownList ID="ddlProperty" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProperty_SelectedIndexChanged">
                            <asp:ListItem Value="" Selected="True">所有属性</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="tool-channel-edit channel-img" runat="server" id="divChannelImg"><a href="javascript:;"><i></i><span>栏目封面</span></a></div>
                    <div class="tool-channel-edit channel-desc" runat="server" id="divChannelDesc"><a href="javascript:;"><i></i><span>栏目描述</span></a></div>
                </div>
            </div>
            <div class="r-list">
                <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
                <asp:LinkButton ID="lbtnViewImg" runat="server" CssClass="img-view" OnClick="lbtnViewImg_Click" ToolTip="图像列表视图" />
                <asp:LinkButton ID="lbtnViewTxt" runat="server" CssClass="txt-view" OnClick="lbtnViewTxt_Click" ToolTip="文字列表视图" />
            </div>
        </div>
    </div>
    <!--/工具栏-->
    <!--文字列表-->
    <asp:Repeater ID="rptList1" runat="server" OnItemCommand="rptList_ItemCommand" OnItemDataBound="rptList_ItemDataBound">
        <HeaderTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                <tr>
                    <th width="6%">
                        选择
                    </th>
                    <%if (chanModel.is_content_call == 1)
                      {%>
                    <th align="left" width="12%">
                        调用名称
                    </th>
                    <%} %>
                    <th align="left">
                        标题
                    </th>
                    <%if (chanModel.deep_layer > 0)
                      { %>
                    <th align="left" width="12%">
                        所属类别
                    </th>
                    <%} %>
                    <th align="left" width="16%">
                        发布时间
                    </th>
                    <th align="left" width="65">
                        排序
                    </th>
                    <%if (chanModel.recom_type.Length > 0)
                      {%>
                    <th align="left" width="110">
                        属性
                    </th>
                    <%} %>
                    <th width="8%">
                        操作
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center">
                    <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Enabled='<%#bool.Parse((Convert.ToInt32(Eval("is_sys"))==0 ).ToString())%>' Style="vertical-align: middle;" />
                    <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                </td>
                <%if (chanModel.is_content_call == 1)
                  {%>
                <td>
                    <%#Eval("call_index")%>
                </td>
                <%} %>
                <td>
                    <a href="article_edit.aspx?action=<%#QJEnums.ActionEnum.Edit %>&channel_id=<%#this.channel_id %>&id=<%#Eval("id")%>">
                        <%#Eval("title")%></a>
                </td>
                <%if (chanModel.deep_layer > 0)
                  { %>
                <td>
                    <%#new QJcms.BLL.article_category().GetTitle(Convert.ToInt32(Eval("category_id")))%>
                </td>
                <%} %>
                <td>
                    <%#string.Format("{0:g}",Eval("add_time"))%>
                </td>
                <td>
                    <asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("sort_id")%>' CssClass="sort" onkeydown="return checkNumber(event);" />
                </td>
                <%if (chanModel.recom_type.Length > 0)
                  {%>
                <td>
                    <div class="btn-tools">
                        <asp:LinkButton ID="lbtnIsMsg" CommandName="lbtnIsMsg" runat="server" CssClass='<%# Convert.ToInt32(Eval("is_msg")) == 1 ? "msg selected" : "msg"%>' ToolTip='<%# Convert.ToInt32(Eval("is_msg")) == 1 ? "取消评论" : "设置评论"%>' Visible="false" />
                        <asp:LinkButton ID="lbtnIsTop" CommandName="lbtnIsTop" runat="server" CssClass='<%# Convert.ToInt32(Eval("is_top")) == 1 ? "top selected" : "top"%>' ToolTip='<%# Convert.ToInt32(Eval("is_top")) == 1 ? "取消置顶" : "设置置顶"%>' Visible="false" />
                        <asp:LinkButton ID="lbtnIsRed" CommandName="lbtnIsRed" runat="server" CssClass='<%# Convert.ToInt32(Eval("is_red")) == 1 ? "red selected" : "red"%>' ToolTip='<%# Convert.ToInt32(Eval("is_red")) == 1 ? "取消推荐" : "设置推荐"%>' Visible="false" />
                        <asp:LinkButton ID="lbtnIsHot" CommandName="lbtnIsHot" runat="server" CssClass='<%# Convert.ToInt32(Eval("is_hot")) == 1 ? "hot selected" : "hot"%>' ToolTip='<%# Convert.ToInt32(Eval("is_hot")) == 1 ? "取消热门" : "设置热门"%>' Visible="false" />
                        <asp:LinkButton ID="lbtnIsSlide" CommandName="lbtnIsSlide" runat="server" CssClass='<%# Convert.ToInt32(Eval("is_slide")) == 1 ? "pic selected" : "pic"%>' ToolTip='<%# Convert.ToInt32(Eval("is_slide")) == 1 ? "取消幻灯片" : "设置幻灯片"%>' Visible="false" />
                    </div>
                </td>
                <%} %>
                <td align="center">
                    <a href="article_edit.aspx?action=<%#QJEnums.ActionEnum.Edit %>&channel_id=<%#this.channel_id %>&id=<%#Eval("id")%>">修改</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <%#rptList1.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无记录</td></tr>" : ""%>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <!--/文字列表-->
    <!--图片列表-->
    <asp:Repeater ID="rptList2" runat="server" OnItemCommand="rptList_ItemCommand" OnItemDataBound="rptList_ItemDataBound">
        <HeaderTemplate>
            <div class="imglist">
                <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <div class="details<%#Eval("img_url").ToString() != "" ? "" : " nopic"%>">
                    <div class="check">
                        <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" /><asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
                    </div>
                    <%#Eval("img_url").ToString() != "" ? "<div class=\"pic\"><img src=\"../skin/default/loadimg.gif\" data-original=\"" + Eval("img_url") + "\" /></div><i class=\"absbg\"></i>" : ""%>
                    <h1>
                        <span><a href="article_edit.aspx?action=<%#QJEnums.ActionEnum.Edit %>&channel_id=<%#this.channel_id %>&id=<%#Eval("id")%>">
                            <%#Eval("title")%></a></span></h1>
                    <div class="remark">
                        <%#Eval("zhaiyao").ToString() == "" ? "暂无内容摘要说明..." : Eval("zhaiyao").ToString()%>
                    </div>
                    <div class="tools">
                        <asp:LinkButton ID="lbtnIsMsg" CommandName="lbtnIsMsg" runat="server" CssClass='<%# Convert.ToInt32(Eval("is_msg")) == 1 ? "msg selected" : "msg"%>' ToolTip='<%# Convert.ToInt32(Eval("is_msg")) == 1 ? "取消评论" : "设置评论"%>' Visible="false" />
                        <asp:LinkButton ID="lbtnIsTop" CommandName="lbtnIsTop" runat="server" CssClass='<%# Convert.ToInt32(Eval("is_top")) == 1 ? "top selected" : "top"%>' ToolTip='<%# Convert.ToInt32(Eval("is_top")) == 1 ? "取消置顶" : "设置置顶"%>' Visible="false" />
                        <asp:LinkButton ID="lbtnIsRed" CommandName="lbtnIsRed" runat="server" CssClass='<%# Convert.ToInt32(Eval("is_red")) == 1 ? "red selected" : "red"%>' ToolTip='<%# Convert.ToInt32(Eval("is_red")) == 1 ? "取消推荐" : "设置推荐"%>' Visible="false" />
                        <asp:LinkButton ID="lbtnIsHot" CommandName="lbtnIsHot" runat="server" CssClass='<%# Convert.ToInt32(Eval("is_hot")) == 1 ? "hot selected" : "hot"%>' ToolTip='<%# Convert.ToInt32(Eval("is_hot")) == 1 ? "取消热门" : "设置热门"%>' Visible="false" />
                        <asp:LinkButton ID="lbtnIsSlide" CommandName="lbtnIsSlide" runat="server" CssClass='<%# Convert.ToInt32(Eval("is_slide")) == 1 ? "pic selected" : "pic"%>' ToolTip='<%# Convert.ToInt32(Eval("is_slide")) == 1 ? "取消幻灯片" : "设置幻灯片"%>' Visible="false" />
                        <asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("sort_id")%>' CssClass="sort" onkeypress="return (/[\d]/.test(String.fromCharCode(event.keyCode)));" />
                    </div>
                    <div class="foot">
                        <p class="time">
                            <%#string.Format("{0:yyyy-MM-dd HH:mm:ss}", Eval("add_time"))%></p>
                        <a href="article_edit.aspx?action=<%#QJEnums.ActionEnum.Edit %>&channel_id=<%#this.channel_id %>&id=<%#Eval("id")%>" title="编辑" class="edit">编辑</a>
                    </div>
                </div>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            <%#rptList2.Items.Count == 0 ? "<div align=\"center\" style=\"font-size:12px;line-height:30px;color:#666;\">暂无记录</div>" : ""%>
            </ul> </div>
        </FooterTemplate>
    </asp:Repeater>
    <!--/图片列表-->
    <!--内容底部-->
    <div class="line20">
    </div>
    <div class="pagelist">
        <div class="l-btns">
            <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
        </div>
        <div id="PageContent" runat="server" class="default">
        </div>
    </div>
    <!--/内容底部-->
    </form>
</body>
</html>
