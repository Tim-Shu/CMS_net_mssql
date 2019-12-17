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
    /// 数据访问类:在线留言
    /// </summary>
    public partial class feedback
    {
        private string databaseprefix; //数据库表名前缀
        public feedback(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        #region  Method
        /// <summary>
        /// 得到最大ID
        /// </summary>
        private int GetMaxId(SqlConnection conn, SqlTransaction trans)
        {
            string strSql = "select top 1 id from " + databaseprefix + "feedback order by id desc";
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
            strSql.Append("select count(1) from " + databaseprefix + "feedback");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.feedback model)
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
                        strSql.Append("insert into " + databaseprefix + "feedback(");
                        strSql.Append("type_id,user_id,obj_id,order_no,title,content,user_name,user_tel,user_mobile,user_qq,user_weix,user_email,address,add_time,is_view,is_lock,payment_amount,order_status,payment_status)");
                        strSql.Append(" values (");
                        strSql.Append("@type_id,@user_id,@obj_id,@order_no,@title,@content,@user_name,@user_tel,@user_mobile,@user_qq,@user_weix,@user_email,@address,@add_time,@is_view,@is_lock,@payment_amount,@order_status,@payment_status)");

                        SqlParameter[] parameters = {                            
                            new SqlParameter("@type_id", SqlDbType.Int,4),
                            new SqlParameter("@user_id", SqlDbType.Int,4),
                            new SqlParameter("@obj_id", SqlDbType.Int,4),
					        new SqlParameter("@order_no", SqlDbType.NVarChar,30),
					        new SqlParameter("@title", SqlDbType.NVarChar,100),
					        new SqlParameter("@content", SqlDbType.NVarChar),
					        new SqlParameter("@user_name", SqlDbType.NVarChar,100),
					        new SqlParameter("@user_tel", SqlDbType.NVarChar,30),
					        new SqlParameter("@user_mobile", SqlDbType.NVarChar,30),
					        new SqlParameter("@user_qq", SqlDbType.NVarChar,30),
					        new SqlParameter("@user_weix", SqlDbType.NVarChar,100),
					        new SqlParameter("@user_email", SqlDbType.NVarChar,100),
					        new SqlParameter("@address", SqlDbType.NVarChar,255),
					        new SqlParameter("@add_time", SqlDbType.DateTime),
                            new SqlParameter("@is_view", SqlDbType.Int,4),
                            new SqlParameter("@is_lock", SqlDbType.Int,4),
					        new SqlParameter("@payment_amount", SqlDbType.Decimal,5),
                            new SqlParameter("@order_status", SqlDbType.Int,4),
                            new SqlParameter("@payment_status", SqlDbType.Int,4)};
                        parameters[0].Value = model.type_id;
                        parameters[1].Value = model.user_id;
                        parameters[2].Value = model.obj_id;
                        parameters[3].Value = model.order_no;
                        parameters[4].Value = model.title;
                        parameters[5].Value = model.content;
                        parameters[6].Value = model.user_name;
                        parameters[7].Value = model.user_tel;
                        parameters[8].Value = model.user_mobile;
                        parameters[9].Value = model.user_qq;
                        parameters[10].Value = model.user_weix;
                        parameters[11].Value = model.user_email;
                        parameters[12].Value = model.address;
                        parameters[13].Value = model.add_time;
                        parameters[14].Value = model.is_view;
                        parameters[15].Value = model.is_lock;
                        parameters[16].Value = model.payment_amount;
                        parameters[17].Value = model.order_status;
                        parameters[18].Value = model.payment_status;

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
            strSql.Append("update " + databaseprefix + "feedback set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.feedback model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "feedback set ");
            strSql.Append("type_id=@type_id,");
            strSql.Append("user_id=@user_id,");
            strSql.Append("obj_id=@obj_id,");
            strSql.Append("order_no=@order_no,");
            strSql.Append("title=@title,");
            strSql.Append("content=@content,");
            strSql.Append("user_name=@user_name,");
            strSql.Append("user_tel=@user_tel,");
            strSql.Append("user_mobile=@user_mobile,");
            strSql.Append("user_qq=@user_qq,");
            strSql.Append("user_weix=@user_weix,");
            strSql.Append("user_email=@user_email,");
            strSql.Append("address=@address,");
            strSql.Append("add_time=@add_time,");
            strSql.Append("is_view=@is_view,");
            strSql.Append("view_time=@view_time,");
            strSql.Append("reply_content=@reply_content,");
            strSql.Append("reply_time=@reply_time,");
            strSql.Append("is_lock=@is_lock,");
            strSql.Append("payment_amount=@payment_amount,");
            strSql.Append("order_status=@order_status,");
            strSql.Append("payment_status=@payment_status");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@type_id", SqlDbType.Int,4),
                    new SqlParameter("@user_id", SqlDbType.Int,4),
                    new SqlParameter("@obj_id", SqlDbType.Int,4),
					new SqlParameter("@order_no", SqlDbType.NVarChar,30),
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@content", SqlDbType.NVarChar),
					new SqlParameter("@user_name", SqlDbType.NVarChar,50),
					new SqlParameter("@user_tel", SqlDbType.NVarChar,30),
					new SqlParameter("@user_mobile", SqlDbType.NVarChar,30),
					new SqlParameter("@user_qq", SqlDbType.NVarChar,30),
					new SqlParameter("@user_weix", SqlDbType.NVarChar,100),
					new SqlParameter("@user_email", SqlDbType.NVarChar,100),
					new SqlParameter("@address", SqlDbType.NVarChar,255),
					new SqlParameter("@add_time", SqlDbType.DateTime),
                    new SqlParameter("@is_view", SqlDbType.Int,4),
					new SqlParameter("@view_time", SqlDbType.DateTime),
					new SqlParameter("@reply_content", SqlDbType.NVarChar),
					new SqlParameter("@reply_time", SqlDbType.DateTime),
                    new SqlParameter("@is_lock", SqlDbType.Int,4),
					new SqlParameter("@payment_amount", SqlDbType.Decimal,5),
                    new SqlParameter("@order_status", SqlDbType.Int,4),
                    new SqlParameter("@payment_status", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.type_id;
            parameters[1].Value = model.user_id;
            parameters[2].Value = model.obj_id;
            parameters[3].Value = model.order_no;
            parameters[4].Value = model.title;
            parameters[5].Value = model.content;
            parameters[6].Value = model.user_name;
            parameters[7].Value = model.user_tel;
            parameters[8].Value = model.user_mobile;
            parameters[9].Value = model.user_qq;
            parameters[10].Value = model.user_weix;
            parameters[11].Value = model.user_email;
            parameters[12].Value = model.address;
            parameters[13].Value = model.add_time;
            parameters[14].Value = model.is_view;
            parameters[15].Value = model.view_time;
            parameters[16].Value = model.reply_content;
            parameters[17].Value = model.reply_time;
            parameters[18].Value = model.is_lock;
            parameters[19].Value = model.payment_amount;
            parameters[20].Value = model.order_status;
            parameters[21].Value = model.payment_status;
            parameters[22].Value = model.id;

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
            strSql.Append("delete from " + databaseprefix + "feedback ");
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
        public Model.feedback GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,type_id,user_id,obj_id,order_no,title,content,user_name,user_tel,user_mobile,user_qq,user_weix,user_email,address,add_time,is_view,view_time,reply_content,reply_time,is_lock,payment_amount,order_status,payment_status from " + databaseprefix + "feedback ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.feedback model = new Model.feedback();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["type_id"] != null && ds.Tables[0].Rows[0]["type_id"].ToString() != "")
                {
                    model.type_id = int.Parse(ds.Tables[0].Rows[0]["type_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["user_id"] != null && ds.Tables[0].Rows[0]["user_id"].ToString() != "")
                {
                    model.user_id = int.Parse(ds.Tables[0].Rows[0]["user_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["obj_id"] != null && ds.Tables[0].Rows[0]["obj_id"].ToString() != "")
                {
                    model.obj_id = int.Parse(ds.Tables[0].Rows[0]["obj_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["order_no"] != null && ds.Tables[0].Rows[0]["order_no"].ToString() != "")
                {
                    model.order_no = ds.Tables[0].Rows[0]["order_no"].ToString();
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
                if (ds.Tables[0].Rows[0]["user_tel"] != null && ds.Tables[0].Rows[0]["user_tel"].ToString() != "")
                {
                    model.user_tel = ds.Tables[0].Rows[0]["user_tel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_mobile"] != null && ds.Tables[0].Rows[0]["user_mobile"].ToString() != "")
                {
                    model.user_mobile = ds.Tables[0].Rows[0]["user_mobile"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_qq"] != null && ds.Tables[0].Rows[0]["user_qq"].ToString() != "")
                {
                    model.user_qq = ds.Tables[0].Rows[0]["user_qq"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_weix"] != null && ds.Tables[0].Rows[0]["user_weix"].ToString() != "")
                {
                    model.user_weix = ds.Tables[0].Rows[0]["user_weix"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_email"] != null && ds.Tables[0].Rows[0]["user_email"].ToString() != "")
                {
                    model.user_email = ds.Tables[0].Rows[0]["user_email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["address"] != null && ds.Tables[0].Rows[0]["address"].ToString() != "")
                {
                    model.address = ds.Tables[0].Rows[0]["address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["add_time"] != null && ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_view"] != null && ds.Tables[0].Rows[0]["is_view"].ToString() != "")
                {
                    model.is_view = int.Parse(ds.Tables[0].Rows[0]["is_view"].ToString());
                }
                if (ds.Tables[0].Rows[0]["view_time"] != null && ds.Tables[0].Rows[0]["view_time"].ToString() != "")
                {
                    model.view_time = DateTime.Parse(ds.Tables[0].Rows[0]["view_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["reply_content"] != null && ds.Tables[0].Rows[0]["reply_content"].ToString() != "")
                {
                    model.reply_content = ds.Tables[0].Rows[0]["reply_content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["reply_time"] != null && ds.Tables[0].Rows[0]["reply_time"].ToString() != "")
                {
                    model.reply_time = DateTime.Parse(ds.Tables[0].Rows[0]["reply_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_lock"] != null && ds.Tables[0].Rows[0]["is_lock"].ToString() != "")
                {
                    model.is_lock = int.Parse(ds.Tables[0].Rows[0]["is_lock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["payment_amount"] != null && ds.Tables[0].Rows[0]["payment_amount"].ToString() != "")
                {
                    model.payment_amount = decimal.Parse(ds.Tables[0].Rows[0]["payment_amount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["order_status"] != null && ds.Tables[0].Rows[0]["order_status"].ToString() != "")
                {
                    model.order_status = int.Parse(ds.Tables[0].Rows[0]["order_status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["payment_status"] != null && ds.Tables[0].Rows[0]["payment_status"].ToString() != "")
                {
                    model.payment_status = int.Parse(ds.Tables[0].Rows[0]["payment_status"].ToString());
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
        public DataSet GetList(int Top, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,type_id,user_id,obj_id,order_no,title,content,user_name,user_tel,user_mobile,user_qq,user_weix,user_email,address,add_time,is_view,view_time,is_lock,payment_amount,order_status,payment_status ");
            strSql.Append(" FROM " + databaseprefix + "feedback ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by add_time desc");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM " + databaseprefix + "feedback");
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
