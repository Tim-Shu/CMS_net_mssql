<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="search_keyword_list.aspx.cs" Inherits="QJcms.Web.admin.plugin.search_keyword_list" %>
<%@ Import namespace="QJcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>搜索关键词</title>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<link type="text/css" rel="stylesheet" href="../../../css/pagination.css" />
<script type="text/javascript" src="../../../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>系统管理</span>
  <i class="arrow"></i>
  <span>搜索关键词</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div class="toolbar-wrap">
  <div id="floatHead" class="toolbar">
    <div class="l-list">
      <ul class="icon-list">
        <li runat="server" id="tool_add"><a class="add" href="search_keyword_edit.aspx?action=<%=QJEnums.ActionEnum.Add %>"><i></i><span>新增</span></a></li>
        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
        <li runat="server" id="tool_edit"><asp:LinkButton ID="btnSave" runat="server" CssClass="save" onclick="btnSave_Click"><i></i><span>保存</span></asp:LinkButton></li>
        <li runat="server" id="tool_del"><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
      </ul>
    </div>
    <div class="r-list">
      <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
      <asp:LinkButton ID="btnSearch" runat="server" CssClass="btn-search" onclick="btnSearch_Click">查询</asp:LinkButton>
    </div>
  </div>
</div>
<!--/工具栏-->

<!--列表-->
<asp:Repeater ID="rptList" runat="server" onitemcommand="rptList_ItemCommand">
<HeaderTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th width="8%">选择</th>
    <th align="left" width="25%">标题</th>
    <th align="left">链接地址</th>
    <th align="left" width="10%">打开窗口</th>
    <th align="left" width="10%">排序</th>
    <th align="left" width="8%">状态</th>
    <th width="10%">操作</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td align="center">
      <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" />
      <asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" />
    </td>
    <td><a href="search_keyword_edit.aspx?action=<%=QJEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>"><%#Eval("title")%></a></td>
    <td><%#Eval("link_url")%></td>
    <td><%#Eval("target")%></td>
    <td><asp:TextBox ID="txtSortId" runat="server" Text='<%#Eval("sort_id")%>' CssClass="sort" onkeydown="return checkNumber(event);" /></td>
    <td>
      <div class="btn-tools">
        <asp:LinkButton ID="lbtnIsLock" CommandName="lbtnIsLock" runat="server" CssClass='<%# Convert.ToInt32(Eval("is_lock")) == 1 ? "lock selected" : "lock"%>' ToolTip='<%# Convert.ToInt32(Eval("is_lock")) == 1 ? "启用" : "停用"%>' />
      </div>
    </td>
    <td align="center"><a href="search_keyword_edit.aspx?action=<%#QJEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>">修改</a></td>
  </tr>
</ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"7\">暂无记录</td></tr>" : ""%>
</table>
</FooterTemplate>
</asp:Repeater>
<!--/列表-->

<!--内容底部-->
<div class="line20"></div>
<div class="pagelist">
  <div class="l-btns">
    <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" ontextchanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
  </div>
  <div id="PageContent" runat="server" class="default"></div>
</div>
<!--/内容底部-->
</form>
</body>
</html>
