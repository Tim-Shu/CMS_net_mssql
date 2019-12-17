<%@ Page Language="C#" AutoEventWireup="true" Inherits="QJcms.Web.UI.Page.article_list" ValidateRequest="false" %>
<%@ Import namespace="System.Collections.Generic" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="QJcms.Common" %>

<script runat="server">
override protected void OnInit(EventArgs e)
{

	/* 
		This page was created by QJcms Template Engine at 2019/5/7 15:24:30.
		本页面代码由QJcms模板引擎生成于 2019/5/7 15:24:30. 
	*/

	base.OnInit(e);
	StringBuilder templateBuilder = new StringBuilder(220000);
	const string channel_name = "danye";
	
	templateBuilder.Append("<!doctype html>\r\n<html>\r\n<head>\r\n    ");

	templateBuilder.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1\" />\r\n<title>上海迎匠热能设备有限公司</title>\r\n<script src=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/js/jquery.js\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/js/index.js\"></");
	templateBuilder.Append("script>\r\n<link href=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/css/style.css\" rel=\"stylesheet\" />\r\n<link href=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/css/css.css\" rel=\"stylesheet\" />\r\n<link href=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/css/swiper.min.css\" rel=\"stylesheet\" />\r\n<link href=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/bootstrap/css/bootstrap.min.css\" rel=\"stylesheet\" />\r\n<link href=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/css/stylesCode.css\" rel=\"stylesheet\" />\r\n<script src=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/js/wow.min.js\"></");
	templateBuilder.Append("script>\r\n<link href=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/css/animate.min.css\" rel=\"stylesheet\" />\r\n<script>\r\n    if (!(/msie [6|7|8|9]/i.test(navigator.userAgent))) {\r\n        new WOW().init();\r\n    };\r\n</");
	templateBuilder.Append("script>");


	templateBuilder.Append("\r\n\r\n</head>\r\n<body>\r\n\r\n\r\n    <div class=\"cpzs clearfix\">\r\n        <div class=\"wrap\">\r\n            <div class=\"pr clearfix hidden-lg hidden-md\">\r\n                <div class=\"od\">\r\n                    <div class=\"od1\">Online message</div>\r\n                    <div class=\"od2\">在线留言<span></span></div>\r\n                </div>\r\n                <div class=\"ct\">当前页：  <a href='");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("'>首页</a>  >  在线留言</div>\r\n            </div>\r\n            <div class=\"cpzs_left\">\r\n                <!--产品下拉开始-->\r\n                <script type=\"text/javascript\">\r\n                    $(document).ready(function () {\r\n                        $(\".div2\").click(function () {\r\n                            $(this).next(\"div\").slideToggle(\"slow\").siblings(\".div3:visible\").slideUp(\"slow\");\r\n                        });\r\n                    });\r\n                </");
	templateBuilder.Append("script>\r\n                <div class=\"left\">\r\n                    <div class=\"div1\">\r\n                        <div class=\"div2\"><div class=\"jbsz\"></div>在线留言<span class=\"visible-lg visible-md\">Successful cases</span></div>\r\n                        <div class=\"div3\">\r\n                            <ul>\r\n                                <li><a href='");
	templateBuilder.Append(linkurl("message"));

	templateBuilder.Append("'>在线留言</a></li>\r\n                            </ul>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                <!--产品下拉结束-->\r\n                ");

	templateBuilder.Append("<div class=\"ctnlb\">\r\n    <div class=\"ctnltit1\">联系我们</div>\r\n    <div class=\"clb\">\r\n        <div class=\"clbtit\">上海迎匠热能设备有限公司</div>\r\n        <div class=\"clbtxt\">\r\n            ");
	templateBuilder.Append(get_article_content("lxwm").ToString());

	templateBuilder.Append("\r\n        </div>\r\n    </div>\r\n</div>");


	templateBuilder.Append("\r\n            </div>\r\n            <div class=\"cpzs_right clearfix\">\r\n                <div class=\"pr clearfix visible-lg visible-md\">\r\n                    <div class=\"od\">\r\n                        <div class=\"od1\">Online message</div>\r\n                        <div class=\"od2\">在线留言<span></span></div>\r\n                    </div>\r\n                    <div class=\"ct\">当前页：  <a href='");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("'>首页</a>  >  在线留言</div>\r\n                </div>\r\n                <div class=\"zxly clearfix\">\r\n                    <form id=\"feedback_forms\" name=\"feedback_forms\" url=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/feedback_ajax.ashx?action=add\" class=\"\">\r\n                        <ul>\r\n                            <li>\r\n                                <label>您的姓名：</label>\r\n                                <input type=\"text\" id=\"name\" name=\"name\" />\r\n                            </li>\r\n                            <li>\r\n                                <label>您的邮箱：</label>\r\n                                <input type=\"text\" id=\"mail\" name=\"mail\" />\r\n                            </li>\r\n                            <li>\r\n                                <label>您的手机：</label>\r\n                                <input type=\"text\" id=\"tel\" name=\"tel\" />\r\n                            </li>\r\n                            <li>\r\n                                <label>您的地址：</label>\r\n                                <input type=\"text\" id=\"qq\" name=\"qq\" />\r\n                            </li>\r\n                            <li>\r\n                                <label style=\"height:200px;\">留言板：</label>\r\n                                <textarea id=\"msg\" name=\"msg\"></textarea>\r\n                                <button type=\"submit\">提交</button>\r\n                                <button type=\"reset\">重置</button>\r\n                            </li>\r\n                        </ul>\r\n                    </form>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <script src=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/js/bases.js\"></");
	templateBuilder.Append("script>\r\n    <script src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/lhgdialog/lhgdialog.js?skin=idialog\" type=\"text/javascript\"></");
	templateBuilder.Append("script>\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/jquery.form.min.js\"></");
	templateBuilder.Append("script>\r\n    <script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/Validform_v5.3.2_min.js\"></");
	templateBuilder.Append("script>\r\n    <script type=\"text/javascript\">\r\n        $(function () {\r\n            //初始化发表评论表单\r\n            AjaxInitForm('feedback_forms', 'btnSubmit', 1);\r\n        });\r\n    </");
	templateBuilder.Append("script>\r\n</body>\r\n</html>");
	Response.Write(templateBuilder.ToString());
}
</script>
