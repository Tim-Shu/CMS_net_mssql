using QJcms.Common;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace QJcms.Web.UI
{
    public class CreatHtml
    {
        BLL.article_category objarticle_category = new BLL.article_category();//文章分类
        BLL.channel objchannel = new BLL.channel();//频道
        BLL.channel_category objchannel_category = new BLL.channel_category();//频道分类
        BLL.article objarticle = new BLL.article();//文章
        Model.siteconfig config = new BLL.siteconfig().loadConfig();//站点配置
        Model.channel modelchanel = new Model.channel();//频道实体类
        private const string urlstr = "\"{0}tools/admin_ajax.ashx?action=get_builder_html&lang={1}&html_filename=&indexy=&aspx_filename={2}&catalogue={3}\"";

        #region 获取生成静态地址
        public void getpublishsite(HttpContext context)
        {
            string lang = QJRequest.GetQueryString("lang");//域名目录
            string name = QJRequest.GetQueryString("name");//频道名称
            string type = QJRequest.GetQueryString("type");//生成类型

            StringBuilder sbjson = new StringBuilder();//地址列表 JSON数据格式
            //获得URL配置列表
            BLL.url_rewrite bll = new BLL.url_rewrite();
            List<Model.url_rewrite> ls = bll.GetListAll();
            string linkurl = string.Empty;

            sbjson.Append("[");
            foreach (Model.url_rewrite modeltrewrite in ls) //循环URL配置表，获取需要创建HTML的地址
            {
                if (!string.IsNullOrEmpty(name) && modeltrewrite.channel != name) continue;
                if (!string.IsNullOrEmpty(type) && modeltrewrite.type.ToLower() != type) continue;
                DataTable dt = new DataTable();//数据列表
                if (!string.IsNullOrEmpty(modeltrewrite.channel))
                {
                    modelchanel = objchannel.GetModel(modeltrewrite.channel);
                    if (modelchanel == null) continue;
                    //含有重写表达式
                    if (modeltrewrite.url_rewrite_items.Count > 0)
                    {
                        //遍历URL字典的子节点
                        foreach (Model.url_rewrite_item item in modeltrewrite.url_rewrite_items)
                        {
                            //不含参数表达式
                            if (item.querystring == string.Empty)
                            {
                                sbjson.AppendFormat(ReWriteURL(lang, "", item.pattern, modeltrewrite));
                            }
                            //含参数表达式
                            else
                            {
                                switch (modeltrewrite.type.ToLower())
                                {
                                    case "index"://首页                                        
                                        sbjson.AppendFormat(GetPageList(lang, name, modeltrewrite, item, dt));
                                        break;
                                    case "category"://栏目页
                                        break;
                                    case "list"://列表页
                                        if (modelchanel.deep_layer == 0)
                                        {
                                            goto case "index";
                                        }
                                        dt = objarticle_category.GetList(0, name);
                                        sbjson.AppendFormat(GetArticleList(lang, name, modeltrewrite, item, dt));
                                        break;
                                    case "detail"://详细页
                                        dt = objarticle.GetList(name, 0, "", " id desc").Tables[0];
                                        sbjson.AppendFormat(GetDetailList(lang, name, modeltrewrite, item, dt));
                                        break;
                                    default://其它
                                        sbjson.AppendFormat(ReWriteURL(lang, "", item.pattern, modeltrewrite));
                                        break;
                                }
                            }
                        }
                    }
                    //不含重写表达式
                    else
                    {
                        sbjson.AppendFormat(ReWriteURL(lang, "", modeltrewrite.page, modeltrewrite));
                    }
                }
                else
                {
                    if (modeltrewrite.type.ToLower() == "other" || modeltrewrite.type.ToLower() == "index")
                    {
                        sbjson.AppendFormat(ReWriteURL(lang, "", modeltrewrite.page, modeltrewrite));
                    }
                }
            }
            sbjson.Append("]");
            context.Response.Write(sbjson.ToString().Replace(",,", ",").Replace("[,", "[").Replace(",]", "]"));
        }
        /// <summary>
        /// 重写静态页地址
        /// </summary>
        /// <param name="lang">域名目录</param>
        /// <param name="querystr">分页数</param>
        /// <param name="pattern">URL配置表</param>
        /// <param name="rewrite">URL重写表达式</param>
        /// <returns></returns>
        private string ReWriteURL(string lang, string querystr, string pattern, Model.url_rewrite rewrite)
        {
            StringBuilder sburl = new StringBuilder();
            string linkurl = string.Format("{0}/{1}/{2}?{3}", QJConst.DIRECTORY_REWRITE_ASPX, lang, rewrite.page, querystr);//动态页页面指向地址（非解析后地址）
            string HTMLPattern = string.Format("{0}/{1}/{2}", QJConst.DIRECTORY_REWRITE_HTML, lang, Utils.GetUrlExtension(pattern, config.staticextension)); //静态页地址 替换扩展名
            sburl.AppendFormat(urlstr, config.webpath, lang, linkurl, HTMLPattern);
            return sburl.ToString();
        }
        //获取分页列表URL
        private string GetPageList(string lang, string channelname, Model.url_rewrite rewrite, Model.url_rewrite_item item, DataTable dt)
        {
            StringBuilder sburl = new StringBuilder();
            int totalCount = 0, pageindex = 0;//初始分页变量            
            if (!string.IsNullOrEmpty(channelname))
            {
                totalCount = objarticle.GetCount(channelname, 0, "");
                modelchanel = objchannel.GetModel(channelname);
                if (modelchanel.page_size > 0)
                    pageindex = GetPageSize(totalCount, modelchanel.page_size);
                else
                    pageindex = 1;
            }
            sburl.Append(",");
            for (int q = 1; q <= pageindex; q++)
            {
                string pageStr = string.Format(item.path, "0", q);
                string querystr = Regex.Replace(pageStr, item.pattern, item.querystring, RegexOptions.None | RegexOptions.IgnoreCase);
                if (!string.IsNullOrEmpty(sburl.ToString()))
                    sburl.Append(",");
                sburl.Append(ReWriteURL(lang, querystr, pageStr, rewrite));
            }
            return sburl.ToString();
        }
        //获取分类列表URL
        private string GetArticleList(string lang, string channelname, Model.url_rewrite rewrite, Model.url_rewrite_item item, DataTable dt)
        {
            StringBuilder sburl = new StringBuilder();
            if (dt != null && dt.Rows.Count > 0)
            {
                sburl.Append(",");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int totalCount = 0, pageindex = 0;//初始分页变量            
                    if (!string.IsNullOrEmpty(channelname))
                    {
                        totalCount = objarticle.GetCount(channelname, 0, "");
                        modelchanel = objchannel.GetModel(channelname);
                        if (modelchanel.page_size > 0)
                            pageindex = GetPageSize(totalCount, modelchanel.page_size);
                        else
                            pageindex = 1;
                    }

                    for (int q = 1; q <= pageindex; q++)
                    {
                        string querystr = Regex.Replace(string.Format(item.path, dt.Rows[i]["id"].ToString(), q), item.pattern, item.querystring, RegexOptions.None | RegexOptions.IgnoreCase);
                        if (!string.IsNullOrEmpty(sburl.ToString()))
                            sburl.Append(",");
                        sburl.Append(ReWriteURL(lang, querystr, string.Format(item.path, dt.Rows[i]["id"].ToString(), q), rewrite));
                    }
                }
            }
            return sburl.ToString();
        }
        //获取文章列表URL
        private string GetDetailList(string lang, string channelname, Model.url_rewrite rewrite, Model.url_rewrite_item item, DataTable dt)
        {
            StringBuilder sburl = new StringBuilder();
            if (dt != null && dt.Rows.Count > 0)
            {
                sburl.Append(",");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string strvalue = string.IsNullOrEmpty(dt.Rows[i]["call_index"].ToString()) ? dt.Rows[i]["id"].ToString() : dt.Rows[i]["call_index"].ToString();
                    string querystr = Regex.Replace(string.Format(item.path, strvalue), item.pattern, item.querystring, RegexOptions.None | RegexOptions.IgnoreCase);
                    if (!string.IsNullOrEmpty(sburl.ToString()))
                        sburl.Append(",");
                    sburl.Append(ReWriteURL(lang, querystr, string.Format(item.path, strvalue), rewrite));
                }
            }
            return sburl.ToString();
        }

        /// <summary>
        /// 计算分页数量
        /// </summary>
        /// <param name="totalCount">数据总数</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns>分页数量</returns>
        private int GetPageSize(int totalCount, int pageSize)
        {
            //计算页数
            if (totalCount < 1 || pageSize < 1)
            {
                return 1;
            }
            int pageCount = totalCount / pageSize;
            if (pageCount < 1)
            {
                return 1;
            }
            if (totalCount % pageSize > 0)
            {
                return (pageCount += 1);
            }
            else
            {
                if (totalCount % pageSize == 0)
                    return pageCount;
            }
            if (pageCount <= 1)
            {
                return 1;
            }
            return 1;
        }
        #endregion
    }
}
