using System;
using System.Collections.Generic;
using System.Text;

namespace QJcms.Model
{
    /// <summary>
    /// 全国城市三联动 - 市
    /// </summary>
    [Serializable]
    public partial class city
    {
        public city() { }

        #region Model
        private int _id;
        private string _city_name;
        private string _zipcode;
        private int _province_id;
        private int _is_lock;

        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 名称（市）
        /// </summary>
        public string city_name
        {
            set { _city_name = value; }
            get { return _city_name; }
        }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string zipcode
        {
            set { _zipcode = value; }
            get { return _zipcode; }
        }
        /// <summary>
        /// 省 ID
        /// </summary>
        public int province_id
        {
            set { _province_id = value; }
            get { return _province_id; }
        }
        /// <summary>
        /// 0：正常 1：锁定（锁定后不显示）
        /// </summary>
        public int is_lock
        {
            set { _is_lock = value; }
            get { return _is_lock; }
        }
        #endregion
    }
}
