using System.Web;

namespace QJcms.Common
{
    public class QJKey
    {
        #region 数据库链接======================================
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                if (DatabaseType == "1")
                {
                    if (HttpContext.Current.Application["QJcms_dbPath"] == null)
                    {
                        string dbPath = HttpContext.Current.Server.MapPath(XmlHelper.LoadConfig("~/xmlconfig/conn", "dbPath"));
                        string dbLoginPass = XmlHelper.LoadConfig("~/xmlconfig/conn", "dbLoginPass");
                        string dbConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbPath + ";Jet OLEDB:Database PassWord=" + DESEncrypt.Decrypt(dbLoginPass);
                        HttpContext.Current.Application.Lock();
                        HttpContext.Current.Application["QJcms_dbPath"] = dbConnStr;
                        HttpContext.Current.Application.UnLock();
                    }
                    return HttpContext.Current.Application["QJcms_dbPath"].ToString();
                }
                else
                {
                    if (HttpContext.Current.Application["QJcms_dbConnStr"] == null)
                    {
                        string dbServerIP = XmlHelper.LoadConfig("~/xmlconfig/conn", "dbServerIP");
                        string dbLoginName = XmlHelper.LoadConfig("~/xmlconfig/conn", "dbLoginName");
                        string dbLoginPass = XmlHelper.LoadConfig("~/xmlconfig/conn", "dbLoginPass");
                        string dbName = XmlHelper.LoadConfig("~/xmlconfig/conn", "dbName");
                        string dbConnStr = "server=127.0.0.1;uid=" + dbLoginName + ";pwd=" + DESEncrypt.Decrypt(dbLoginPass) + ";database=QJcms;Provider=SQLOLEDB;";
                        HttpContext.Current.Application.Lock();
                        HttpContext.Current.Application["QJcms_dbConnStr"] = dbConnStr;
                        HttpContext.Current.Application.UnLock();
                    }
                    return HttpContext.Current.Application["QJcms_dbConnStr"].ToString();
                }
            }
        }
        /// <summary>
        ///  数据库类型:0代表Access，1代表SqlServer
        /// </summary>
        public static string DatabaseType
        {
            get
            {
                if (System.Web.HttpContext.Current.Application["QJcms_dbType"] == null)
                {
                    System.Web.HttpContext.Current.Application.Lock();
                    System.Web.HttpContext.Current.Application["QJcms_dbType"] = XmlHelper.LoadConfig("~/xmlconfig/conn", "dbType");
                    System.Web.HttpContext.Current.Application.UnLock();
                }
                return System.Web.HttpContext.Current.Application["QJcms_dbType"].ToString();
            }
        }
        /// <summary>
        /// 数据表前缀
        /// </summary>
        public static string DatabasePrefix
        {
            get
            {
                if (System.Web.HttpContext.Current.Application["QJcms_dbPrefix"] == null)
                {
                    System.Web.HttpContext.Current.Application.Lock();
                    System.Web.HttpContext.Current.Application["QJcms_dbPrefix"] = XmlHelper.LoadConfig("~/xmlconfig/conn", "dbPrefix");
                    System.Web.HttpContext.Current.Application.UnLock();
                }
                return System.Web.HttpContext.Current.Application["QJcms_dbPrefix"].ToString();
            }
        }
        /// <summary>
        /// access数据库路径
        /// </summary>
        public static string dbPathAcc
        {
            get
            {
                string dbPath = HttpContext.Current.Server.MapPath(XmlHelper.LoadConfig("~/xmlconfig/conn", "dbPath"));
                return dbPath;
            }
        }
        /// <summary>
        /// access数据库密码
        /// </summary>
        public static string dbPwdAcc
        {
            get
            {
                string dbLoginPass = XmlHelper.LoadConfig("~/xmlconfig/conn", "dbLoginPass");
                return dbLoginPass;
            }
        }
        #endregion
    }
}
