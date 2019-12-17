using System;
using System.Collections.Generic;
using System.Web;
using QJcms.Common;
using System.Text;
using System.Data;

namespace QJcms.Web.tools
{
    /// <summary>
    /// advert_ajax 的摘要说明
    /// </summary>
    public class advert_ajax : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int aid = QJRequest.GetQueryInt("id");

            //获得广告位的ID
            if (aid < 1)
            {
                context.Response.Write("document.write('错误提示，请勿提交非法字符！');");
                return;
            }

            //检查广告位是否存在
            BLL.advert abll = new BLL.advert();
            if (!abll.Exists(aid))
            {
                context.Response.Write("document.write('错误提示，该广告位不存在！');");
                return;
            }

            //取得该广告位详细信息
            Model.advert aModel = abll.GetModel(aid);

            //输出该广告位下的广告条,不显示未开始、过期、暂停广告
            BLL.advert_banner bbll = new BLL.advert_banner();
            DataSet ds = bbll.GetList(0, "is_lock=0 and datediff('d',start_time,date())>=0 and datediff('d',end_time,date())<=0 and aid=" + aid, "sort_id asc");
            if (ds.Tables[0].Rows.Count < 1)
            {
                context.Response.Write("document.write('该广告位下暂无广告内容');");
                return;
            }

            //=================判断广告位类别,输出广告条======================

            //新增，取得站点配置信息
            QJcms.Model.siteconfig siteConfig = new QJcms.BLL.siteconfig().loadConfig();

            switch (aModel.type)
            {
                case 1: //文字
                    context.Response.Write("document.write('<ul>');\n");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        //如果超出限制广告数量，则退出循环
                        if (i >= aModel.view_num)
                            break;
                        DataRow dr = ds.Tables[0].Rows[i];
                        context.Response.Write("document.write('<li>');");
                        context.Response.Write("document.write('<a title=\"" + dr["title"] + "\" target=\"" + aModel.target + "\" href=\"" + dr["link_url"] + "\">" + dr["title"] + "</a>');");
                        context.Response.Write("document.write('</li>');\n");
                    }
                    context.Response.Write("document.write('</ul>');\n");
                    break;
                case 2: //图片
                    string widthANDheight = "";
                    if (aModel.view_width > 0 || aModel.view_height > 0)
                    {
                        widthANDheight = " width=" + aModel.view_width + " height=" + aModel.view_height + "";
                    }
                    //if (ds.Tables[0].Rows.Count == 1)
                    //{
                    //    DataRow dr = ds.Tables[0].Rows[0];
                    //    if (!string.IsNullOrEmpty(dr["link_url"].ToString()))
                    //    {

                    //        context.Response.Write("document.write('<a data=\"" + dr["title"] + "\" target=\"" + aModel.target + "\" href=\"" + dr["link_url"] + "\">');");
                    //        context.Response.Write("document.write('<img src=\"" + dr["file_path"] + "\" " + widthANDheight + " border=0 />');");
                    //        context.Response.Write("document.write('</a>');");
                    //    }
                    //    else
                    //    {
                    //        context.Response.Write("document.write('<img src=\"" + dr["file_path"] + "\" " + widthANDheight + " border=0 />');");
                    //    }
                    //}
                    //else
                    //{
                        context.Response.Write("document.write('<ul>');\n");
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            //如果超出限制广告数量，则退出循环
                            if (i >= aModel.view_num)
                                break;
                            DataRow dr = ds.Tables[0].Rows[i];
                            if (!string.IsNullOrEmpty(dr["link_url"].ToString()))
                            {
                                context.Response.Write("document.write('<li>');");
                                context.Response.Write("document.write('<a data=\"" + dr["title"] + "\" target=\"" + aModel.target + "\" href=\"" + dr["link_url"] + "\">');");
                                context.Response.Write("document.write('<img src=\"" + dr["file_path"] + "\" " + widthANDheight + "  border=0 />');");
                                context.Response.Write("document.write('</a>');\n");
                                context.Response.Write("document.write('</li>');\n");
                            }
                            else
                            {
                                context.Response.Write("document.write('<li><img src=\"" + dr["file_path"] + "\" " + widthANDheight + "  border=0 /></li>');");
                            }
                        }
                        context.Response.Write("document.write('</ul>');\n");
                    //}
                    break;
                case 3: //幻灯片
                    StringBuilder picTitle = new StringBuilder();
                    StringBuilder picUrl = new StringBuilder();
                    StringBuilder picLink = new StringBuilder();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        //如果超出限制广告数量，则退出循环
                        if (i >= aModel.view_num)
                            break;
                        DataRow dr = ds.Tables[0].Rows[i];
                        picTitle.Append(dr["title"].ToString());
                        picUrl.Append(dr["file_path"].ToString());
                        picLink.Append(dr["link_url"].ToString());
                        if (i < ds.Tables[0].Rows.Count - 1)
                        {
                            picTitle.Append("|");
                            picUrl.Append("|");
                            picLink.Append("|");
                        }
                    }/*?width=" + aModel.view_width + "&height=" + aModel.view_height + "&bigSrc=" + picUrl + "&href=" + picLink + "*/
                    context.Response.Write("document.write('<object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" codebase=\"http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0\" width=\"" + aModel.view_width + "\" height=\"" + aModel.view_height + "\">');\n");
                    context.Response.Write("document.write('<param name=\"allowScriptAccess\" value=\"sameDomain\">');\n");
                    context.Response.Write("document.write('<param name=\"movie\" value=\"" + siteConfig.webpath + "images/focus.swf\">');\n");
                    context.Response.Write("document.write('<param name=\"menu\" value=\"false\">');\n");
                    context.Response.Write("document.write('<param name=\"quality\" value=\"high\">');\n");
                    context.Response.Write("document.write('<param name=\"wmode\" value=\"transparent\">');\n");
                    context.Response.Write("document.write('<param name=\"bgcolor\" value=\"#ffffff\">');\n");
                    context.Response.Write("document.write('<param name=\"FlashVars\" value=\"pics=" + picUrl + "&links=" + picLink + "&texts=" + picTitle + "&borderwidth=" + aModel.view_width + "&borderheight=" + aModel.view_height + "&textheight=0\">');\n");
                    context.Response.Write("document.write('<embed allowScriptAccess=\"sameDomain\" src=\"" + siteConfig.webpath + "images/focus.swf\" width=\"" + aModel.view_width + "\" height=\"" + aModel.view_height + "\" menu=\"false\" quality=\"high\" wmode=\"transparent\" bgcolor=\"#ffffff\" FlashVars=\"pics=" + picUrl + "&links=" + picLink + "&texts=" + picTitle + "&borderwidth=" + aModel.view_width + "&borderheight=" + aModel.view_height + "&textheight=0\" type=\"application/x-shockwave-flash\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\"></embed>');\n");
                    context.Response.Write("document.write('</object>');\n");
                    break;
                case 4: //动画
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];
                        context.Response.Write("document.write('<object classid=\"clsid:D27CDB6E-AE6D-11CF-96B8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0\" width=\"" + aModel.view_width + "\" height=\"" + aModel.view_height + "\">');\n");
                        context.Response.Write("document.write('<param name=\"movie\" value=\"" + dr["file_path"] + "\">');\n");
                        context.Response.Write("document.write('<param name=\"quality\" value=\"high\">');\n");
                        context.Response.Write("document.write('<param name=\"wmode\" value=\"transparent\">');\n");
                        context.Response.Write("document.write('<param name=\"menu\" value=\"false\">');\n");
                        context.Response.Write("document.write('<embed src=\"" + dr["file_path"] + "\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\" width=\"" + aModel.view_width + "\" height=\"" + aModel.view_height + "\" quality=\"High\" wmode=\"transparent\">');\n");
                        context.Response.Write("document.write('</embed>');\n");
                        context.Response.Write("document.write('</object>');\n");
                    }
                    else
                    {
                        context.Response.Write("document.write('<ul>');\n");
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            //如果超出限制广告数量，则退出循环
                            if (i >= aModel.view_num)
                                break;
                            DataRow dr = ds.Tables[0].Rows[i];
                            context.Response.Write("document.write('<li>');");
                            context.Response.Write("document.write('<object classid=\"clsid:D27CDB6E-AE6D-11CF-96B8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0\" width=\"" + aModel.view_width + "\" height=\"" + aModel.view_height + "\">');\n");
                            context.Response.Write("document.write('<param name=\"movie\" value=\"" + dr["file_path"] + "\">');\n");
                            context.Response.Write("document.write('<param name=\"quality\" value=\"high\">');\n");
                            context.Response.Write("document.write('<param name=\"wmode\" value=\"transparent\">');\n");
                            context.Response.Write("document.write('<param name=\"menu\" value=\"false\">');\n");
                            context.Response.Write("document.write('<embed src=\"" + dr["file_path"] + "\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\" width=\"" + aModel.view_width + "\" height=\"" + aModel.view_height + "\" quality=\"High\" wmode=\"transparent\">');\n");
                            context.Response.Write("document.write('</embed>');\n");
                            context.Response.Write("document.write('</object>');\n");
                            context.Response.Write("document.write('</li>');\n");
                        }
                        context.Response.Write("document.write('</ul>');\n");
                    }
                    break;
                case 5://视频
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        //如果超出限制广告数量，则退出循环
                        if (i >= 1)
                            break;
                        DataRow dr = ds.Tables[0].Rows[i];
                        context.Response.Write("document.write('<object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,40,0\" width=" + aModel.view_width + " height=" + aModel.view_height + " viewastext>');\n");
                        context.Response.Write("document.write('<param name=\"movie\" value=\"" + siteConfig.webpath + "images/player.swf\" />');\n");
                        context.Response.Write("document.write('<param name=\"quality\" value=\"high\" />');\n");
                        context.Response.Write("document.write('<param name=\"allowFullScreen\" value=\"true\" />');\n");
                        context.Response.Write("document.write('<param name=\"FlashVars\" value=\"vcastr_file=" + dr["file_path"].ToString() + "&LogoText=www.auto.cn&BarTransparent=30&BarColor=0xffffff&IsAutoPlay=1&IsContinue=1\" />');\n");
                        context.Response.Write("document.write('</object>');\n");
                    }
                    break;
                case 6://代码
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        //如果超出限制广告数量，则退出循环
                        if (i >= 1)
                            break;
                        DataRow dr = ds.Tables[0].Rows[i];
                        StringBuilder sb = new StringBuilder(dr["content"].ToString());
                        sb.Replace("&lt;", "<");
                        sb.Replace("&gt;", ">");
                        sb.Replace("\"", "'");
                        context.Response.Write("document.write(\"" + sb.ToString() + "\")");
                    }
                    break;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}