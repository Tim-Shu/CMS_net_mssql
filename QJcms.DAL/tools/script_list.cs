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
    /// 数据访问类:script_list
    /// </summary>
    public partial class script_list
    {
        private string databaseprefix; //数据库表名前缀
        public script_list(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        #region  Method
        /// <summary>
        /// 得到最大ID
        /// </summary>
        private int GetMaxId(SqlConnection conn, SqlTransaction trans)
        {
            string strSql = "select top 1 id from " + databaseprefix + "script_list order by id desc";
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
            strSql.Append("select count(1) from " + databaseprefix + "script_list");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.script_list model)
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
                        strSql.Append("insert into " + databaseprefix + "script_list(");
                        strSql.Append("title,content,user_name,login_ip,login_time,login_history,sort_id,is_lock,add_time)");
                        strSql.Append(" values (");
                        strSql.Append("@title,@content,@user_name,@login_ip,@login_time,@login_history,@sort_id,@is_lock,@add_time)");

                        SqlParameter[] parameters = {
					        new SqlParameter("@title", SqlDbType.NVarChar,100),
					        new SqlParameter("@content", SqlDbType.NVarChar),
					        new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					        new SqlParameter("@login_ip", SqlDbType.NVarChar,30),
					        new SqlParameter("@login_time", SqlDbType.DateTime),
					        new SqlParameter("@login_history", SqlDbType.NVarChar),
					        new SqlParameter("@sort_id", SqlDbType.Int,4),
					        new SqlParameter("@is_lock", SqlDbType.Int,4),
					        new SqlParameter("@add_time", SqlDbType.DateTime)};
                        parameters[0].Value = model.title;
                        parameters[1].Value = model.content;
                        parameters[2].Value = model.user_name;
                        parameters[3].Value = model.login_ip;
                        parameters[4].Value = model.login_time;
                        parameters[5].Value = model.login_history;
                        parameters[6].Value = model.sort_id;
                        parameters[7].Value = model.is_lock;
                        parameters[8].Value = model.add_time;

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
            strSql.Append("update " + databaseprefix + "script_list set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.script_list model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "script_list set ");
            strSql.Append("title=@title,");
            strSql.Append("content=@content,");
            strSql.Append("user_name=@user_name,");
            strSql.Append("login_ip=@login_ip,");
            strSql.Append("login_time=@login_time,");
            strSql.Append("login_history=@login_history,");
            strSql.Append("sort_id=@sort_id,");
            strSql.Append("is_lock=@is_lock,");
            strSql.Append("add_time=@add_time");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@content", SqlDbType.NVarChar),
					new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					new SqlParameter("@login_ip", SqlDbType.NVarChar,30),
					new SqlParameter("@login_time", SqlDbType.DateTime),
					new SqlParameter("@login_history", SqlDbType.NVarChar),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@is_lock", SqlDbType.Int,4),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.content;
            parameters[2].Value = model.user_name;
            parameters[3].Value = model.login_ip;
            parameters[4].Value = model.login_time;
            parameters[5].Value = model.login_history;
            parameters[6].Value = model.sort_id;
            parameters[7].Value = model.is_lock;
            parameters[8].Value = model.add_time;
            parameters[9].Value = model.id;

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
            strSql.Append("delete from " + databaseprefix + "script_list ");
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
        public Model.script_list GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,title,content,user_name,login_ip,login_time,login_history,sort_id,is_lock,add_time from " + databaseprefix + "script_list ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.script_list model = new Model.script_list();
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
                if (ds.Tables[0].Rows[0]["content"] != null && ds.Tables[0].Rows[0]["content"].ToString() != "")
                {
                    model.content = ds.Tables[0].Rows[0]["content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_name"] != null && ds.Tables[0].Rows[0]["user_name"].ToString() != "")
                {
                    model.user_name = ds.Tables[0].Rows[0]["user_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["login_ip"] != null && ds.Tables[0].Rows[0]["login_ip"].ToString() != "")
                {
                    model.login_ip = ds.Tables[0].Rows[0]["login_ip"].ToString();
                }
                if (ds.Tables[0].Rows[0]["login_time"] != null && ds.Tables[0].Rows[0]["login_time"].ToString() != "")
                {
                    model.login_time = DateTime.Parse(ds.Tables[0].Rows[0]["login_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["login_history"] != null && ds.Tables[0].Rows[0]["login_history"].ToString() != "")
                {
                    model.login_history = ds.Tables[0].Rows[0]["login_history"].ToString();
                }
                if (ds.Tables[0].Rows[0]["sort_id"] != null && ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_lock"] != null && ds.Tables[0].Rows[0]["is_lock"].ToString() != "")
                {
                    model.is_lock = int.Parse(ds.Tables[0].Rows[0]["is_lock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_time"] != null && ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
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
            strSql.Append("select id,title,content,user_name,login_ip,login_time,login_history,sort_id,is_lock,add_time ");
            strSql.Append(" FROM " + databaseprefix + "script_list ");
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
            strSql.Append(" id,title,content,user_name,login_ip,login_time,login_history,sort_id,is_lock,add_time ");
            strSql.Append(" FROM " + databaseprefix + "script_list ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by sort_id asc,add_time desc");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM " + databaseprefix + "script_list");
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
