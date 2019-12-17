using System;
using System.Collections.Generic;
using System.Text;
using QJcms.Common;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace QJcms.DBUtility
{
    /// <summary>
    /// 数据库链接配置类
    /// </summary>
    public class DbHelper
    {
        public static string connectionString = QJKey.ConnectionString;
        public string DBType = QJKey.DatabaseType;
        /// <summary>
        /// 根据配置信息链接Access或SQL数据库
        /// </summary>
        /// <returns>0：链接Access数据库 1：链接SQL数据库</returns>
        public DbOperHandler Doh()
        {
            if (DBType == "0")
            {
                return new OleDbOperHandler(new OleDbConnection(connectionString));
            }
            else
            {
                return new SqlDbOperHandler(new SqlConnection(connectionString));
            }
        }
    }
}
