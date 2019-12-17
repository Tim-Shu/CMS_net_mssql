using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QJcms.Common;

namespace QJcms.Web.UI
{
    public partial class BasePage : System.Web.UI.Page
    {
        #region 列表标签======================================
        /// <summary>
        /// 文章列表
        /// </summary>
        /// <param name="channel_name">频道名称</param>
        /// <param name="top">显示条数</param>
        /// <param name="strwhere">查询条件</param>
        /// <returns>DataTable</returns>
        protected DataTable get_article_list(string channel_name, int top, string strwhere)
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(channel_name))
            {
                dt = new BLL.article().GetList(channel_name, top, strwhere, "sort_id asc,add_time desc").Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// 文章列表
        /// </summary>
        /// <param name="channel_name">频道名称</param>
        /// <param name="category_id">分类ID</param>
        /// <param name="top">显示条数</param>
        /// <param name="strwhere">查询条件</param>
        /// <returns>DataTable</returns>
        protected DataTable get_article_list(string channel_name, int category_id, int top, string strwhere)
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(channel_name))
            {
                dt = new BLL.article().GetList(channel_name, category_id, top, strwhere, "sort_id asc,add_time desc").Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// 文章列表
        /// </summary>
        /// <param name="channel_name">频道名称</param>
        /// <param name="category_id">分类ID</param>
        /// <param name="top">显示条数</param>
        /// <param name="strwhere">查询条件</param>
        /// <returns>DataTable</returns>
        protected DataTable get_article_list(string channel_name, string category_call, int top, string strwhere)
        {
            int category_id = 0;
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(channel_name))
            {
                if (new BLL.article_category().Exists(category_call))
                {
                    category_id = get_category_model(category_call).id;
                }
                dt = new BLL.article().GetList(channel_name, category_id, top, strwhere, "sort_id asc,add_time desc").Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// 文章列表
        /// </summary>
        /// <param name="channel_name">频道名称</param>
        /// <param name="category_id">分类ID</param>
        /// <param name="top">显示条数</param>
        /// <param name="strwhere">查询条件</param>
        /// <param name="orderby">排序</param>
        /// <returns>DataTable</returns>
        protected DataTable get_article_list(string channel_name, int category_id, int top, string strwhere, string orderby)
        {
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(channel_name))
            {
                dt = new BLL.article().GetList(channel_name, category_id, top, strwhere, orderby).Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// 文章分页列表
        /// </summary>
        /// <param name="channel_name">频道名称</param>
        /// <param name="category_id">分类ID</param>
        /// <param name="page_index">当前页码</param>
        /// <param name="strwhere">查询条件</param>
        /// <param name="totalcount">总记录数</param>
        /// <param name="_key">URL配置名称</param>
        /// <param name="_params">传输参数</param>
        /// <returns>DataTable</returns>
        protected DataTable get_article_list(string channel_name, int category_id, int page_index, string strwhere, out int totalcount, out string pagelist, string _key, params object[] _params)
        {
            DataTable dt = new DataTable();
            int pagesize;
            if (!string.IsNullOrEmpty(channel_name))
            {
                dt = new BLL.article().GetList(channel_name, category_id, page_index, strwhere, "sort_id asc,add_time desc", out totalcount, out pagesize).Tables[0];
                pagelist = Utils.OutPageList(pagesize, page_index, totalcount, linkurl(_key, _params), 8);
            }
            else
            {
                totalcount = 0;
                pagelist = "";
            }
            return dt;
        }
        #endregion

        #region 内容标签======================================
        /// <summary>
        /// 根据ID取得标题
        /// </summary>
        /// <param name="id">调用ID</param>
        /// <returns>String</returns>
        protected string get_article_title(int id)
        {
            if (id < 1)
                return string.Empty;
            BLL.article bll = new BLL.article();
            if (bll.Exists(id))
            {
                return bll.GetModel(id).title;
            }
            return string.Empty;
        }
        /// <summary>
        /// 根据调用标识取得内容
        /// </summary>
        /// <param name="call_index">调用别名</param>
        /// <returns>String</returns>
        protected string get_article_content(string call_index)
        {
            if (string.IsNullOrEmpty(call_index))
                return string.Empty;
            BLL.article bll = new BLL.article();
            if (bll.Exists(call_index))
            {
                return bll.GetModel(call_index).content;
            }
            return string.Empty;
        }
        /// <summary>
        /// 根据调用标识取得内容
        /// </summary>
        /// <param name="call_index">调用别名</param>
        /// <returns>String</returns>
        protected string get_article_zhaiyao(string call_index)
        {
            if (string.IsNullOrEmpty(call_index))
                return string.Empty;
            BLL.article bll = new BLL.article();
            if (bll.Exists(call_index))
            {
                return bll.GetModel(call_index).zhaiyao;
            }
            return string.Empty;
        }
        /// <summary>
        /// 根据ID取得实体类
        /// </summary>
        /// <param name="id">调用ID</param>
        /// <returns>String</returns>
        protected Model.article get_article_model(int id)
        {
            if (id < 1)
                return null;
            BLL.article bll = new BLL.article();
            if (bll.Exists(id))
            {
                return bll.GetModel(id);
            }
            return null;
        }
        /// <summary>
        /// 根据调用标识取得实体类
        /// </summary>
        /// <param name="id">调用别名</param>
        /// <returns>String</returns>
        protected Model.article get_article_model(string call_index)
        {
            if (string.IsNullOrEmpty(call_index))
                return null;
            BLL.article bll = new BLL.article();
            if (bll.Exists(call_index))
            {
                return bll.GetModel(call_index);
            }
            return null;
        }

        /// <summary>
        /// 获取扩展字段的值
        /// </summary>
        /// <param name="article_id">内容ID</param>
        /// <param name="field_name">扩展字段名</param>
        /// <returns>String</returns>
        protected string get_article_field(int article_id, string field_name)
        {
            Model.article model = new BLL.article().GetModel(article_id);
            if (model != null && model.fields.ContainsKey(field_name))
            {
                return model.fields[field_name];
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取扩展字段的值
        /// </summary>
        /// <param name="call_index">调用别名</param>
        /// <param name="field_name">扩展字段名</param>
        /// <returns>String</returns>
        protected string get_article_field(string call_index, string field_name)
        {
            if (string.IsNullOrEmpty(call_index))
                return string.Empty;
            BLL.article bll = new BLL.article();
            if (!bll.Exists(call_index))
            {
                return string.Empty;
            }
            Model.article model = bll.GetModel(call_index);
            if (model != null && model.fields.ContainsKey(field_name))
            {
                return model.fields[field_name];
            }
            return string.Empty;
        }

        /// <summary>
        /// 解析多规格参数字段
        /// </summary>
        /// <param name="field_value">规格类数组</param>
        /// <returns></returns>
        protected DataTable get_article_field_prop(string field_value)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name", Type.GetType("System.String"));
            dt.Columns.Add("value", Type.GetType("System.String"));

            if (!string.IsNullOrEmpty(field_value))
            {
                string[] proplist = field_value.Split(',');
                foreach (string prop in proplist)
                {
                    if (prop.IndexOf('|') > 0)
                    {
                        DataRow dr = dt.NewRow();
                        dr["name"] = prop.Split('|')[0]; //名称
                        dr["value"] = prop.Split('|')[1]; //参数
                        dt.Rows.Add(dr);
                    }
                }
                return dt;
            }
            return null;
        }

        /// <summary>
        /// 根据ID及下标获取相应属性标题
        /// </summary>
        /// <param name="article_id"></param>
        /// <param name="index_of"></param>
        /// <returns></returns>
        protected string get_article_field_prop_title(int article_id, string field_value, int index_of)
        {
            Model.article model = new BLL.article().GetModel(article_id);
            if (model == null) return "";
            DataTable dt = get_article_field_prop(model.fields[field_value]);
            return dt.Rows[index_of]["name"].ToString();
        }
        #endregion
        #region 相册通用方法
        protected List<Model.article_albums> get_artice_albums(int id)
        {
            List<Model.article_albums> ls = new List<Model.article_albums>();
            BLL.article bll = new BLL.article();
            if (bll.Exists(id))
            {
                return bll.GetModel(id).albums;

            }
            return ls;

        }

        #endregion
        #region 附件通用方法==========================================
        protected List<Model.article_attach> get_artice_attach(int id)
        {
            List<Model.article_attach> ls = new List<Model.article_attach>();
            BLL.article bll = new BLL.article();
            if (bll.Exists(id))
            {
                return bll.GetModel(id).attach;

            }
            return ls;

        }

        #endregion

        #region 购物标签======================================
        /// <summary>
        /// 返回相应的图片
        /// </summary>
        /// <param name="article_id">信息ID</param>
        /// <returns>String</returns>
        protected string get_article_img_url(int article_id)
        {
            Model.article model = new BLL.article().GetModel(article_id);
            if (model != null)
            {
                return model.img_url;
            }
            return "";
        }

        /// <summary>
        /// 返回对应商品的会员价格
        /// </summary>
        /// <param name="article_id">信息ID</param>
        /// <returns>Decimal</returns>
        protected decimal get_user_article_price(int article_id)
        {
            Model.users userModel = GetUserInfo();
            if (userModel == null)
            {
                return -1;
            }
            Model.article model = new BLL.article().GetModel(article_id);
            if (model != null)
            {
                if (model.group_price != null)
                {
                    Model.user_group_price priceModel = model.group_price.Find(p => p.group_id == userModel.group_id);
                    if (priceModel != null)
                    {
                        return priceModel.price;
                    }
                }
                if (model.fields.ContainsKey("sell_price"))
                {
                    return Utils.StrToDecimal(model.fields["sell_price"], -1);
                }
            }
            return -1;
        }
        #endregion

        /// <summary>
        /// 获取附件--下载
        /// </summary>
        /// <param name="article_id"></param>
        /// <returns></returns>
        protected string get_first_attach(int article_id)
        {
            return new BLL.article_attach().GetFirstPath(article_id);
        }

    }
}
