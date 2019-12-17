using System;
using System.Collections.Generic;
using System.Text;

namespace QJcms.Model
{
    /// <summary>
    /// 搜索关键词实体类
    /// </summary>
    [Serializable]
    public partial class search_keyword
    {
        public search_keyword()
        { }
        #region Model
        private int _id;
        private string _title;
        private string _link_url;
        private string _target;
        private int _is_lock;
        private int _is_top;
        private int _sort_id;

        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 标题文字
        /// </summary>
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }
        /// <summary>
        /// 链接地址
        /// </summary>
        public string link_url
        {
            get { return _link_url; }
            set { _link_url = value; }
        }
        /// <summary>
        /// 打开窗口方式
        /// </summary>
        public string target
        {
            get { return _target; }
            set { _target = value; }
        }
        /// <summary>
        /// 锁定0：正常 1：锁（锁定后不显示）
        /// </summary>
        public int is_lock
        {
            get { return _is_lock; }
            set { _is_lock = value; }
        }
        /// <summary>
        /// 置顶
        /// </summary>
        public int is_top
        {
            get { return _is_top; }
            set { _is_top = value; }
        }
        /// <summary>
        /// 排序数字（数字越小越靠前）
        /// </summary>
        public int sort_id
        {
            get { return _sort_id; }
            set { _sort_id = value; }
        }
        #endregion
    }
}
