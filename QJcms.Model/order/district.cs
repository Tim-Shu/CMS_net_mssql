using System;
using System.Collections.Generic;
using System.Text;

namespace QJcms.Model
{
    /// <summary>
    /// 全国城市三联动 - 区
    /// </summary>
    [Serializable]
    public partial class district
    {
        public district() { }

        #region Model
        private int _id;
        private string _district_name;
        private int _city_id;
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
        /// 名称（区）
        /// </summary>
        public string district_name
        {
            set { _district_name = value; }
            get { return _district_name; }
        }
        /// <summary>
        /// 市 ID
        /// </summary>
        public int city_id
        {
            set { _city_id = value; }
            get { return _city_id; }
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
