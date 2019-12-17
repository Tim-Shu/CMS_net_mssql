using System;
using System.Collections.Generic;
using System.Text;

namespace QJcms.Model
{
    /// <summary>
    /// 类别图册
    /// </summary>
    [Serializable]
    public partial class article_category_albums
    {
        public article_category_albums()
        { }
        #region Model
        private int _id;
        private int _category_id = 0;
        private string _thumb_path = "";
        private string _original_path = "";
        private string _remark = "";
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
        /// 类别ID
        /// </summary>
        public int category_id
        {
            set { _category_id = value; }
            get { return _category_id; }
        }
        /// <summary>
        /// 缩略图地址
        /// </summary>
        public string thumb_path
        {
            set { _thumb_path = value; }
            get { return _thumb_path; }
        }
        /// <summary>
        /// 原图地址
        /// </summary>
        public string original_path
        {
            set { _original_path = value; }
            get { return _original_path; }
        }
        /// <summary>
        /// 图片描述
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        #endregion Model
    }
}
