using QJcms.Common;
using QJcms.DBUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace QJcms.DAL
{
    /// <summary>
    /// 数据访问类:seo_list
    /// </summary>
    public partial class seo_list
    {
        private string databaseprefix; //数据库表名前缀
        public seo_list(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        #region  Method
        /// <summary>
        /// 得到最大ID
        /// </summary>
        private int GetMaxId(SqlConnection conn, SqlTransaction trans)
        {
            string strSql = "select top 1 id from " + databaseprefix + "seo_list order by id desc";
            object obj = DbHelperSQL.GetSingle(conn, trans, strSql);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "seo_list");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.seo_list model)
        {
            int newId;
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into " + databaseprefix + "seo_list(");
                        strSql.Append("call_index,title,seo_title,seo_keywords,seo_description)");
                        strSql.Append(" values (");
                        strSql.Append("@call_index,@title,@seo_title,@seo_keywords,@seo_description)");
                        SqlParameter[] parameters = {
					        new SqlParameter("@call_index", SqlDbType.NVarChar,50),
					        new SqlParameter("@title", SqlDbType.NVarChar,100),
					        new SqlParameter("@seo_title", SqlDbType.NVarChar,255),
					        new SqlParameter("@seo_keywords", SqlDbType.NVarChar,255),
					        new SqlParameter("@seo_description", SqlDbType.NVarChar,255)};
                        parameters[0].Value = model.call_index;
                        parameters[1].Value = model.title;
                        parameters[2].Value = model.seo_title;
                        parameters[3].Value = model.seo_keywords;
                        parameters[4].Value = model.seo_description;

                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);
                        //取得新插入的ID
                        newId = GetMaxId(conn, trans);
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return 0;
                    }
                }
            }
            return newId;
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "seo_list set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.seo_list model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "seo_list set ");
            strSql.Append("call_index=@call_index,");
            strSql.Append("title=@title,");
            strSql.Append("seo_title=@seo_title,");
            strSql.Append("seo_keywords=@seo_keywords,");
            strSql.Append("seo_description=@seo_description");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@call_index", SqlDbType.NVarChar,50),
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@seo_title", SqlDbType.NVarChar,255),
					new SqlParameter("@seo_keywords", SqlDbType.NVarChar,255),
					new SqlParameter("@seo_description", SqlDbType.NVarChar,255),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.call_index;
            parameters[1].Value = model.title;
            parameters[2].Value = model.seo_title;
            parameters[3].Value = model.seo_keywords;
            parameters[4].Value = model.seo_description;
            parameters[5].Value = model.id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "seo_list ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.seo_list GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,call_index,title,seo_title,seo_keywords,seo_description from " + databaseprefix + "seo_list ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.seo_list model = new Model.seo_list();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["call_index"] != null && ds.Tables[0].Rows[0]["call_index"].ToString() != "")
                {
                    model.call_index = ds.Tables[0].Rows[0]["call_index"].ToString();
                }
                if (ds.Tables[0].Rows[0]["title"] != null && ds.Tables[0].Rows[0]["title"].ToString() != "")
                {
                    model.title = ds.Tables[0].Rows[0]["title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["seo_title"] != null && ds.Tables[0].Rows[0]["seo_title"].ToString() != "")
                {
                    model.seo_title = ds.Tables[0].Rows[0]["seo_title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["seo_keywords"] != null && ds.Tables[0].Rows[0]["seo_keywords"].ToString() != "")
                {
                    model.seo_keywords = ds.Tables[0].Rows[0]["seo_keywords"].ToString();
                }
                if (ds.Tables[0].Rows[0]["seo_description"] != null && ds.Tables[0].Rows[0]["seo_description"].ToString() != "")
                {
                    model.seo_description = ds.Tables[0].Rows[0]["seo_description"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.seo_list GetModel(string call_index)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,call_index,title,seo_title,seo_keywords,seo_description from " + databaseprefix + "seo_list ");
            strSql.Append(" where call_index=@call_index");
            SqlParameter[] parameters = {
					new SqlParameter("@call_index", SqlDbType.NVarChar,50)};
            parameters[0].Value = call_index;

            Model.seo_list model = new Model.seo_list();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["call_index"] != null && ds.Tables[0].Rows[0]["call_index"].ToString() != "")
                {
                    model.call_index = ds.Tables[0].Rows[0]["call_index"].ToString();
                }
                if (ds.Tables[0].Rows[0]["title"] != null && ds.Tables[0].Rows[0]["title"].ToString() != "")
                {
                    model.title = ds.Tables[0].Rows[0]["title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["seo_title"] != null && ds.Tables[0].Rows[0]["seo_title"].ToString() != "")
                {
                    model.seo_title = ds.Tables[0].Rows[0]["seo_title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["seo_keywords"] != null && ds.Tables[0].Rows[0]["seo_keywords"].ToString() != "")
                {
                    model.seo_keywords = ds.Tables[0].Rows[0]["seo_keywords"].ToString();
                }
                if (ds.Tables[0].Rows[0]["seo_description"] != null && ds.Tables[0].Rows[0]["seo_description"].ToString() != "")
                {
                    model.seo_description = ds.Tables[0].Rows[0]["seo_description"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,call_index,title,seo_title,seo_keywords,seo_description ");
            strSql.Append(" FROM " + databaseprefix + "seo_list ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,call_index,title,seo_title,seo_keywords,seo_description ");
            strSql.Append(" FROM " + databaseprefix + "seo_list ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by id asc");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM " + databaseprefix + "seo_list");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        #endregion  Method
    }
}
