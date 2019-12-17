using System;
using System.Collections.Generic;
using System.Text;

namespace QJcms.Model
{
    /// <summary>
    /// 统计代码实体类
    /// </summary>
    [Serializable]
    public partial class script_list
    {
        public script_list()
        { }
        #region Model
        private int _id;
        private string _title;
        private string _content;
        private string _user_name;
        private string _login_ip;
        private DateTime _login_time = DateTime.Now;
        private string _login_history;
        private int _sort_id = 99;
        private int _is_lock;
        private DateTime _add_time = DateTime.Now;

        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
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
        /// 代码内容
        /// </summary>
        public string content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 操作用户
        /// </summary>
        public string user_name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        /// <summary>
        /// 操作IP
        /// </summary>
        public string login_ip
        {
            set { _login_ip = value; }
            get { return _login_ip; }
        }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime login_time
        {
            set { _login_time = value; }
            get { return _login_time; }
        }
        /// <summary>
        /// 操作历史
        /// </summary>
        public string login_history
        {
            set { _login_history = value; }
            get { return _login_history; }
        }
        /// <summary>
        /// 调用顺序
        /// </summary>
        public int sort_id
        {
            set { _sort_id = value; }
            get { return _sort_id; }
        }
        /// <summary>
        /// 审核结果 1:未审核 不显示 0:已审核 显示
        /// </summary>
        public int is_lock
        {
            set { _is_lock = value; }
            get { return _is_lock; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        #endregion Model
    }
}
