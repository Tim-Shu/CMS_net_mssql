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
    /// 数据访问类:search_keyword
    /// </summary>
    public partial class search_keyword
    {
        private string databaseprefix; //数据库表名前缀
        public search_keyword(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }
        #region  Method
        /// <summary>
        /// 得到最大ID
        /// </summary>
        private int GetMaxId(SqlConnection conn, SqlTransaction trans)
        {
            string strSql = "select top 1 id from " + databaseprefix + "search_keyword order by id desc";
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
            strSql.Append("select count(1) from " + databaseprefix + "search_keyword");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.search_keyword model)
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
                        strSql.Append("insert into " + databaseprefix + "search_keyword(");
                        strSql.Append("title,link_url,target,is_lock,is_top,sort_id)");
                        strSql.Append(" values (");
                        strSql.Append("@title,@link_url,@target,@is_lock,@is_top,@sort_id)");

                        SqlParameter[] parameters = {
					        new SqlParameter("@title", SqlDbType.NVarChar,100),
					        new SqlParameter("@link_url", SqlDbType.NVarChar,255),
					        new SqlParameter("@target", SqlDbType.NVarChar,50),
					        new SqlParameter("@is_lock", SqlDbType.Int,4),
					        new SqlParameter("@is_top", SqlDbType.Int,4),
					        new SqlParameter("@sort_id", SqlDbType.Int,4)};
                        parameters[0].Value = model.title;
                        parameters[1].Value = model.link_url;
                        parameters[2].Value = model.target;
                        parameters[3].Value = model.is_lock;
                        parameters[4].Value = model.is_top;
                        parameters[5].Value = model.sort_id;

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
            strSql.Append("update " + databaseprefix + "search_keyword set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.search_keyword model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "search_keyword set ");
            strSql.Append("title=@title,");
            strSql.Append("link_url=@link_url,");
            strSql.Append("target=@target,");
            strSql.Append("is_lock=@is_lock,");
            strSql.Append("is_top=@is_top,");
            strSql.Append("sort_id=@sort_id");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@link_url", SqlDbType.NVarChar,255),
					new SqlParameter("@target", SqlDbType.NVarChar,50),
					new SqlParameter("@is_lock", SqlDbType.Int,4),
					new SqlParameter("@is_top", SqlDbType.Int,4),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.link_url;
            parameters[2].Value = model.target;
            parameters[3].Value = model.is_lock;
            parameters[4].Value = model.is_top;
            parameters[5].Value = model.sort_id;
            parameters[6].Value = model.id;

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
            strSql.Append("delete from " + databaseprefix + "search_keyword ");
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
        public Model.search_keyword GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,title,link_url,target,is_lock,is_top,sort_id from " + databaseprefix + "search_keyword ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.search_keyword model = new Model.search_keyword();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["title"] != null && ds.Tables[0].Rows[0]["title"].ToString() != "")
                {
                    model.title = ds.Tables[0].Rows[0]["title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["link_url"] != null && ds.Tables[0].Rows[0]["link_url"].ToString() != "")
                {
                    model.link_url = ds.Tables[0].Rows[0]["link_url"].ToString();
                }
                if (ds.Tables[0].Rows[0]["target"] != null && ds.Tables[0].Rows[0]["target"].ToString() != "")
                {
                    model.target = ds.Tables[0].Rows[0]["target"].ToString();
                }
                if (ds.Tables[0].Rows[0]["is_lock"] != null && ds.Tables[0].Rows[0]["is_lock"].ToString() != "")
                {
                    model.is_lock = int.Parse(ds.Tables[0].Rows[0]["is_lock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_top"] != null && ds.Tables[0].Rows[0]["is_top"].ToString() != "")
                {
                    model.is_top = int.Parse(ds.Tables[0].Rows[0]["is_top"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sort_id"] != null && ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
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
            strSql.Append("select id,title,link_url,target,is_lock,is_top,sort_id ");
            strSql.Append(" FROM " + databaseprefix + "search_keyword ");
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
            strSql.Append(" id,title,link_url,target,is_lock,is_top,sort_id ");
            strSql.Append(" FROM " + databaseprefix + "search_keyword ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by sort_id asc");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM " + databaseprefix + "search_keyword");
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
