using System;
using System.Collections.Generic;
using System.Text;

namespace QJcms.Model
{
    /// <summary>
    /// 关键词优化实体类
    /// </summary>
    [Serializable]
    public partial class seo_list
    {
        public seo_list()
        { }
        #region Model
        private int _id;
        private string _call_index;
        private string _title;
        private string _seo_title;
        private string _seo_keywords;
        private string _seo_description;

        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 调用名称
        /// </summary>
        public string call_index
        {
            set { _call_index = value; }
            get { return _call_index; }
        }
        /// <summary>
        /// 说明标题
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 优化标题
        /// </summary>
        public string seo_title
        {
            set { _seo_title = value; }
            get { return _seo_title; }
        }
        /// <summary>
        /// 优化关键词
        /// </summary>
        public string seo_keywords
        {
            set { _seo_keywords = value; }
            get { return _seo_keywords; }
        }
        /// <summary>
        /// 优化描述
        /// </summary>
        public string seo_description
        {
            set { _seo_description = value; }
            get { return _seo_description; }
        }
        #endregion Model
    }
}
