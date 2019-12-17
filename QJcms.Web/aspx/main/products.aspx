<%@ Page Language="C#" AutoEventWireup="true" Inherits="QJcms.Web.UI.Page.article_show" ValidateRequest="false" %>
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
	const string channel_name = "product";
	
	templateBuilder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    ");

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


	templateBuilder.Append("\r\n</head>\r\n\r\n<body>\r\n    ");

	templateBuilder.Append("<div class=\"header\">\r\n    <div class=\"wrap\" style=\"position:relative;\">\r\n        <div class=\"logo1\"><img src=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/images/logo1.png\" /></div>\r\n        <div class=\"logo2\"><img src=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/images/logo2.png\" /></div>\r\n        <div class=\"header-right\">\r\n            <div class=\"search\">\r\n                <div class=\"search1\">产品搜索<span><img src=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/images/xx.png\" /></span></div>\r\n                <input type=\"text\" id=\"keywords\" name=\"keywords\" placeholder=\"请输入关键字\" required=\"\" onkeydown=\"if (event.keyCode == 13) { SiteSearch('");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("search.aspx', '#keywords', 'product'); return false };\" />\r\n                <button type=\"submit\" onclick=\"SiteSearch('");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("search.aspx', '#keywords', 'product'); return false\"></button>\r\n            </div>\r\n            <div class=\"tel1\">24小时免费服务热线：<span>");
	templateBuilder.Append(get_article_title(220).ToString());

	templateBuilder.Append("</span></div>\r\n        </div>\r\n        <div class=\"zd\">\r\n        <a href=\"javascript:void(0);\" onclick=\"AddFavorite('我的网站',location.href)\">收藏本站</a>|\r\n        <a href=\"javascript:void(0);\" onclick=\"SetHome(this, 'http://*&&*&&.com');\">设为首页</a></div>\r\n        <div class=\"logo\">\r\n            <span class=\"icon-menu hidden-lg hidden-md\"></span>\r\n            <!--移动端导航-->\r\n            <div class=\"sjdnav sjdnavhide hidden-lg hidden-md\">\r\n                <ul class=\"list-inline\">\r\n                    <li><a href='");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("'>首页</a></li>\r\n                    <li><a href='");
	templateBuilder.Append(linkurl("product"));

	templateBuilder.Append("'>产品总览</a></li>\r\n                    <li><a href='");
	templateBuilder.Append(linkurl("case"));

	templateBuilder.Append("'>工业应用</a></li>\r\n                    <li><a href='");
	templateBuilder.Append(linkurl("reform"));

	templateBuilder.Append("'>节能改造</a></li>\r\n                    <li><a href='");
	templateBuilder.Append(linkurl("boiler",1379));

	templateBuilder.Append("'>低氮锅炉</a></li>\r\n                    <li><a href='");
	templateBuilder.Append(linkurl("service"));

	templateBuilder.Append("'>维保服务</a></li>\r\n                    <li><a href='");
	templateBuilder.Append(linkurl("about"));

	templateBuilder.Append("'>企业简介</a></li>\r\n                    <li><a href='");
	templateBuilder.Append(linkurl("contact"));

	templateBuilder.Append("'>联系我们</a></li>\r\n                </ul>\r\n            </div>\r\n            <!--------------------------->\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"nav\">\r\n    <div class=\"wrap\" style=\"padding:0 2%;\">\r\n        <ul class=\"nul\">\r\n            <li class=\"nli\"><a href='");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("'>首页</a></li>\r\n            <li class=\"nli\"><a href='");
	templateBuilder.Append(linkurl("product"));

	templateBuilder.Append("'>产品总览</a></li>\r\n            <li class=\"nli\"><a href='");
	templateBuilder.Append(linkurl("case"));

	templateBuilder.Append("'>工业应用</a></li>\r\n            <li class=\"nli\">\r\n                <a href='");
	templateBuilder.Append(linkurl("reform"));

	templateBuilder.Append("'>节能改造</a>\r\n                <!--<ul>\r\n                    <li><a href=\"#\">示范案例</a></li>\r\n                    <li><a href=\"#\">示范案例</a></li>\r\n                    <li><a href=\"#\">示范案例</a></li>\r\n                </ul>-->\r\n            </li>\r\n            <li class=\"nli\"><a href='");
	templateBuilder.Append(linkurl("boiler",79));

	templateBuilder.Append("'>低氮锅炉</a></li>\r\n            <li class=\"nli\"><a href='");
	templateBuilder.Append(linkurl("service"));

	templateBuilder.Append("'>维保服务</a></li>\r\n            <li class=\"nli\"><a href='");
	templateBuilder.Append(linkurl("about"));

	templateBuilder.Append("'>企业简介</a></li>\r\n            <li class=\"nli\" style=\"background:none;\"><a href='");
	templateBuilder.Append(linkurl("contact"));

	templateBuilder.Append("'>联系我们</a></li>\r\n        </ul>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"swiper-containers aa\">\r\n    <div class=\"swiper-wrapper\">\r\n        <div class=\"swiper-slide\"><a href=\"#\"><div class=\"banner\" style=\"background:url(");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/images/1.jpg) no-repeat center center; background-size:cover;\"></div></a></div>\r\n        <div class=\"swiper-slide\"><a href=\"#\"><div class=\"banner\" style=\"background:url(");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/images/2.jpg) no-repeat center center; background-size:cover;\"></div></a></div>\r\n        <div class=\"swiper-slide\"><a href=\"#\"><div class=\"banner\" style=\"background:url(");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/images/3.jpg) no-repeat center center; background-size:cover;\"></div></a></div>\r\n    </div>\r\n    <!-- Add Pagination -->\r\n    <div class=\"swiper-pagination aa\"></div>\r\n</div>");


	templateBuilder.Append("\r\n\r\n    <div class=\"ctn\">\r\n        <div class=\"wrap\">\r\n            ");

	templateBuilder.Append("<!DOCTYPE html>\r\n<html lang=\"zh-CN\">\r\n<head>\r\n    ");

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


	templateBuilder.Append("\r\n</head>\r\n<body>\r\n    ");

	templateBuilder.Append("<div class=\"header\">\r\n    <div class=\"wrap\" style=\"position:relative;\">\r\n        <div class=\"logo1\"><img src=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/images/logo1.png\" /></div>\r\n        <div class=\"logo2\"><img src=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/images/logo2.png\" /></div>\r\n        <div class=\"header-right\">\r\n            <div class=\"search\">\r\n                <div class=\"search1\">产品搜索<span><img src=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/images/xx.png\" /></span></div>\r\n                <input type=\"text\" id=\"keywords\" name=\"keywords\" placeholder=\"请输入关键字\" required=\"\" onkeydown=\"if (event.keyCode == 13) { SiteSearch('");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("search.aspx', '#keywords', 'product'); return false };\" />\r\n                <button type=\"submit\" onclick=\"SiteSearch('");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("search.aspx', '#keywords', 'product'); return false\"></button>\r\n            </div>\r\n            <div class=\"tel1\">24小时免费服务热线：<span>");
	templateBuilder.Append(get_article_title(220).ToString());

	templateBuilder.Append("</span></div>\r\n        </div>\r\n        <div class=\"zd\">\r\n        <a href=\"javascript:void(0);\" onclick=\"AddFavorite('我的网站',location.href)\">收藏本站</a>|\r\n        <a href=\"javascript:void(0);\" onclick=\"SetHome(this, 'http://*&&*&&.com');\">设为首页</a></div>\r\n        <div class=\"logo\">\r\n            <span class=\"icon-menu hidden-lg hidden-md\"></span>\r\n            <!--移动端导航-->\r\n            <div class=\"sjdnav sjdnavhide hidden-lg hidden-md\">\r\n                <ul class=\"list-inline\">\r\n                    <li><a href='");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("'>首页</a></li>\r\n                    <li><a href='");
	templateBuilder.Append(linkurl("product"));

	templateBuilder.Append("'>产品总览</a></li>\r\n                    <li><a href='");
	templateBuilder.Append(linkurl("case"));

	templateBuilder.Append("'>工业应用</a></li>\r\n                    <li><a href='");
	templateBuilder.Append(linkurl("reform"));

	templateBuilder.Append("'>节能改造</a></li>\r\n                    <li><a href='");
	templateBuilder.Append(linkurl("boiler",1379));

	templateBuilder.Append("'>低氮锅炉</a></li>\r\n                    <li><a href='");
	templateBuilder.Append(linkurl("service"));

	templateBuilder.Append("'>维保服务</a></li>\r\n                    <li><a href='");
	templateBuilder.Append(linkurl("about"));

	templateBuilder.Append("'>企业简介</a></li>\r\n                    <li><a href='");
	templateBuilder.Append(linkurl("contact"));

	templateBuilder.Append("'>联系我们</a></li>\r\n                </ul>\r\n            </div>\r\n            <!--------------------------->\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"nav\">\r\n    <div class=\"wrap\" style=\"padding:0 2%;\">\r\n        <ul class=\"nul\">\r\n            <li class=\"nli\"><a href='");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("'>首页</a></li>\r\n            <li class=\"nli\"><a href='");
	templateBuilder.Append(linkurl("product"));

	templateBuilder.Append("'>产品总览</a></li>\r\n            <li class=\"nli\"><a href='");
	templateBuilder.Append(linkurl("case"));

	templateBuilder.Append("'>工业应用</a></li>\r\n            <li class=\"nli\">\r\n                <a href='");
	templateBuilder.Append(linkurl("reform"));

	templateBuilder.Append("'>节能改造</a>\r\n                <!--<ul>\r\n                    <li><a href=\"#\">示范案例</a></li>\r\n                    <li><a href=\"#\">示范案例</a></li>\r\n                    <li><a href=\"#\">示范案例</a></li>\r\n                </ul>-->\r\n            </li>\r\n            <li class=\"nli\"><a href='");
	templateBuilder.Append(linkurl("boiler",79));

	templateBuilder.Append("'>低氮锅炉</a></li>\r\n            <li class=\"nli\"><a href='");
	templateBuilder.Append(linkurl("service"));

	templateBuilder.Append("'>维保服务</a></li>\r\n            <li class=\"nli\"><a href='");
	templateBuilder.Append(linkurl("about"));

	templateBuilder.Append("'>企业简介</a></li>\r\n            <li class=\"nli\" style=\"background:none;\"><a href='");
	templateBuilder.Append(linkurl("contact"));

	templateBuilder.Append("'>联系我们</a></li>\r\n        </ul>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"swiper-containers aa\">\r\n    <div class=\"swiper-wrapper\">\r\n        <div class=\"swiper-slide\"><a href=\"#\"><div class=\"banner\" style=\"background:url(");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/images/1.jpg) no-repeat center center; background-size:cover;\"></div></a></div>\r\n        <div class=\"swiper-slide\"><a href=\"#\"><div class=\"banner\" style=\"background:url(");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/images/2.jpg) no-repeat center center; background-size:cover;\"></div></a></div>\r\n        <div class=\"swiper-slide\"><a href=\"#\"><div class=\"banner\" style=\"background:url(");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/images/3.jpg) no-repeat center center; background-size:cover;\"></div></a></div>\r\n    </div>\r\n    <!-- Add Pagination -->\r\n    <div class=\"swiper-pagination aa\"></div>\r\n</div>");


	templateBuilder.Append("\r\n\r\n    <div class=\"content-wrap indexbg clearfix\">\r\n        <!--服务项目-->\r\n        <div class=\"hotpro-wrap\">\r\n            <div class=\"container-fluid\">\r\n                <div class=\"title-line\">\r\n                    <img src=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/images/index-tit1.png\" alt=\"\">\r\n                </div>\r\n                <div class=\"hotpro-con\">\r\n                    <div class=\"hotpro-carousel\">\r\n                        ");
	DataTable p_list=get_article_list("product",8,"status = 0 and is_red=1");

	int p_adder__loop__id=0;
	foreach(DataRow p_adder in p_list.Rows)
	{
		p_adder__loop__id++;


	templateBuilder.Append("\r\n                        <a href='");
	templateBuilder.Append(linkurl("products",Utils.ObjectToStr(p_adder["id"])));

	templateBuilder.Append("#main' class=\"item\">\r\n                            <div class=\"picbox\">\r\n                                <div class=\"pic imgs text-center\" style=\"background:#fff; overflow:hidden;\">\r\n                                    <img src=\"" + Utils.ObjectToStr(p_adder["img_url"]) + "\" alt=\"\" style=\"max-width: 100%; max-height: 100%;\">\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"btit\">" + Utils.ObjectToStr(p_adder["title"]) + "</div>\r\n                        </a>\r\n                        ");
	}	//end for if

	templateBuilder.Append("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <!--公司简介-->\r\n        <div class=\"about-wrap\">\r\n            <div class=\"container-fluid\">\r\n                <div class=\"title-line\">\r\n                    <img src=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/images/index-tit2.png\" alt=\"\">\r\n                </div>\r\n                <div class=\"about-con\">\r\n                    <a href='");
	templateBuilder.Append(linkurl("about",1515));

	templateBuilder.Append("#main' class=\"clearfix\">\r\n                        <div class=\"picbox\">\r\n                            <div class=\"pic\"><img src=\"");
	templateBuilder.Append(get_article_img_url(1401).ToString());

	templateBuilder.Append("\" alt=\"\"></div>\r\n                        </div>\r\n                        <div class=\"conbox\">\r\n                            <div class=\"tit\">上海待武膜结构有限公司<span></span></div>\r\n                            <div class=\"line\"></div>\r\n                            <div class=\"con\">\r\n                                ");
	templateBuilder.Append(get_article_content("iabout").ToString());

	templateBuilder.Append("\r\n                            </div>\r\n                            <div class=\"morebtn\">查看详情+</div>\r\n                        </div>\r\n                    </a>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <!--案例展示-->\r\n        <div class=\"product-wrap\">\r\n            <div class=\"container-fluid\">\r\n                <div class=\"title-line\">\r\n                    <img src=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/images/index-tit3.png\" alt=\"\">\r\n                </div>\r\n                <div class=\"product-con\">\r\n                    <div class=\"row\">\r\n                        ");
	DataTable c_list=get_article_list("case",8,"status = 0 and is_red=1");

	int c_adder__loop__id=0;
	foreach(DataRow c_adder in c_list.Rows)
	{
		c_adder__loop__id++;


	templateBuilder.Append("\r\n                        <div class=\"col-md-3 col-sm-3 col-xs-6\">\r\n                            <div class=\"plist clearfix\">\r\n                                <a href='");
	templateBuilder.Append(linkurl("cases",Utils.ObjectToStr(c_adder["id"])));

	templateBuilder.Append("#main' class=\"clearfix\">\r\n                                    <div class=\"picbox\">\r\n                                        <div class=\"pic imgs text-center\" style=\"background:#fff; overflow:hidden;\">\r\n                                            <img src=\"" + Utils.ObjectToStr(c_adder["img_url"]) + "\" alt=\"\" style=\"max-width: 100%; max-height: 100%;\">\r\n                                        </div>\r\n                                    </div>\r\n                                    <div class=\"conbox\">\r\n                                        <div class=\"tit-more clearfix\">\r\n                                            <div class=\"tit lt\">" + Utils.ObjectToStr(c_adder["title"]) + "</div>\r\n                                            <div class=\"morebtn rt\">MORE+</div>\r\n                                        </div>\r\n                                        <div class=\"con\"></div>\r\n                                    </div>\r\n                                </a>\r\n                            </div>\r\n                        </div>\r\n                        ");
	}	//end for if

	templateBuilder.Append("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <!--合作伙伴-->\r\n        <!--<div class=\"partner-wrap\">\r\n            <div class=\"container-fluid\">\r\n                <div class=\"title-line\">\r\n                    <img src=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/images/index-tit4.png\" alt=\"\">\r\n                </div>\r\n                <div class=\"partner-con\">\r\n                    <div class=\"pbox\">\r\n                        <div class=\"row\">\r\n                            ");
	foreach(QJcms.Model.article_albums modelt in get_artice_albums(1517))
	{

	templateBuilder.Append("\r\n                            <div class=\"col-md-2 col-sm-3 col-xs-6\">\r\n                                <div class=\"plist clearfix\">\r\n                                    <a href=\"javascript:;\" class=\"clearfix\">\r\n                                        <div class=\"picbox\">\r\n                                            <div class=\"pic imgss text-center\" style=\"background: #fff; overflow:hidden;\">\r\n                                                <img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(modelt.thumb_path));
	templateBuilder.Append("\" alt=\"\" style=\"max-height: 100%; max-width: 100%;\">\r\n                                            </div>\r\n                                        </div>\r\n                                    </a>\r\n                                </div>\r\n                            </div>\r\n                            ");
	}	//end for if

	templateBuilder.Append("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>-->\r\n        <!--新闻动态-->\r\n        <div class=\"news-wrap\">\r\n            <div class=\"container-fluid\">\r\n                <div class=\"title-line\">\r\n                    <img src=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/images/index-tit5.png\" alt=\"\">\r\n                </div>\r\n                <div class=\"news-con\">\r\n                    <div class=\"row\">\r\n                        <div class=\"col-md-5 col-sm-12 col-xs-12\">\r\n                            <div class=\"bnlist clearfix\">\r\n                                ");
	DataTable n_list=get_article_list("news",1,"status = 0 and is_hot=1");

	int n_adder__loop__id=0;
	foreach(DataRow n_adder in n_list.Rows)
	{
		n_adder__loop__id++;


	templateBuilder.Append("\r\n                                <a href='");
	templateBuilder.Append(linkurl("newss",Utils.ObjectToStr(n_adder["id"])));

	templateBuilder.Append("#main'>\r\n                                    <div class=\"picbox\">\r\n                                        <div class=\"pic\" style=\"background: url(" + Utils.ObjectToStr(n_adder["img_url"]) + ") no-repeat center center; background-size: cover;\"></div>\r\n                                    </div>\r\n                                    <div class=\"conbox\">\r\n                                        <div class=\"tit\">" + Utils.ObjectToStr(n_adder["title"]) + "</div>\r\n                                        <div class=\"con\">" + Utils.ObjectToStr(n_adder["zhaiyao"]) + "... </div>\r\n                                        <div class=\"mbtn clearfix\">\r\n                                            <div class=\"m1 lt\">发布：");	templateBuilder.Append(Utils.ObjectToDateTime(Utils.ObjectToStr(n_adder["add_time"])).ToString("yyyy-MM-dd"));

	templateBuilder.Append("</div>\r\n                                            <div class=\"hidden-sm hidden-xs m2 lt\">更多新闻</div>\r\n                                            <div class=\"add rt\">+</div>\r\n                                        </div>\r\n                                    </div>\r\n                                </a>\r\n                                ");
	}	//end for if

	templateBuilder.Append("\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"col-md-7 col-sm-12 col-xs-12\">\r\n                            <div class=\"nlistbox clearfix\">\r\n                                ");
	DataTable n1_list=get_article_list("news",4,"status = 0 and is_red=1");

	int n1_adder__loop__id=0;
	foreach(DataRow n1_adder in n1_list.Rows)
	{
		n1_adder__loop__id++;


	templateBuilder.Append("\r\n                                <div class=\"nlist clearfix\">\r\n                                    <a href='");
	templateBuilder.Append(linkurl("newss",Utils.ObjectToStr(n1_adder["id"])));

	templateBuilder.Append("#main' class=\"clearfix\">\r\n                                        <div class=\"timebox\"><span>");	templateBuilder.Append(Utils.ObjectToDateTime(Utils.ObjectToStr(n1_adder["add_time"])).ToString("dd"));

	templateBuilder.Append("</span>");	templateBuilder.Append(Utils.ObjectToDateTime(Utils.ObjectToStr(n1_adder["add_time"])).ToString("yyyy-MM"));

	templateBuilder.Append("</div>\r\n                                        <div class=\"hidden-sm hidden-xs line\"></div>\r\n                                        <div class=\"conbox\">\r\n                                            <div class=\"tit\">" + Utils.ObjectToStr(n1_adder["title"]) + "</div>\r\n                                            <div class=\"con\">" + Utils.ObjectToStr(n1_adder["zhaiyao"]) + "</div>\r\n                                        </div>\r\n                                        <div class=\"hidden-sm hidden-xs add\">+</div>\r\n                                    </a>\r\n                                </div>\r\n                                ");
	}	//end for if

	templateBuilder.Append("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    ");

	templateBuilder.Append("<div class=\"footer wow slideInUp\">\r\n    <div class=\"wrap\">\r\n        <div class=\"footer1\">\r\n            <div class=\"ft\">\r\n                <ul class=\"ful\">\r\n                    <li class=\"ftit\">产品总览</li>\r\n                    ");
	DataTable anflist = get_category_child_list("product",0);

	int anfcpdr__loop__id=0;
	foreach(DataRow anfcpdr in anflist.Rows)
	{
		anfcpdr__loop__id++;


	templateBuilder.Append("\r\n                    <a href='");
	templateBuilder.Append(linkurl("product_lb",Utils.ObjectToStr(anfcpdr["id"])));

	templateBuilder.Append("'><li>" + Utils.ObjectToStr(anfcpdr["title"]) + "</li></a>\r\n                    ");
	}	//end for if

	templateBuilder.Append("\r\n                </ul>\r\n            </div>\r\n            <div class=\"ft\">\r\n                <ul class=\"ful\">\r\n                    <li class=\"ftit\">工业应用</li>\r\n                    ");
	DataTable anclist = get_category_child_list("case",0);

	int anccpdr__loop__id=0;
	foreach(DataRow anccpdr in anclist.Rows)
	{
		anccpdr__loop__id++;


	templateBuilder.Append("\r\n                    <a href='");
	templateBuilder.Append(linkurl("case_lb",Utils.ObjectToStr(anccpdr["id"])));

	templateBuilder.Append("'><li>" + Utils.ObjectToStr(anccpdr["title"]) + "</li></a>\r\n                    ");
	}	//end for if

	templateBuilder.Append("\r\n                </ul>\r\n            </div>\r\n            <div class=\"ft\">\r\n                <ul class=\"ful\">\r\n                    <li class=\"ftit\">节能改造</li>\r\n                    ");
	DataTable anrlist = get_category_child_list("reform",0);

	int anrcpdr__loop__id=0;
	foreach(DataRow anrcpdr in anrlist.Rows)
	{
		anrcpdr__loop__id++;


	templateBuilder.Append("\r\n                    <a href='");
	templateBuilder.Append(linkurl("reform_lb",Utils.ObjectToStr(anrcpdr["id"])));

	templateBuilder.Append("'><li>" + Utils.ObjectToStr(anrcpdr["title"]) + "</li></a>\r\n                    ");
	}	//end for if

	templateBuilder.Append("\r\n                </ul>\r\n            </div>\r\n            <div class=\"ft\">\r\n                <ul class=\"ful\">\r\n                    <li class=\"ftit\">低氮锅炉</li>\r\n                    ");
	DataTable lbcsist = get_article_list("boiler",0,"");

	int abscdder__loop__id=0;
	foreach(DataRow abscdder in lbcsist.Rows)
	{
		abscdder__loop__id++;


	templateBuilder.Append("\r\n                    <a href='");
	templateBuilder.Append(linkurl("boiler",Utils.ObjectToStr(abscdder["id"])));

	templateBuilder.Append("'><li>" + Utils.ObjectToStr(abscdder["title"]) + "</li></a>\r\n                    ");
	}	//end for if

	templateBuilder.Append("\r\n                </ul>\r\n            </div>\r\n            <div class=\"ft\" style=\"border:none;\">\r\n                <ul class=\"ful\">\r\n                    <li class=\"ftit\">维保服务</li>\r\n                    ");
	DataTable lcsist = get_article_list("service",0,"");

	int ascdder__loop__id=0;
	foreach(DataRow ascdder in lcsist.Rows)
	{
		ascdder__loop__id++;


	templateBuilder.Append("\r\n                    <a href='");
	templateBuilder.Append(linkurl("service"));

	templateBuilder.Append("'><li>" + Utils.ObjectToStr(ascdder["title"]) + "</li></a>\r\n                    ");
	}	//end for if

	templateBuilder.Append("\r\n                </ul>\r\n            </div>\r\n            <div class=\"ft\">\r\n                <ul class=\"ful\">\r\n                    <li class=\"ftit\">联系我们</li>\r\n                    <a href='");
	templateBuilder.Append(linkurl("contact"));

	templateBuilder.Append("'><li>联系我们</li></a>\r\n                </ul>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"fbj\"></div>\r\n\r\n<div class=\"cpyright wow slideInUp\">\r\n    <div class=\"wrap\">\r\n        版权所有 © 2017 上海迎匠热能设备有限公司 保留所有权利 <a href=\"http://www.miitbeian.gov.cn\" style=\"color:#666\" target=\"_blank\">沪ICP备17044079号-1</a> <br /><a href=\"\" style=\"color:#666\" target=\"_blank\">[管理入口]</a>\r\n        ");
	templateBuilder.Append(get_article_content("foot").ToString());

	templateBuilder.Append("\r\n\r\n    </div>\r\n</div>\r\n\r\n<div class=\"hot w100 hidden-lg hidden-md hidden-sm\">\r\n    <div class=\"row\">\r\n        <div class=\"col-xs-3 text-center no-padding\">\r\n            <a href=\"tel:18916156641\" class=\"no-decoration\">\r\n                <span class=\"glyphicon glyphicon-earphone\"></span>\r\n                <h6 class=\"no-margin\">电话</h6>\r\n            </a>\r\n        </div>\r\n        <div class=\"col-xs-3 text-center no-padding\">\r\n            <a target=\"_blank\" href=\"mqqwpa://im/chat?chat_type=wpa&uin=000000&version=1&src_type=web&web_src=oicqzone.com\" class=\"no-decoration\">\r\n                <span class=\"\"><img src=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/images/qq.png\" width=\"16\" height=\"16\" style=\"margin-bottom:3px; margin-top:2px;\" /></span>\r\n                <h6 class=\"no-margin\">消息</h6>\r\n            </a>\r\n        </div>\r\n        <div class=\"col-xs-3 text-center no-padding db-ewms\">\r\n            <a class=\"no-decoration\">\r\n                <span class=\"glyphicon glyphicon-qrcode\"></span>\r\n                <h6 class=\"no-margin\">二维码</h6>\r\n            </a>\r\n        </div>\r\n        <div class=\"col-xs-3 text-center no-padding\">\r\n            <a class=\"no-decoration\">\r\n                <span class=\"glyphicon glyphicon-share-alt\"></span>\r\n                <h6 class=\"no-margin\">分享</h6>\r\n            </a>\r\n        </div>\r\n    </div>\r\n</div>\r\n<div class=\"dbbox hidden-sm hidden-md hidden-lg\">\r\n    <div class=\"dbs ewm-box\">\r\n        <div class=\"neirong\">\r\n            <img src=\"");
	templateBuilder.Append(get_article_img_url(219).ToString());

	templateBuilder.Append("\" alt=\"\" />\r\n        </div>\r\n    </div>\r\n    <div class=\"dbs fenxiang-box\">\r\n        <div class=\"neirong\">\r\n            <div class=\"bdsharebuttonbox clearfix\">\r\n                <div class=\"pull-left li\"><a href=\"#\" class=\"bds_qzone\" data-cmd=\"qzone\" title=\"分享到QQ空间\"></a></div>\r\n                <div class=\"pull-left li\"><a href=\"#\" class=\"bds_tsina\" data-cmd=\"tsina\" title=\"分享到新浪微博\"></a></div>\r\n                <div class=\"pull-left li\"><a href=\"#\" class=\"bds_tqq\" data-cmd=\"tqq\" title=\"分享到腾讯微博\"></a></div>\r\n                <div class=\"pull-left li\"><a href=\"#\" class=\"bds_renren\" data-cmd=\"renren\" title=\"分享到人人网\"></a></div>\r\n                <div class=\"pull-left li\"><a href=\"#\" class=\"bds_weixin\" data-cmd=\"weixin\" title=\"分享到微信\"></a></div>\r\n            </div>\r\n            <script>\r\n                window._bd_share_config = { \"common\": { \"bdSnsKey\": {}, \"bdText\": \"\", \"bdMini\": \"2\", \"bdMiniList\": false, \"bdPic\": \"\", \"bdStyle\": \"1\", \"bdSize\": \"32\" }, \"share\": {} }; with (document) 0[(getElementsByTagName('head')[0] || body).appendChild(createElement('script')).src = 'http://bdimg.share.baidu.com/static/api/js/share.js?v=89860593.js?cdnversion=' + ~(-new Date() / 36e5)];\r\n            </");
	templateBuilder.Append("script>\r\n        </div>\r\n    </div>\r\n</div>\r\n<script>\r\n    $(\".hot .col-xs-3\").eq(2).click(function () {\r\n        if ($(\".dbbox .dbs.ewm-box\").is(':hidden')) {\r\n            $(\".dbbox .dbs.ewm-box\").slideDown();\r\n            $(\".dbbox .dbs.fenxiang-box\").slideUp();\r\n        } else {\r\n            $(\".dbbox .dbs.ewm-box\").slideUp();\r\n        }\r\n    })\r\n    $(\".hot .col-xs-3\").eq(3).find(\"a\").click(function () {\r\n        if ($(\".dbbox .dbs.fenxiang-box\").is(':hidden')) {\r\n            $(\".dbbox .dbs.fenxiang-box\").slideDown();\r\n            $(\".dbbox .dbs.ewm-box\").slideUp();\r\n        } else {\r\n            $(\".dbbox .dbs.fenxiang-box\").slideUp();\r\n        }\r\n    })\r\n</");
	templateBuilder.Append("script>\r\n\r\n<script src=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/js/swiper.min.js\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/js/gundong.js\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/js/lrtk.js\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/js/nav.js\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/js/bases.js\"></");
	templateBuilder.Append("script>\r\n\r\n<!--客服-->\r\n<div class=\"dock hidden-xs\" style=\"height: 296px; top: 200px;\">\r\n    <ul class=\"icons\">\r\n        <li class=\"up\"><i></i></li>\r\n\r\n        <li class=\"im\">\r\n            <i></i><p>\r\n                网站客服咨询<a href=\"http://wpa.qq.com/msgrd?v=3&amp;uin=000000&amp;site=qq&amp;menu=yes\" target=\"_blank\">客服1</a>\r\n            </p>\r\n        </li>\r\n\r\n        <li class=\"tel\">\r\n            <i></i><p>\r\n                电话：");
	templateBuilder.Append(get_article_title(220).ToString());

	templateBuilder.Append("<br>\r\n            </p>\r\n        </li>\r\n        <li class=\"wechat\">\r\n            <i></i><p><img src=\"");
	templateBuilder.Append(get_article_img_url(219).ToString());

	templateBuilder.Append("\" width=\"140\" height=\"140\" alt=\"扫描关注微信账号\"></p>\r\n        </li>\r\n        <li class=\"down\"><i></i></li>\r\n    </ul>\r\n    <a class=\"switch\"></a>\r\n</div>\r\n<script>\r\n    $(function () {\r\n\r\n        $(\"ul.icons li\").hover(function () {\r\n            $(this).addClass(\"active\").siblings(\"li\").removeClass(\"active\");\r\n        })\r\n        $(\"ul.icons li\").mouseout(function () {\r\n            $(this).removeClass(\"active\");\r\n        })\r\n        $(\".up\").click(function () {\r\n            // $(document).scrollTop(0);\r\n            $('html,body').animate({ scrollTop: '0px' }, 500);\r\n        })\r\n        $(\".down\").click(function () {\r\n            var temp = $(document).height();\r\n            console.log(temp);\r\n            $('html,body').animate({ scrollTop: temp }, 500);\r\n            // $(document).scrollTop(temp);\r\n        })\r\n        $(\".switch\").click(function () {\r\n            $(\"div.dock\").toggleClass(\"close\");\r\n        })\r\n    })\r\n</");
	templateBuilder.Append("script>\r\n\r\n");


	templateBuilder.Append("\r\n</body>\r\n</html>");


	templateBuilder.Append("\r\n            <div class=\"ctn-right\">\r\n                <div class=\"crt\"><div class=\"crtl\">产品总览</div><div class=\"crtr\">您现在的位置：首页>");
	templateBuilder.Append(Utils.ObjectToStr(model.title));
	templateBuilder.Append("</div></div>\r\n                <div class=\"crb\">\r\n                    <div class=\"cpxq\">\r\n                        <img src=\"");
	templateBuilder.Append(Utils.ObjectToStr(model.img_url));
	templateBuilder.Append("\" />\r\n                        <div class=\"cpxq1\">");
	templateBuilder.Append(Utils.ObjectToStr(model.title));
	templateBuilder.Append("</div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    ");

	templateBuilder.Append("<div class=\"footer wow slideInUp\">\r\n    <div class=\"wrap\">\r\n        <div class=\"footer1\">\r\n            <div class=\"ft\">\r\n                <ul class=\"ful\">\r\n                    <li class=\"ftit\">产品总览</li>\r\n                    ");
	DataTable anflist = get_category_child_list("product",0);

	int anfcpdr__loop__id=0;
	foreach(DataRow anfcpdr in anflist.Rows)
	{
		anfcpdr__loop__id++;


	templateBuilder.Append("\r\n                    <a href='");
	templateBuilder.Append(linkurl("product_lb",Utils.ObjectToStr(anfcpdr["id"])));

	templateBuilder.Append("'><li>" + Utils.ObjectToStr(anfcpdr["title"]) + "</li></a>\r\n                    ");
	}	//end for if

	templateBuilder.Append("\r\n                </ul>\r\n            </div>\r\n            <div class=\"ft\">\r\n                <ul class=\"ful\">\r\n                    <li class=\"ftit\">工业应用</li>\r\n                    ");
	DataTable anclist = get_category_child_list("case",0);

	int anccpdr__loop__id=0;
	foreach(DataRow anccpdr in anclist.Rows)
	{
		anccpdr__loop__id++;


	templateBuilder.Append("\r\n                    <a href='");
	templateBuilder.Append(linkurl("case_lb",Utils.ObjectToStr(anccpdr["id"])));

	templateBuilder.Append("'><li>" + Utils.ObjectToStr(anccpdr["title"]) + "</li></a>\r\n                    ");
	}	//end for if

	templateBuilder.Append("\r\n                </ul>\r\n            </div>\r\n            <div class=\"ft\">\r\n                <ul class=\"ful\">\r\n                    <li class=\"ftit\">节能改造</li>\r\n                    ");
	DataTable anrlist = get_category_child_list("reform",0);

	int anrcpdr__loop__id=0;
	foreach(DataRow anrcpdr in anrlist.Rows)
	{
		anrcpdr__loop__id++;


	templateBuilder.Append("\r\n                    <a href='");
	templateBuilder.Append(linkurl("reform_lb",Utils.ObjectToStr(anrcpdr["id"])));

	templateBuilder.Append("'><li>" + Utils.ObjectToStr(anrcpdr["title"]) + "</li></a>\r\n                    ");
	}	//end for if

	templateBuilder.Append("\r\n                </ul>\r\n            </div>\r\n            <div class=\"ft\">\r\n                <ul class=\"ful\">\r\n                    <li class=\"ftit\">低氮锅炉</li>\r\n                    ");
	DataTable lbcsist = get_article_list("boiler",0,"");

	int abscdder__loop__id=0;
	foreach(DataRow abscdder in lbcsist.Rows)
	{
		abscdder__loop__id++;


	templateBuilder.Append("\r\n                    <a href='");
	templateBuilder.Append(linkurl("boiler",Utils.ObjectToStr(abscdder["id"])));

	templateBuilder.Append("'><li>" + Utils.ObjectToStr(abscdder["title"]) + "</li></a>\r\n                    ");
	}	//end for if

	templateBuilder.Append("\r\n                </ul>\r\n            </div>\r\n            <div class=\"ft\" style=\"border:none;\">\r\n                <ul class=\"ful\">\r\n                    <li class=\"ftit\">维保服务</li>\r\n                    ");
	DataTable lcsist = get_article_list("service",0,"");

	int ascdder__loop__id=0;
	foreach(DataRow ascdder in lcsist.Rows)
	{
		ascdder__loop__id++;


	templateBuilder.Append("\r\n                    <a href='");
	templateBuilder.Append(linkurl("service"));

	templateBuilder.Append("'><li>" + Utils.ObjectToStr(ascdder["title"]) + "</li></a>\r\n                    ");
	}	//end for if

	templateBuilder.Append("\r\n                </ul>\r\n            </div>\r\n            <div class=\"ft\">\r\n                <ul class=\"ful\">\r\n                    <li class=\"ftit\">联系我们</li>\r\n                    <a href='");
	templateBuilder.Append(linkurl("contact"));

	templateBuilder.Append("'><li>联系我们</li></a>\r\n                </ul>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"fbj\"></div>\r\n\r\n<div class=\"cpyright wow slideInUp\">\r\n    <div class=\"wrap\">\r\n        版权所有 © 2017 上海迎匠热能设备有限公司 保留所有权利 <a href=\"http://www.miitbeian.gov.cn\" style=\"color:#666\" target=\"_blank\">沪ICP备17044079号-1</a> <br /><a href=\"\" style=\"color:#666\" target=\"_blank\">[管理入口]</a>\r\n        ");
	templateBuilder.Append(get_article_content("foot").ToString());

	templateBuilder.Append("\r\n\r\n    </div>\r\n</div>\r\n\r\n<div class=\"hot w100 hidden-lg hidden-md hidden-sm\">\r\n    <div class=\"row\">\r\n        <div class=\"col-xs-3 text-center no-padding\">\r\n            <a href=\"tel:18916156641\" class=\"no-decoration\">\r\n                <span class=\"glyphicon glyphicon-earphone\"></span>\r\n                <h6 class=\"no-margin\">电话</h6>\r\n            </a>\r\n        </div>\r\n        <div class=\"col-xs-3 text-center no-padding\">\r\n            <a target=\"_blank\" href=\"mqqwpa://im/chat?chat_type=wpa&uin=000000&version=1&src_type=web&web_src=oicqzone.com\" class=\"no-decoration\">\r\n                <span class=\"\"><img src=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/images/qq.png\" width=\"16\" height=\"16\" style=\"margin-bottom:3px; margin-top:2px;\" /></span>\r\n                <h6 class=\"no-margin\">消息</h6>\r\n            </a>\r\n        </div>\r\n        <div class=\"col-xs-3 text-center no-padding db-ewms\">\r\n            <a class=\"no-decoration\">\r\n                <span class=\"glyphicon glyphicon-qrcode\"></span>\r\n                <h6 class=\"no-margin\">二维码</h6>\r\n            </a>\r\n        </div>\r\n        <div class=\"col-xs-3 text-center no-padding\">\r\n            <a class=\"no-decoration\">\r\n                <span class=\"glyphicon glyphicon-share-alt\"></span>\r\n                <h6 class=\"no-margin\">分享</h6>\r\n            </a>\r\n        </div>\r\n    </div>\r\n</div>\r\n<div class=\"dbbox hidden-sm hidden-md hidden-lg\">\r\n    <div class=\"dbs ewm-box\">\r\n        <div class=\"neirong\">\r\n            <img src=\"");
	templateBuilder.Append(get_article_img_url(219).ToString());

	templateBuilder.Append("\" alt=\"\" />\r\n        </div>\r\n    </div>\r\n    <div class=\"dbs fenxiang-box\">\r\n        <div class=\"neirong\">\r\n            <div class=\"bdsharebuttonbox clearfix\">\r\n                <div class=\"pull-left li\"><a href=\"#\" class=\"bds_qzone\" data-cmd=\"qzone\" title=\"分享到QQ空间\"></a></div>\r\n                <div class=\"pull-left li\"><a href=\"#\" class=\"bds_tsina\" data-cmd=\"tsina\" title=\"分享到新浪微博\"></a></div>\r\n                <div class=\"pull-left li\"><a href=\"#\" class=\"bds_tqq\" data-cmd=\"tqq\" title=\"分享到腾讯微博\"></a></div>\r\n                <div class=\"pull-left li\"><a href=\"#\" class=\"bds_renren\" data-cmd=\"renren\" title=\"分享到人人网\"></a></div>\r\n                <div class=\"pull-left li\"><a href=\"#\" class=\"bds_weixin\" data-cmd=\"weixin\" title=\"分享到微信\"></a></div>\r\n            </div>\r\n            <script>\r\n                window._bd_share_config = { \"common\": { \"bdSnsKey\": {}, \"bdText\": \"\", \"bdMini\": \"2\", \"bdMiniList\": false, \"bdPic\": \"\", \"bdStyle\": \"1\", \"bdSize\": \"32\" }, \"share\": {} }; with (document) 0[(getElementsByTagName('head')[0] || body).appendChild(createElement('script')).src = 'http://bdimg.share.baidu.com/static/api/js/share.js?v=89860593.js?cdnversion=' + ~(-new Date() / 36e5)];\r\n            </");
	templateBuilder.Append("script>\r\n        </div>\r\n    </div>\r\n</div>\r\n<script>\r\n    $(\".hot .col-xs-3\").eq(2).click(function () {\r\n        if ($(\".dbbox .dbs.ewm-box\").is(':hidden')) {\r\n            $(\".dbbox .dbs.ewm-box\").slideDown();\r\n            $(\".dbbox .dbs.fenxiang-box\").slideUp();\r\n        } else {\r\n            $(\".dbbox .dbs.ewm-box\").slideUp();\r\n        }\r\n    })\r\n    $(\".hot .col-xs-3\").eq(3).find(\"a\").click(function () {\r\n        if ($(\".dbbox .dbs.fenxiang-box\").is(':hidden')) {\r\n            $(\".dbbox .dbs.fenxiang-box\").slideDown();\r\n            $(\".dbbox .dbs.ewm-box\").slideUp();\r\n        } else {\r\n            $(\".dbbox .dbs.fenxiang-box\").slideUp();\r\n        }\r\n    })\r\n</");
	templateBuilder.Append("script>\r\n\r\n<script src=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/js/swiper.min.js\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/js/gundong.js\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/js/lrtk.js\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/js/nav.js\"></");
	templateBuilder.Append("script>\r\n<script src=\"");
	templateBuilder.Append("/templates/html");
	templateBuilder.Append("/js/bases.js\"></");
	templateBuilder.Append("script>\r\n\r\n<!--客服-->\r\n<div class=\"dock hidden-xs\" style=\"height: 296px; top: 200px;\">\r\n    <ul class=\"icons\">\r\n        <li class=\"up\"><i></i></li>\r\n\r\n        <li class=\"im\">\r\n            <i></i><p>\r\n                网站客服咨询<a href=\"http://wpa.qq.com/msgrd?v=3&amp;uin=000000&amp;site=qq&amp;menu=yes\" target=\"_blank\">客服1</a>\r\n            </p>\r\n        </li>\r\n\r\n        <li class=\"tel\">\r\n            <i></i><p>\r\n                电话：");
	templateBuilder.Append(get_article_title(220).ToString());

	templateBuilder.Append("<br>\r\n            </p>\r\n        </li>\r\n        <li class=\"wechat\">\r\n            <i></i><p><img src=\"");
	templateBuilder.Append(get_article_img_url(219).ToString());

	templateBuilder.Append("\" width=\"140\" height=\"140\" alt=\"扫描关注微信账号\"></p>\r\n        </li>\r\n        <li class=\"down\"><i></i></li>\r\n    </ul>\r\n    <a class=\"switch\"></a>\r\n</div>\r\n<script>\r\n    $(function () {\r\n\r\n        $(\"ul.icons li\").hover(function () {\r\n            $(this).addClass(\"active\").siblings(\"li\").removeClass(\"active\");\r\n        })\r\n        $(\"ul.icons li\").mouseout(function () {\r\n            $(this).removeClass(\"active\");\r\n        })\r\n        $(\".up\").click(function () {\r\n            // $(document).scrollTop(0);\r\n            $('html,body').animate({ scrollTop: '0px' }, 500);\r\n        })\r\n        $(\".down\").click(function () {\r\n            var temp = $(document).height();\r\n            console.log(temp);\r\n            $('html,body').animate({ scrollTop: temp }, 500);\r\n            // $(document).scrollTop(temp);\r\n        })\r\n        $(\".switch\").click(function () {\r\n            $(\"div.dock\").toggleClass(\"close\");\r\n        })\r\n    })\r\n</");
	templateBuilder.Append("script>\r\n\r\n");


	templateBuilder.Append("\r\n</body>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
