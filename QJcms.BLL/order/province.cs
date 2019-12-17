using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QJcms.Common;

namespace QJcms.BLL
{
    /// <summary>
    /// 全国城市三联动 - 省
    /// </summary>
    public partial class province
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息
        private readonly DAL.province dal;

        public province()
        {
            dal = new DAL.province(QJKey.DatabasePrefix);
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.province GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
    }
}
