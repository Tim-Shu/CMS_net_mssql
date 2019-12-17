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
    ///  数据访问类:user_groups
    /// </summary>
    public partial class user_groups
    {
        private string databaseprefix; //数据库表名前缀
        public user_groups(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        #region 基本方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        private int GetMaxId(SqlConnection conn, SqlTransaction trans)
        {
            string strSql = "select top 1 id from " + databaseprefix + "user_groups order by id desc";
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
            strSql.Append("select count(1) from " + databaseprefix + "user_groups");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回标题名称
        /// </summary>
        public string GetTitle(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 title from " + databaseprefix + "user_groups");
            strSql.Append(" where id=" + id);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.user_groups model)
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
                        strSql.Append("insert into " + databaseprefix + "user_groups(");
                        strSql.Append("title,grade,upgrade_exp,amount,point,discount,is_default,is_upgrade,is_lock)");
                        strSql.Append(" values (");
                        strSql.Append("@title,@grade,@upgrade_exp,@amount,@point,@discount,@is_default,@is_upgrade,@is_lock)");
                        SqlParameter[] parameters = {
					        new SqlParameter("@title", SqlDbType.NVarChar,100),
					        new SqlParameter("@grade", SqlDbType.Int,4),
					        new SqlParameter("@upgrade_exp", SqlDbType.Int,4),
					        new SqlParameter("@amount", SqlDbType.Decimal,5),
					        new SqlParameter("@point", SqlDbType.Int,4),
					        new SqlParameter("@discount", SqlDbType.Int,4),
					        new SqlParameter("@is_default", SqlDbType.Int,4),
					        new SqlParameter("@is_upgrade", SqlDbType.Int,4),
					        new SqlParameter("@is_lock", SqlDbType.Int,4)};
                        parameters[0].Value = model.title;
                        parameters[1].Value = model.grade;
                        parameters[2].Value = model.upgrade_exp;
                        parameters[3].Value = model.amount;
                        parameters[4].Value = model.point;
                        parameters[5].Value = model.discount;
                        parameters[6].Value = model.is_default;
                        parameters[7].Value = model.is_upgrade;
                        parameters[8].Value = model.is_lock;
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
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.user_groups model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "user_groups set ");
            strSql.Append("title=@title,");
            strSql.Append("grade=@grade,");
            strSql.Append("upgrade_exp=@upgrade_exp,");
            strSql.Append("amount=@amount,");
            strSql.Append("point=@point,");
            strSql.Append("discount=@discount,");
            strSql.Append("is_default=@is_default,");
            strSql.Append("is_upgrade=@is_upgrade,");
            strSql.Append("is_lock=@is_lock");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@grade", SqlDbType.Int,4),
					new SqlParameter("@upgrade_exp", SqlDbType.Int,4),
					new SqlParameter("@amount", SqlDbType.Decimal,5),
					new SqlParameter("@point", SqlDbType.Int,4),
					new SqlParameter("@discount", SqlDbType.Int,4),
					new SqlParameter("@is_default", SqlDbType.Int,4),
					new SqlParameter("@is_upgrade", SqlDbType.Int,4),
					new SqlParameter("@is_lock", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.grade;
            parameters[2].Value = model.upgrade_exp;
            parameters[3].Value = model.amount;
            parameters[4].Value = model.point;
            parameters[5].Value = model.discount;
            parameters[6].Value = model.is_default;
            parameters[7].Value = model.is_upgrade;
            parameters[8].Value = model.is_lock;
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
            Hashtable sqllist = new Hashtable();
            //删除会员组价格
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("delete from " + databaseprefix + "user_group_price ");
            strSql1.Append(" where group_id=@group_id ");
            SqlParameter[] parameters1 = {
                    new SqlParameter("@group_id", SqlDbType.Int,4)};
            parameters1[0].Value = id;
            sqllist.Add(strSql1.ToString(), parameters1);

            //删除主表
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "user_groups ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            bool result = DbHelperSQL.ExecuteSqlTranbool(sqllist);
            return result;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.user_groups GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,title,grade,upgrade_exp,amount,point,discount,is_default,is_upgrade,is_lock from " + databaseprefix + "user_groups ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            QJcms.Model.user_groups model = new QJcms.Model.user_groups();
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
                if (ds.Tables[0].Rows[0]["grade"] != null && ds.Tables[0].Rows[0]["grade"].ToString() != "")
                {
                    model.grade = int.Parse(ds.Tables[0].Rows[0]["grade"].ToString());
                }
                if (ds.Tables[0].Rows[0]["upgrade_exp"] != null && ds.Tables[0].Rows[0]["upgrade_exp"].ToString() != "")
                {
                    model.upgrade_exp = int.Parse(ds.Tables[0].Rows[0]["upgrade_exp"].ToString());
                }
                if (ds.Tables[0].Rows[0]["amount"] != null && ds.Tables[0].Rows[0]["amount"].ToString() != "")
                {
                    model.amount = decimal.Parse(ds.Tables[0].Rows[0]["amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["point"] != null && ds.Tables[0].Rows[0]["point"].ToString() != "")
                {
                    model.point = int.Parse(ds.Tables[0].Rows[0]["point"].ToString());
                }
                if (ds.Tables[0].Rows[0]["discount"] != null && ds.Tables[0].Rows[0]["discount"].ToString() != "")
                {
                    model.discount = int.Parse(ds.Tables[0].Rows[0]["discount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_default"] != null && ds.Tables[0].Rows[0]["is_default"].ToString() != "")
                {
                    model.is_default = int.Parse(ds.Tables[0].Rows[0]["is_default"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_upgrade"] != null && ds.Tables[0].Rows[0]["is_upgrade"].ToString() != "")
                {
                    model.is_upgrade = int.Parse(ds.Tables[0].Rows[0]["is_upgrade"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_lock"] != null && ds.Tables[0].Rows[0]["is_lock"].ToString() != "")
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
        /// 取得默认组别实体
        /// </summary>
        public Model.user_groups GetDefault()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id from " + databaseprefix + "user_groups where is_lock=0 order by is_default desc,id asc");
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return GetModel(Convert.ToInt32(obj));
            }
            return null;
        }

        /// <summary>
        /// 根据经验值返回升级的组别实体
        /// </summary>
        public Model.user_groups GetUpgrade(int group_id, int exp)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id from " + databaseprefix + "user_groups");
            strSql.Append(" where is_lock=0 and is_upgrade=1 and grade>(select grade from " + databaseprefix + "user_groups where id=" + group_id + ") and upgrade_exp<=" + exp);
            strSql.Append(" order by grade asc");
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return GetModel(Convert.ToInt32(obj));
            }
            return null;
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
            strSql.Append(" id,title,grade,upgrade_exp,amount,point,discount,is_default,is_upgrade,is_lock ");
            strSql.Append(" FROM " + databaseprefix + "user_groups ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}