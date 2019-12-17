using System;
namespace QJcms.Model
{
    /// <summary>
    /// 邮件模板
    /// </summary>
    [Serializable]
    public partial class mail_template
    {
        public mail_template()
        { }
        #region Model
        private int _id;
        private string _title = "";
        private string _call_index = "";
        private string _mail_title = "";
        private string _content = "";
        private int _is_sys = 0;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 标题名称
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 调用别名
        /// </summary>
        public string call_index
        {
            set { _call_index = value; }
            get { return _call_index; }
        }
        /// <summary>
        /// 邮件标题
        /// </summary>
        public string mail_title
        {
            set { _mail_title = value; }
            get { return _mail_title; }
        }
        /// <summary>
        /// 邮件内容
        /// </summary>
        public string content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 系统默认
        /// </summary>
        public int is_sys
        {
            set { _is_sys = value; }
            get { return _is_sys; }
        }
        #endregion Model
    }
}