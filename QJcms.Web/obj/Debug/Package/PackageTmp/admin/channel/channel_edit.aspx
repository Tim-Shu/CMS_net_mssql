<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="channel_edit.aspx.cs" Inherits="QJcms.Web.admin.channel.channel_edit" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑频道信息</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=mac"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <script type="text/javascript" src="../js/pinyin.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();
            //添加按钮(点击绑定)
            $("#itemAddButton").click(function () {
                showChannelDialog();
            });
            $("#cbIsComment").click(function () {
                CommentNameshow(this);
            });
            CommentNameshow($("#cbIsComment"));
            $("#txtName").focus();
        });

        function CommentNameshow(obj) {
            if ($(obj).prop("checked") == true) {
                $("#dlCommentName").show();
            }
            else {
                $("#dlCommentName").hide();
            }
        }
        //创建窗口
        function showChannelDialog(obj) {
            var objNum = arguments.length;
            var m = $.dialog({
                id: 'dialogChannel',
                lock: true,
                max: false,
                min: false,
                title: "URL配置信息",
                content: 'url:dialog/dialog_channel.aspx',
                width: 750
            });
            //检查是否修改状态
            if (objNum == 1) {
                m.data = obj;
            }
        }

        //删除一行
        function delItemTr(obj) {
            $.dialog.confirm("您确定要删除这个页面吗？", function () {
                $(obj).parent().parent().remove(); //删除节点
            });
        }
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
        <a href="channel_list.aspx" class="back"><i></i><span>返回列表页</span></a> <a href="../center.aspx" class="home"><i></i><span>首页</span></a> <i class="arrow"></i><a href="channel_list.aspx"><span>频道列表</span></a> <i class="arrow"></i><span>编辑频道</span>
    </div>
    <div class="line10">
    </div>
    <!--/导航栏-->
    <!--内容-->
    <div class="content-tab-wrap">
        <div id="floatHead" class="content-tab">
            <div class="content-tab-ul-wrap">
                <ul>
                    <li><a href="javascript:;" onclick="tabs(this);">频道基本信息</a></li>
                    <li><a href="javascript:;" onclick="tabs(this);">功能权限配置</a></li>
                    <li><a href="javascript:;" onclick="tabs(this);">类别权限配置</a></li>
                    <li><a href="javascript:;" onclick="tabs(this);">内容权限配置</a></li>
                    <li><a href="javascript:;" onclick="tabs(this);">上传配置</a></li>
                    <li><a href="javascript:;" onclick="tabs(this);">URL配置信息</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="tab-content">
        <dl>
            <dt>标题</dt>
            <dd>
                <asp:TextBox ID="txtTitle" runat="server" CssClass="input normal" datatype="*2-100" sucmsg=" "></asp:TextBox>
                <span class="Validform_checktip">*标题备注，允许中文。</span></dd>
        </dl>
        <dl>
            <dt>字段名称</dt>
            <dd>
                <asp:TextBox ID="txtName" runat="server" CssClass="input normal" datatype="/^[a-zA-Z0-9\-\_]{2,50}$/" errormsg="请填写正确的名称！" sucmsg=" "></asp:TextBox>
                <span class="Validform_checktip">*频道名称，只允许使用英文、数字或下划线。</span>
            </dd>
        </dl>
        <dl>
            <dt>所属分类</dt>
            <dd>
                <div class="rule-single-select">
                    <asp:DropDownList ID="ddlCategoryId" runat="server" datatype="*" errormsg="请选择所属分类！" sucmsg=" ">
                    </asp:DropDownList>
                </div>
            </dd>
        </dl>
        <dl>
            <dt>内容别名</dt>
            <dd>
                <asp:TextBox ID="txtContentName" runat="server" Text="内容管理" CssClass="input normal" datatype="*2-100" sucmsg=" "></asp:TextBox>
                <span class="Validform_checktip">*内容管理显示别名 默认"内容管理"。</span></dd>
        </dl>
        <dl>
            <dt>类别别名</dt>
            <dd>
                <asp:TextBox ID="txtCagegoryName" runat="server" Text="栏目类别" CssClass="input normal" datatype="*2-100" sucmsg=" "></asp:TextBox>
                <span class="Validform_checktip">*栏目类别显示别名 默认"栏目类别"。</span></dd>
        </dl>
        <dl>
            <dt>分页数量</dt>
            <dd>
                <asp:TextBox ID="txtPageSize" runat="server" CssClass="input small" datatype="n" sucmsg=" ">10</asp:TextBox>
                <span class="Validform_checktip">*列表页每页显示数据数量</span>
            </dd>
        </dl>
        <dl>
            <dt>分类层深</dt>
            <dd>
                <asp:TextBox ID="txtDeepLayer" runat="server" CssClass="input small" datatype="n" sucmsg=" ">0</asp:TextBox>
                <span class="Validform_checktip">*频道下分类的最大数量 0为不分类</span>
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
            <dt>选择字段</dt>
            <dd>
                <div class="rule-multi-porp">
                    <asp:CheckBoxList ID="cblAttributeField" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    </asp:CheckBoxList>
                </div>
            </dd>
        </dl>
    </div>
    <div class="tab-content">
        <dl>
            <dt>开启频道封面</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="cbIsChannelImg" runat="server" />
                </div>
                <span class="Validform_checktip">*开启封面图片后可上传单张封面图片</span>
            </dd>
        </dl>
        <dl>
            <dt>开启频道描述</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="cbIsChannelDesc" runat="server" />
                </div>
                <span class="Validform_checktip">*开启频道描述后可编辑频道详细描述</span>
            </dd>
        </dl>
        <dl>
            <dt>开启封面图片</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="cbIsCover" runat="server" />
                </div>
                <span class="Validform_checktip">*开启封面图片后可上传单张封面图片</span>
            </dd>
        </dl>
        <dl>
            <dt>开启相册功能</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="cbIsAlbums" runat="server" />
                </div>
                <span class="Validform_checktip">*开启相册功能后可上传多张图片</span>
            </dd>
        </dl>
        <dl>
            <dt>开启附件功能</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="cbIsAttach" runat="server" />
                </div>
                <span class="Validform_checktip">*开启附件功能后可上传多个附件。</span>
            </dd>
        </dl>
        <dl>
            <dt>开启内容评论</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="cbIsComment" runat="server" />
                </div>
                <span class="Validform_checktip">*开启内容评论后可对该频道的详细内容进行评论。</span>
            </dd>
        </dl>
        <dl id="dlCommentName" style="display: none;">
            <dt>评论别名</dt>
            <dd>
                <asp:TextBox ID="txtCommentName" runat="server" Text="评论管理" CssClass="input normal" datatype="*2-100" sucmsg=" "></asp:TextBox>
                <span class="Validform_checktip">*评论管理显示别名 默认"评论管理"。</span></dd>
        </dl>
        <dl>
            <dt>开放客修改</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="cbIsCustomer" runat="server" Checked="true" />
                </div>
                <span class="Validform_checktip">*开放客修改后可对该频道的类别及详细内容添加或删除。</span>
            </dd>
        </dl>
        <dl runat="server" id="dlIsGroupPrice">
            <dt>开启会员价格</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="cbIsGroupPrice" runat="server" />
                </div>
                <span class="Validform_checktip">*只有当会员功能开启状态下才生效</span>
            </dd>
        </dl>
        <dl>
            <dt>推荐类型</dt>
            <dd>
                <div class="rule-multi-checkbox">
                    <asp:CheckBoxList ID="cblRecomItem" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="isMsg">允许评论</asp:ListItem>
                        <asp:ListItem Value="isTop">置顶</asp:ListItem>
                        <asp:ListItem Value="isRed">推荐</asp:ListItem>
                        <asp:ListItem Value="isHot">热门</asp:ListItem>
                        <asp:ListItem Value="isSlide">幻灯片</asp:ListItem>
                    </asp:CheckBoxList>
                </div>
            </dd>
        </dl>
    </div>
    <div class="tab-content">
        <dl>
            <dt>类别别名访问</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="cbCategoryCall" runat="server" />
                </div>
                <span class="Validform_checktip">*关闭后调用别名失效</span>
            </dd>
        </dl>
        <dl>
            <dt>开启跳转链接</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="cbCategoryLink" runat="server" />
                </div>
                <span class="Validform_checktip">*开启后访问时跳转到所指向链接</span>
            </dd>
        </dl>
        <dl>
            <dt>开启类别介绍</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="cbCategoryInto" runat="server" />
                </div>
                <span class="Validform_checktip">*开启后可以添加类别介绍描述</span>
            </dd>
        </dl>
        <dl>
            <dt>开启类别优化</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="cbCategorySeo" runat="server" />
                </div>
                <span class="Validform_checktip">*开启后可以添加类别介绍描述</span>
            </dd>
        </dl>
        <dl>
            <dt>类别图片</dt>
            <dd>
                <div class="rule-multi-radio">
                    <asp:RadioButtonList ID="rblCategoryPhoto" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="0" Selected="True">关闭</asp:ListItem>
                        <asp:ListItem Value="1">单图</asp:ListItem>
                        <asp:ListItem Value="2">多图</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <span class="Validform_checktip">*选择对应的图片上传组件</span>
            </dd>
        </dl>
    </div>
    <div class="tab-content">
        <dl>
            <dt>内容别名访问</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="cbContentCall" runat="server" />
                </div>
                <span class="Validform_checktip">*关闭后调用别名失效</span>
            </dd>
        </dl>
        <dl>
            <dt>开启跳转链接</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="cbContentLink" runat="server" />
                </div>
                <span class="Validform_checktip">*开启后访问时跳转到所指向链接</span>
            </dd>
        </dl>
        <dl>
            <dt>开启摘要简介</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="cbContentInto" runat="server" />
                </div>
                <span class="Validform_checktip">*开启后可以添加类别介绍描述</span>
            </dd>
        </dl>
        <dl>
            <dt>开启内容优化</dt>
            <dd>
                <div class="rule-single-checkbox">
                    <asp:CheckBox ID="cbContentSeo" runat="server" />
                </div>
                <span class="Validform_checktip">*开启后可以添加类别介绍描述</span>
            </dd>
        </dl>
    </div>
    <div class="tab-content">
        <dl>
            <dt>附件上传大小</dt>
            <dd>
                <asp:TextBox ID="txtAttachSize" runat="server" Text="0" CssClass="input small" datatype="n" sucmsg=" " />
                KB <span class="Validform_checktip">*超过设定的文件大小不予上传，0全局配置 1不限制</span>
            </dd>
        </dl>
        <dl>
            <dt>图片上传大小</dt>
            <dd>
                <asp:TextBox ID="txtImgSize" runat="server" Text="0" CssClass="input small" datatype="n" sucmsg=" " />
                KB <span class="Validform_checktip">*超过设定的图片大小不予上传，0全局配置 1不限制</span>
            </dd>
        </dl>
        <dl>
            <dt>图片最大尺寸</dt>
            <dd>
                <asp:TextBox ID="txtImgMaxHeight" runat="server" Text="0" CssClass="input small" datatype="n" sucmsg=" " />
                ×
                <asp:TextBox ID="txtImgMaxWidth" runat="server" Text="0" CssClass="input small" datatype="n" sucmsg=" " />
                px <span class="Validform_checktip">*左边高度，右边宽度，超出自动裁剪，0全局配置 1不限制</span>
            </dd>
        </dl>
        <dl>
            <dt>生成缩略图尺寸</dt>
            <dd>
                <asp:TextBox ID="txtThumbnailHeight" runat="server" Text="0" CssClass="input small" datatype="n" sucmsg=" " />
                ×
                <asp:TextBox ID="txtThumbnailWidth" runat="server" Text="0" CssClass="input small" datatype="n" sucmsg=" " />
                px <span class="Validform_checktip">*左边高度，右边宽度，0为不生成缩略图</span>
            </dd>
        </dl>
        <dl>
            <dt>超出操作</dt>
            <dd>
                <div class="rule-multi-radio">
                    <asp:RadioButtonList ID="rblBeyond" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="1" Selected="True">裁剪</asp:ListItem>
                        <asp:ListItem Value="2">压缩</asp:ListItem>
                        <asp:ListItem Value="3">等比宽</asp:ListItem>
                        <asp:ListItem Value="4">等比高</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <span class="Validform_checktip">*该功能暂时无效</span>
            </dd>
        </dl>
    </div>
    <div class="tab-content">
        <dl>
            <dt>URL生成配置</dt>
            <dd>
                <a id="itemAddButton" class="icon-btn add"><i></i><span>添加页面</span></a></dd>
        </dl>
        <dl>
            <dt></dt>
            <dd>
                <table border="0" cellspacing="0" cellpadding="0" class="border-table" width="98%">
                    <thead>
                        <tr>
                            <th width="12%">
                                类型
                            </th>
                            <th width="20%">
                                调用名称
                            </th>
                            <th width="28%">
                                生成文件名
                            </th>
                            <th width="28%">
                                模板文件名
                            </th>
                            <th width="10%">
                                操作
                            </th>
                        </tr>
                    </thead>
                    <tbody id="item_box">
                        <asp:Repeater ID="rptList" runat="server">
                            <ItemTemplate>
                                <tr class="td_c">
                                    <td>
                                        <input type="hidden" name="item_rewrite" value="<%#Eval("url_rewrite_str") %>" />
                                        <input type="hidden" name="item_type" value="<%#Eval("type")%>" />
                                        <span class="item_type">
                                            <%#GetPageTypeTxt(Eval("type").ToString())%></span>
                                    </td>
                                    <td>
                                        <input type="hidden" name="old_item_name" value="<%#Eval("name")%>" />
                                        <input type="hidden" name="item_name" value="<%#Eval("name")%>" />
                                        <span class="item_name">
                                            <%#Eval("name")%></span>
                                    </td>
                                    <td>
                                        <input type="hidden" name="item_page" value="<%#Eval("page")%>" />
                                        <span class="item_page">
                                            <%#Eval("page")%></span>
                                    </td>
                                    <td>
                                        <input type="hidden" name="item_templet" value="<%#Eval("templet")%>" />
                                        <span class="item_templet">
                                            <%#Eval("templet")%></span>
                                    </td>
                                    <td>
                                        <a title="编辑" class="img-btn edit operator" onclick="showChannelDialog(this);">编辑</a> <a title="删除" class="img-btn del operator" onclick="delItemTr(this);">删除</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
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
