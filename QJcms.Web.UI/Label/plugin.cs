using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QJcms.Web.UI
{
    public partial class BasePage : System.Web.UI.Page
    {
        /// <summary>
        /// 利用反射调用插件方法
        /// </summary>
        /// <param name="className">类名</param>
        /// <param name="methodName">方法名</param>
        /// <param name="objParas">参数</param>
        /// <returns>DataTable</returns>
        public DataTable get_plugin_method(string assemblyName, string className, string methodName, params object[] objParas)
        {
            DataTable dt = new DataTable();
            try
            {
                Assembly assembly = Assembly.Load(assemblyName);
                object obj = assembly.CreateInstance(assemblyName + "." + className);
                Type t = obj.GetType();
                //查找匹配的方法
                foreach (MethodInfo m in t.GetMethods(BindingFlags.Instance | BindingFlags.Public))
                {
                    if (m.Name == methodName && m.GetParameters().Length == objParas.Length)
                    {
                        object obj2 = m.Invoke(obj, objParas);
                        dt = obj2 as DataTable;
                        return dt;
                    }
                }
            }
            catch
            {
                //插件方法获取失败
            }
            return dt;
        }


        #region 友情链接
        /// <summary>
        /// 友情链接列表
        /// </summary>
        /// <param name="top">显示条数</param>
        /// <param name="strwhere">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable get_link_list(int top, string strwhere)
        {
            DataTable dt = new DataTable();
            string _where = "is_lock=0";
            if (!string.IsNullOrEmpty(strwhere))
            {
                _where += " and " + strwhere;
            }
            dt = new BLL.link().GetList(top, _where).Tables[0];
            return dt;
        }

        /// <summary>
        /// 图文分页列表
        /// </summary>
        /// <param name="page_size">页面大小</param>
        /// <param name="page_index">当前页码</param>
        /// <param name="strwhere">查询条件</param>
        /// <param name="totalcount">总记录数</param>
        /// <returns>DateTable</returns>
        public DataTable get_link_list(int page_size, int page_index, string strwhere, out int totalcount)
        {
            DataTable dt = new DataTable();
            string _where = "is_lock=0";
            if (!string.IsNullOrEmpty(strwhere))
            {
                _where += " and " + strwhere;
            }
            dt = new BLL.link().GetList(page_size, page_index, _where, "sort_id asc,add_time desc", out totalcount).Tables[0];
            return dt;
        }
        #endregion

        #region 统计代码
        /// <summary>
        /// 统计代码列表
        /// </summary>
        /// <param name="top">显示条数</param>
        /// <param name="strwhere">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable get_script_list(int top, string strwhere)
        {
            DataTable dt = new DataTable();
            string _where = "is_lock=0";
            if (!string.IsNullOrEmpty(strwhere))
            {
                _where += " and " + strwhere;
            }
            dt = new BLL.script_list().GetList(top, _where).Tables[0];
            return dt;
        }
        #endregion

        #region SEO优化
        public string get_seo_body(string call_index)
        {
            string str = "";
            Model.seo_list model = new BLL.seo_list().GetModel(call_index);
            str += "<title>" + model.seo_title + "</title>\r\n";
            str += "<meta name=\"keywords\" content=\"" + model.seo_keywords + "\" />\r\n";
            str += "<meta name=\"description\" content=\"" + model.seo_description + "\" />";
            return str;
        }
        #endregion

        #region 搜索关键词
        /// <summary>
        /// 关键词列表
        /// </summary>
        /// <param name="top">显示条数</param>
        /// <param name="strwhere">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable get_search_keyword_list(int top, string strwhere)
        {
            DataTable dt = new DataTable();
            string _where = "is_lock=0";
            if (!string.IsNullOrEmpty(strwhere))
            {
                _where += " and " + strwhere;
            }
            dt = new BLL.search_keyword().GetList(top, _where).Tables[0];
            return dt;
        }
        #endregion
    }
}
