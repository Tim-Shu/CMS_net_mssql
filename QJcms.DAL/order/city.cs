using QJcms.Common;
using QJcms.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace QJcms.DAL
{
    /// <summary>
    /// 数据访问类:全国城市三联动 - 市
    /// </summary>
    public partial class city
    {
        private string databaseprefix; //数据库表名前缀
        public city(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "city set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.city GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,city_name,zipcode,province_id,is_lock from " + databaseprefix + "city ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.city model = new Model.city();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.city_name = ds.Tables[0].Rows[0]["city_name"].ToString();
                model.zipcode = ds.Tables[0].Rows[0]["zipcode"].ToString();
                if (ds.Tables[0].Rows[0]["province_id"].ToString() != "")
                {
                    model.province_id = int.Parse(ds.Tables[0].Rows[0]["province_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_lock"].ToString() != "")
                {
                    model.is_lock = int.Parse(ds.Tables[0].Rows[0]["is_lock"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,city_name,zipcode,province_id,is_lock ");
            strSql.Append(" FROM " + databaseprefix + "city ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by " + filedOrder);
            }
            else strSql.Append(" order by id asc");
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
