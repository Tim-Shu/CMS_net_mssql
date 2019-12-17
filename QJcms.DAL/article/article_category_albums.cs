using QJcms.Common;
using QJcms.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace QJcms.DAL
{/// <summary>
    /// 类别图册
    /// </summary>
    public partial class article_category_albums
    {
        private string databaseprefix; //数据库表名前缀
        public article_category_albums(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.article_category_albums> GetList(int category_id)
        {
            List<Model.article_category_albums> modelList = new List<Model.article_category_albums>();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,category_id,thumb_path,original_path,remark,add_time ");
            strSql.Append(" FROM " + databaseprefix + "article_category_albums ");
            strSql.Append(" where category_id=" + category_id);
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];

            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.article_category_albums model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.article_category_albums();
                    if (dt.Rows[n]["id"] != null && dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["category_id"] != null && dt.Rows[n]["category_id"].ToString() != "")
                    {
                        model.category_id = int.Parse(dt.Rows[n]["category_id"].ToString());
                    }
                    if (dt.Rows[n]["thumb_path"] != null && dt.Rows[n]["thumb_path"].ToString() != "")
                    {
                        model.thumb_path = dt.Rows[n]["thumb_path"].ToString();
                    }
                    if (dt.Rows[n]["original_path"] != null && dt.Rows[n]["original_path"].ToString() != "")
                    {
                        model.original_path = dt.Rows[n]["original_path"].ToString();
                    }
                    if (dt.Rows[n]["remark"] != null && dt.Rows[n]["remark"].ToString() != "")
                    {
                        model.remark = dt.Rows[n]["remark"].ToString();
                    }
                    if (dt.Rows[0]["add_time"].ToString() != "")
                    {
                        model.add_time = DateTime.Parse(dt.Rows[0]["add_time"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 查找不存在的图片并删除已删除的图片及数据
        /// </summary>
        public void DeleteList(SqlConnection conn, SqlTransaction trans, List<Model.article_category_albums> models, int category_id)
        {
            StringBuilder idList = new StringBuilder();
            if (models != null)
            {
                foreach (Model.article_category_albums modelt in models)
                {
                    if (modelt.id > 0)
                    {
                        idList.Append(modelt.id + ",");
                    }
                }
            }
            string id_list = Utils.DelLastChar(idList.ToString(), ",");
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,thumb_path,original_path from " + databaseprefix + "article_category_albums where category_id=" + category_id);
            if (!string.IsNullOrEmpty(id_list))
            {
                strSql.Append(" and id not in(" + id_list + ")");
            }
            DataSet ds = DbHelperSQL.Query(conn, trans, strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int rows = DbHelperSQL.ExecuteSql(conn, trans, "delete from " + databaseprefix + "article_category_albums where id=" + dr["id"].ToString()); //删除数据库
                if (rows > 0)
                {
                    Utils.DeleteFile(dr["thumb_path"].ToString()); //删除缩略图
                    Utils.DeleteFile(dr["original_path"].ToString()); //删除原图
                }
            }
        }

        /// <summary>
        /// 删除相册图片
        /// </summary>
        public void DeleteFile(List<Model.article_category_albums> models)
        {
            if (models != null)
            {
                foreach (Model.article_category_albums modelt in models)
                {
                    Utils.DeleteFile(modelt.thumb_path);
                    Utils.DeleteFile(modelt.original_path);
                }
            }
        }

        public bool ClearFile(int category_id)
        {
            if (category_id > 0)
            {
                List<Model.article_category_albums> models = GetList(category_id);
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from " + databaseprefix + "article_category_albums ");
                strSql.Append(" where category_id=@category_id");
                SqlParameter[] parameters = {
					new SqlParameter("@category_id", SqlDbType.Int,4)};
                parameters[0].Value = category_id;

                int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                if (rows > 0)
                {
                    foreach (Model.article_category_albums modelt in models)
                    {
                        Utils.DeleteFile(modelt.thumb_path);
                        Utils.DeleteFile(modelt.original_path);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
