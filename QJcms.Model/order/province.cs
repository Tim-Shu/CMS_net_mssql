using System;
using System.Collections.Generic;
using System.Text;

namespace QJcms.Model
{
    /// <summary>
    /// 全国城市三联动 - 省
    /// </summary>
    [Serializable]
    public partial class province
    {
        public province() { }

        #region Model
        private int _id;
        private string _province_name;
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
        /// 名称（省）
        /// </summary>
        public string province_name
        {
            set { _province_name = value; }
            get { return _province_name; }
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
