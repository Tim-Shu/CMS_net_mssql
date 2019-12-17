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
    /// 数据访问类:频道
    /// </summary>
    public partial class channel
    {
        private string databaseprefix; //数据库表名前缀
        public channel(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        #region  基本方法=========================================
        /// <summary>
        /// 得到最大ID
        /// </summary>
        private int GetMaxId(SqlConnection conn, SqlTransaction trans)
        {
            string strSql = "select top 1 id from " + databaseprefix + "channel order by id desc";
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
            strSql.Append("select count(1) from " + databaseprefix + "channel");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 查询是否存在该记录
        /// </summary>
        public bool Exists(string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "channel");
            strSql.Append(" where name=@name ");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50)};
            parameters[0].Value = name;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 返回数据总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as H ");
            strSql.Append(" from " + databaseprefix + "channel");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 增加一条数据及其子表
        /// </summary>
        public int Add(Model.channel model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into " + databaseprefix + "channel(");
                        strSql.Append("category_id,name,title,content_name,category_name,comment_name,recom_type,is_cover,is_albums,is_attach,is_comment,is_customer,is_group_price,page_size,deep_layer,attach_size,img_size,img_maxheight,img_maxwidth,thumbnail_height,thumbnail_width,beyond_type,is_category_call,is_category_link,is_category_into,is_category_seo,is_category_img,is_content_call,is_content_link,is_content_into,is_content_seo,sort_id,is_channel_img,channel_img,is_channel_descript,channel_descript)");
                        strSql.Append(" values (");
                        strSql.Append("@category_id,@name,@title,@content_name,@category_name,@comment_name,@recom_type,@is_cover,@is_albums,@is_attach,@is_comment,@is_customer,@is_group_price,@page_size,@deep_layer,@attach_size,@img_size,@img_maxheight,@img_maxwidth,@thumbnail_height,@thumbnail_width,@beyond_type,@is_category_call,@is_category_link,@is_category_into,@is_category_seo,@is_category_img,@is_content_call,@is_content_link,@is_content_into,@is_content_seo,@sort_id,@is_channel_img,@channel_img,@is_channel_descript,@channel_descript)");
                        
                        SqlParameter[] parameters = {
					            new SqlParameter("@category_id", SqlDbType.Int,4),
					            new SqlParameter("@name", SqlDbType.NVarChar,50),
					            new SqlParameter("@title", SqlDbType.NVarChar,100),
					            new SqlParameter("@content_name", SqlDbType.NVarChar,50),
					            new SqlParameter("@category_name", SqlDbType.NVarChar,50),
					            new SqlParameter("@comment_name", SqlDbType.NVarChar,50),
					            new SqlParameter("@recom_type", SqlDbType.NVarChar,50),
                                new SqlParameter("@is_cover", SqlDbType.Int,4),
                                new SqlParameter("@is_albums", SqlDbType.Int,4),
					            new SqlParameter("@is_attach", SqlDbType.Int,4),
					            new SqlParameter("@is_comment", SqlDbType.Int,4),
					            new SqlParameter("@is_customer", SqlDbType.Int,4),
					            new SqlParameter("@is_group_price", SqlDbType.Int,4),
					            new SqlParameter("@page_size", SqlDbType.Int,4),
					            new SqlParameter("@deep_layer", SqlDbType.Int,4),
					            new SqlParameter("@attach_size", SqlDbType.Int,4),
					            new SqlParameter("@img_size", SqlDbType.Int,4),
					            new SqlParameter("@img_maxheight", SqlDbType.Int,4),
					            new SqlParameter("@img_maxwidth", SqlDbType.Int,4),
					            new SqlParameter("@thumbnail_height", SqlDbType.Int,4),
					            new SqlParameter("@thumbnail_width", SqlDbType.Int,4),
					            new SqlParameter("@beyond_type", SqlDbType.Int,4),
					            new SqlParameter("@is_category_call", SqlDbType.Int,4),
					            new SqlParameter("@is_category_link", SqlDbType.Int,4),
					            new SqlParameter("@is_category_into", SqlDbType.Int,4),
					            new SqlParameter("@is_category_seo", SqlDbType.Int,4),
					            new SqlParameter("@is_category_img", SqlDbType.Int,4),
					            new SqlParameter("@is_content_call", SqlDbType.Int,4),
					            new SqlParameter("@is_content_link", SqlDbType.Int,4),
					            new SqlParameter("@is_content_into", SqlDbType.Int,4),
					            new SqlParameter("@is_content_seo", SqlDbType.Int,4),
					            new SqlParameter("@sort_id", SqlDbType.Int,4),
					            new SqlParameter("@is_channel_img", SqlDbType.Int,4),
					            new SqlParameter("@channel_img", SqlDbType.NVarChar,255),
					            new SqlParameter("@is_channel_descript", SqlDbType.Int,4),
					            new SqlParameter("@channel_descript", SqlDbType.NVarChar),
                                new SqlParameter("@ReturnValue",SqlDbType.Int)};
                        parameters[0].Value = model.category_id;
                        parameters[1].Value = model.name;
                        parameters[2].Value = model.title;
                        parameters[3].Value = model.content_name;
                        parameters[4].Value = model.category_name;
                        parameters[5].Value = model.comment_name;
                        parameters[6].Value = model.recom_type;
                        parameters[7].Value = model.is_cover;
                        parameters[8].Value = model.is_albums;
                        parameters[9].Value = model.is_attach;
                        parameters[10].Value = model.is_comment;
                        parameters[11].Value = model.is_customer;
                        parameters[12].Value = model.is_group_price;
                        parameters[13].Value = model.page_size;
                        parameters[14].Value = model.deep_layer;
                        parameters[15].Value = model.attach_size;
                        parameters[16].Value = model.img_size;
                        parameters[17].Value = model.img_maxheight;
                        parameters[18].Value = model.img_maxwidth;
                        parameters[19].Value = model.thumbnail_height;
                        parameters[20].Value = model.thumbnail_width;
                        parameters[21].Value = model.beyond_type;
                        parameters[22].Value = model.is_category_call;
                        parameters[23].Value = model.is_category_link;
                        parameters[24].Value = model.is_category_into;
                        parameters[25].Value = model.is_category_seo;
                        parameters[26].Value = model.is_category_img;
                        parameters[27].Value = model.is_content_call;
                        parameters[28].Value = model.is_content_link;
                        parameters[29].Value = model.is_content_into;
                        parameters[30].Value = model.is_content_seo;
                        parameters[31].Value = model.sort_id;
                        parameters[32].Value = model.is_channel_img;
                        parameters[33].Value = model.channel_img;
                        parameters[34].Value = model.is_channel_descript;
                        parameters[35].Value = model.channel_descript;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);
                        //取得新插入的ID
                        model.id = GetMaxId(conn, trans);
                        #region 扩展方法
                        //扩展字段
                        if (model.channel_fields != null)
                        {
                            StringBuilder strSql2;
                            foreach (Model.channel_field modelt in model.channel_fields)
                            {
                                strSql2 = new StringBuilder();
                                strSql2.Append("insert into " + databaseprefix + "channel_field(");
                                strSql2.Append("channel_id,field_id)");
                                strSql2.Append(" values (");
                                strSql2.Append("@channel_id,@field_id)");
                                SqlParameter[] parameters2 = {
					                    new SqlParameter("@channel_id", SqlDbType.Int,4),
					                    new SqlParameter("@field_id", SqlDbType.Int,4)};
                                parameters2[0].Value = model.id;
                                parameters2[1].Value = modelt.field_id;
                                DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);
                            }
                        }

                        //添加视图
                        StringBuilder strSql3 = new StringBuilder();
                        strSql3.Append("CREATE VIEW view_channel_" + model.name + " as");
                        strSql3.Append(" SELECT " + databaseprefix + "article.*");
                        if (model.channel_fields.Count > 0 && model.channel_fields != null)
                        {
                            foreach (Model.channel_field modelt in model.channel_fields)
                            {
                                Model.article_attribute_field fieldModel = new DAL.article_attribute_field(databaseprefix).GetModel(modelt.field_id);
                                if (fieldModel != null)
                                {
                                    strSql3.Append("," + databaseprefix + "article_attribute_value." + fieldModel.name);
                                }
                            }
                        }
                        if (model.deep_layer > 0)
                        {
                            strSql3.Append("," + databaseprefix + "article_category.title AS category_title");
                        }
                        strSql3.Append(" FROM ");
                        if (model.channel_fields != null && model.channel_fields.Count > 0)
                        {
                            strSql3.Append(" (" + databaseprefix + "article_attribute_value INNER JOIN");
                            strSql3.Append(" " + databaseprefix + "article ON " + databaseprefix + "article_attribute_value.article_id = " + databaseprefix + "article.id)");
                            if (model.deep_layer > 0)
                            {
                                strSql3.Append(" INNER JOIN " + databaseprefix + "article_category ON " + databaseprefix + "article.category_id = " + databaseprefix + "article_category.id");
                            }
                        }
                        else
                        {
                            if (model.deep_layer > 0)
                            {
                                strSql3.Append(" " + databaseprefix + "article_category INNER JOIN");
                                strSql3.Append(" " + databaseprefix + "article ON " + databaseprefix + "article.category_id = " + databaseprefix + "article_category.id");
                            }
                            else
                            {
                                strSql3.Append(" " + databaseprefix + "article");
                            }
                        }
                        strSql3.Append(" WHERE " + databaseprefix + "article.channel_id=" + model.id);
                        DbHelperSQL.ExecuteSql(conn, trans, strSql3.ToString());
                        #endregion
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return 0;
                    }
                }
            }
            return model.id;
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "channel set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.channel model)
        {
            Model.channel oldModel = GetModel(model.id); //旧的数据
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update " + databaseprefix + "channel set ");
                        strSql.Append("category_id=@category_id,");
                        strSql.Append("name=@name,");
                        strSql.Append("title=@title,");
                        strSql.Append("content_name=@content_name,");
                        strSql.Append("category_name=@category_name,");
                        strSql.Append("comment_name=@comment_name,");
                        strSql.Append("recom_type=@recom_type,");
                        strSql.Append("is_cover=@is_cover,");
                        strSql.Append("is_albums=@is_albums,");
                        strSql.Append("is_attach=@is_attach,");
                        strSql.Append("is_comment=@is_comment,");
                        strSql.Append("is_customer=@is_customer,");
                        strSql.Append("is_group_price=@is_group_price,");
                        strSql.Append("page_size=@page_size,");
                        strSql.Append("deep_layer=@deep_layer,");
                        strSql.Append("attach_size=@attach_size,");
                        strSql.Append("img_size=@img_size,");
                        strSql.Append("img_maxheight=@img_maxheight,");
                        strSql.Append("img_maxwidth=@img_maxwidth,");
                        strSql.Append("thumbnail_height=@thumbnail_height,");
                        strSql.Append("thumbnail_width=@thumbnail_width,");
                        strSql.Append("beyond_type=@beyond_type,");
                        strSql.Append("is_category_call=@is_category_call,");
                        strSql.Append("is_category_link=@is_category_link,");
                        strSql.Append("is_category_into=@is_category_into,");
                        strSql.Append("is_category_seo=@is_category_seo,");
                        strSql.Append("is_category_img=@is_category_img,");
                        strSql.Append("is_content_call=@is_content_call,");
                        strSql.Append("is_content_link=@is_content_link,");
                        strSql.Append("is_content_into=@is_content_into,");
                        strSql.Append("is_content_seo=@is_content_seo,");
                        strSql.Append("sort_id=@sort_id,");
                        strSql.Append("is_channel_img=@is_channel_img,");
                        strSql.Append("channel_img=@channel_img,");
                        strSql.Append("is_channel_descript=@is_channel_descript,");
                        strSql.Append("channel_descript=@channel_descript");
                        strSql.Append(" where id=@id ");
                        SqlParameter[] parameters = {
					            new SqlParameter("@category_id", SqlDbType.Int,4),
					            new SqlParameter("@name", SqlDbType.NVarChar,50),
					            new SqlParameter("@title", SqlDbType.NVarChar,100),
					            new SqlParameter("@content_name", SqlDbType.NVarChar,50),
					            new SqlParameter("@category_name", SqlDbType.NVarChar,50),
					            new SqlParameter("@comment_name", SqlDbType.NVarChar,50),
					            new SqlParameter("@recom_type", SqlDbType.NVarChar,50),
                                new SqlParameter("@is_cover", SqlDbType.Int,4),
                                new SqlParameter("@is_albums", SqlDbType.Int,4),
					            new SqlParameter("@is_attach", SqlDbType.Int,4),
					            new SqlParameter("@is_comment", SqlDbType.Int,4),
					            new SqlParameter("@is_customer", SqlDbType.Int,4),
					            new SqlParameter("@is_group_price", SqlDbType.Int,4),
					            new SqlParameter("@page_size", SqlDbType.Int,4),
					            new SqlParameter("@deep_layer", SqlDbType.Int,4),
					            new SqlParameter("@attach_size", SqlDbType.Int,4),
					            new SqlParameter("@img_size", SqlDbType.Int,4),
					            new SqlParameter("@img_maxheight", SqlDbType.Int,4),
					            new SqlParameter("@img_maxwidth", SqlDbType.Int,4),
					            new SqlParameter("@thumbnail_height", SqlDbType.Int,4),
					            new SqlParameter("@thumbnail_width", SqlDbType.Int,4),
					            new SqlParameter("@beyond_type", SqlDbType.Int,4),
					            new SqlParameter("@is_category_call", SqlDbType.Int,4),
					            new SqlParameter("@is_category_link", SqlDbType.Int,4),
					            new SqlParameter("@is_category_into", SqlDbType.Int,4),
					            new SqlParameter("@is_category_seo", SqlDbType.Int,4),
					            new SqlParameter("@is_category_img", SqlDbType.Int,4),
					            new SqlParameter("@is_content_call", SqlDbType.Int,4),
					            new SqlParameter("@is_content_link", SqlDbType.Int,4),
					            new SqlParameter("@is_content_into", SqlDbType.Int,4),
					            new SqlParameter("@is_content_seo", SqlDbType.Int,4),
					            new SqlParameter("@sort_id", SqlDbType.Int,4),
					            new SqlParameter("@is_channel_img", SqlDbType.Int,4),
					            new SqlParameter("@channel_img", SqlDbType.NVarChar,255),
					            new SqlParameter("@is_channel_descript", SqlDbType.Int,4),
					            new SqlParameter("@channel_descript", SqlDbType.NVarChar),
                                new SqlParameter("@id", SqlDbType.Int,4)};
                        parameters[0].Value = model.category_id;
                        parameters[1].Value = model.name;
                        parameters[2].Value = model.title;
                        parameters[3].Value = model.content_name;
                        parameters[4].Value = model.category_name;
                        parameters[5].Value = model.comment_name;
                        parameters[6].Value = model.recom_type;
                        parameters[7].Value = model.is_cover;
                        parameters[8].Value = model.is_albums;
                        parameters[9].Value = model.is_attach;
                        parameters[10].Value = model.is_comment;
                        parameters[11].Value = model.is_customer;
                        parameters[12].Value = model.is_group_price;
                        parameters[13].Value = model.page_size;
                        parameters[14].Value = model.deep_layer;
                        parameters[15].Value = model.attach_size;
                        parameters[16].Value = model.img_size;
                        parameters[17].Value = model.img_maxheight;
                        parameters[18].Value = model.img_maxwidth;
                        parameters[19].Value = model.thumbnail_height;
                        parameters[20].Value = model.thumbnail_width;
                        parameters[21].Value = model.beyond_type;
                        parameters[22].Value = model.is_category_call;
                        parameters[23].Value = model.is_category_link;
                        parameters[24].Value = model.is_category_into;
                        parameters[25].Value = model.is_category_seo;
                        parameters[26].Value = model.is_category_img;
                        parameters[27].Value = model.is_content_call;
                        parameters[28].Value = model.is_content_link;
                        parameters[29].Value = model.is_content_into;
                        parameters[30].Value = model.is_content_seo;
                        parameters[31].Value = model.sort_id;
                        parameters[32].Value = model.is_channel_img;
                        parameters[33].Value = model.channel_img;
                        parameters[34].Value = model.is_channel_descript;
                        parameters[35].Value = model.channel_descript;
                        parameters[36].Value = model.id;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

                        //删除已移除的扩展字段
                        FieldDelete(conn, trans, model.channel_fields, model.id);
                        //添加扩展字段
                        if (model.channel_fields != null)
                        {
                            StringBuilder strSql2;
                            foreach (Model.channel_field modelt in model.channel_fields)
                            {
                                strSql2 = new StringBuilder();
                                Model.channel_field fieldModel = null;
                                if (oldModel.channel_fields != null)
                                {
                                    fieldModel = oldModel.channel_fields.Find(p => p.field_id == modelt.field_id); //查找是否已经存在
                                }
                                if (fieldModel == null) //如果不存在则添加
                                {
                                    strSql2.Append("insert into " + databaseprefix + "channel_field(");
                                    strSql2.Append("channel_id,field_id)");
                                    strSql2.Append(" values (");
                                    strSql2.Append("@channel_id,@field_id)");
                                    SqlParameter[] parameters2 = {
					                        new SqlParameter("@channel_id", SqlDbType.Int,4),
					                        new SqlParameter("@field_id", SqlDbType.Int,4)};
                                    parameters2[0].Value = modelt.channel_id;
                                    parameters2[1].Value = modelt.field_id;
                                    DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);
                                }
                            }
                        }
                        //删除旧视图重建新视图
                        RehabChannelViews(conn, trans, model, oldModel.name);

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            //取得将要删除的记录
            Model.channel model = GetModel(id);
            if (model == null)
            {
                return false;
            }
            //取得导航的ID
            int nav_id = new navigation(databaseprefix).GetNavId("channel_" + model.name);

            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        //删除导航主表
                        if (nav_id > 0)
                        {
                            DbHelperSQL.ExecuteSql(conn, trans, "delete from " + databaseprefix + "navigation  where class_list like '%," + nav_id + ",%'");
                        }

                        //删除视图
                        StringBuilder strSql1 = new StringBuilder();
                        //strSql1.Append("if exists (select 1 from sysobjects where id = object_id('view_channel_" + model.name + "') and type = 'V')");
                        strSql1.Append("drop view view_channel_" + model.name);
                        DbHelperSQL.ExecuteSql(conn, trans, strSql1.ToString());

                        //删除频道扩展字段表
                        StringBuilder strSql2 = new StringBuilder();
                        strSql2.Append("delete from " + databaseprefix + "channel_field ");
                        strSql2.Append(" where channel_id=@channel_id ");
                        SqlParameter[] parameters2 = {
					            new SqlParameter("@channel_id", SqlDbType.Int,4)};
                        parameters2[0].Value = id;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);

                        //删除频道表
                        StringBuilder strSql3 = new StringBuilder();
                        strSql3.Append("delete from " + databaseprefix + "channel ");
                        strSql3.Append(" where id=@id ");
                        SqlParameter[] parameters3 = {
					            new SqlParameter("@id", SqlDbType.Int,4)};
                        parameters3[0].Value = id;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql3.ToString(), parameters3);

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.channel GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,category_id,name,title,content_name,category_name,comment_name,recom_type,is_cover,is_albums,is_attach,is_comment,is_customer,is_group_price,page_size,deep_layer,attach_size,img_size,img_maxheight,img_maxwidth,thumbnail_height,thumbnail_width,beyond_type,is_category_call,is_category_link,is_category_into,is_category_seo,is_category_img,is_content_call,is_content_link,is_content_into,is_content_seo,sort_id,is_channel_img,channel_img,is_channel_descript,channel_descript from " + databaseprefix + "channel ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.channel model = new Model.channel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                #region  父表信息
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["category_id"].ToString() != "")
                {
                    model.category_id = int.Parse(ds.Tables[0].Rows[0]["category_id"].ToString());
                }
                model.name = ds.Tables[0].Rows[0]["name"].ToString();
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.content_name = ds.Tables[0].Rows[0]["content_name"].ToString();
                model.category_name = ds.Tables[0].Rows[0]["category_name"].ToString();
                model.comment_name = ds.Tables[0].Rows[0]["comment_name"].ToString();
                model.recom_type = ds.Tables[0].Rows[0]["recom_type"].ToString();
                if (ds.Tables[0].Rows[0]["is_cover"].ToString() != "")
                {
                    model.is_cover = int.Parse(ds.Tables[0].Rows[0]["is_cover"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_albums"].ToString() != "")
                {
                    model.is_albums = int.Parse(ds.Tables[0].Rows[0]["is_albums"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_attach"].ToString() != "")
                {
                    model.is_attach = int.Parse(ds.Tables[0].Rows[0]["is_attach"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_comment"].ToString() != "")
                {
                    model.is_comment = int.Parse(ds.Tables[0].Rows[0]["is_comment"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_customer"].ToString() != "")
                {
                    model.is_customer = int.Parse(ds.Tables[0].Rows[0]["is_customer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_group_price"].ToString() != "")
                {
                    model.is_group_price = int.Parse(ds.Tables[0].Rows[0]["is_group_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["page_size"].ToString() != "")
                {
                    model.page_size = int.Parse(ds.Tables[0].Rows[0]["page_size"].ToString());
                }
                if (ds.Tables[0].Rows[0]["deep_layer"].ToString() != "")
                {
                    model.deep_layer = int.Parse(ds.Tables[0].Rows[0]["deep_layer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["attach_size"].ToString() != "")
                {
                    model.attach_size = int.Parse(ds.Tables[0].Rows[0]["attach_size"].ToString());
                }
                if (ds.Tables[0].Rows[0]["img_size"].ToString() != "")
                {
                    model.img_size = int.Parse(ds.Tables[0].Rows[0]["img_size"].ToString());
                }
                if (ds.Tables[0].Rows[0]["img_maxheight"].ToString() != "")
                {
                    model.img_maxheight = int.Parse(ds.Tables[0].Rows[0]["img_maxheight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["img_maxwidth"].ToString() != "")
                {
                    model.img_maxwidth = int.Parse(ds.Tables[0].Rows[0]["img_maxwidth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["thumbnail_height"].ToString() != "")
                {
                    model.thumbnail_height = int.Parse(ds.Tables[0].Rows[0]["thumbnail_height"].ToString());
                }
                if (ds.Tables[0].Rows[0]["thumbnail_width"].ToString() != "")
                {
                    model.thumbnail_width = int.Parse(ds.Tables[0].Rows[0]["thumbnail_width"].ToString());
                }
                if (ds.Tables[0].Rows[0]["beyond_type"].ToString() != "")
                {
                    model.beyond_type = int.Parse(ds.Tables[0].Rows[0]["beyond_type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_category_call"].ToString() != "")
                {
                    model.is_category_call = int.Parse(ds.Tables[0].Rows[0]["is_category_call"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_category_link"].ToString() != "")
                {
                    model.is_category_link = int.Parse(ds.Tables[0].Rows[0]["is_category_link"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_category_into"].ToString() != "")
                {
                    model.is_category_into = int.Parse(ds.Tables[0].Rows[0]["is_category_into"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_category_seo"].ToString() != "")
                {
                    model.is_category_seo = int.Parse(ds.Tables[0].Rows[0]["is_category_seo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_category_img"].ToString() != "")
                {
                    model.is_category_img = int.Parse(ds.Tables[0].Rows[0]["is_category_img"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_content_call"].ToString() != "")
                {
                    model.is_content_call = int.Parse(ds.Tables[0].Rows[0]["is_content_call"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_content_link"].ToString() != "")
                {
                    model.is_content_link = int.Parse(ds.Tables[0].Rows[0]["is_content_link"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_content_into"].ToString() != "")
                {
                    model.is_content_into = int.Parse(ds.Tables[0].Rows[0]["is_content_into"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_content_seo"].ToString() != "")
                {
                    model.is_content_seo = int.Parse(ds.Tables[0].Rows[0]["is_content_seo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_channel_img"].ToString() != "")
                {
                    model.is_channel_img = int.Parse(ds.Tables[0].Rows[0]["is_channel_img"].ToString());
                }
                model.channel_img = ds.Tables[0].Rows[0]["channel_img"].ToString();
                if (ds.Tables[0].Rows[0]["is_channel_descript"].ToString() != "")
                {
                    model.is_channel_descript = int.Parse(ds.Tables[0].Rows[0]["is_channel_descript"].ToString());
                }
                model.channel_descript = ds.Tables[0].Rows[0]["channel_descript"].ToString();
                #endregion  父表信息end

                #region  子表信息
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("select id,channel_id,field_id from " + databaseprefix + "channel_field ");
                strSql2.Append(" where channel_id=@channel_id ");
                SqlParameter[] parameters2 = {
					new SqlParameter("@channel_id", SqlDbType.Int,4)};
                parameters2[0].Value = id;

                DataSet ds2 = DbHelperSQL.Query(strSql2.ToString(), parameters2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    int i = ds2.Tables[0].Rows.Count;
                    List<Model.channel_field> models = new List<Model.channel_field>();
                    Model.channel_field modelt;
                    for (int n = 0; n < i; n++)
                    {
                        modelt = new Model.channel_field();
                        if (ds2.Tables[0].Rows[n]["id"].ToString() != "")
                        {
                            modelt.id = int.Parse(ds2.Tables[0].Rows[n]["id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["channel_id"].ToString() != "")
                        {
                            modelt.channel_id = int.Parse(ds2.Tables[0].Rows[n]["channel_id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["field_id"].ToString() != "")
                        {
                            modelt.field_id = int.Parse(ds2.Tables[0].Rows[n]["field_id"].ToString());
                        }
                        models.Add(modelt);
                    }
                    model.channel_fields = models;
                }
                #endregion  子表信息end

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
        public Model.channel GetModel(SqlConnection conn, SqlTransaction trans, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,category_id,name,title,content_name,category_name,comment_name,recom_type,is_cover,is_albums,is_attach,is_comment,is_customer,is_group_price,page_size,deep_layer,attach_size,img_size,img_maxheight,img_maxwidth,thumbnail_height,thumbnail_width,beyond_type,is_category_call,is_category_link,is_category_into,is_category_seo,is_category_img,is_content_call,is_content_link,is_content_into,is_content_seo,sort_id,is_channel_img,channel_img,is_channel_descript,channel_descript from " + databaseprefix + "channel ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.channel model = new Model.channel();
            DataSet ds = DbHelperSQL.Query(conn, trans, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                #region  父表信息
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["category_id"].ToString() != "")
                {
                    model.category_id = int.Parse(ds.Tables[0].Rows[0]["category_id"].ToString());
                }
                model.name = ds.Tables[0].Rows[0]["name"].ToString();
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.content_name = ds.Tables[0].Rows[0]["content_name"].ToString();
                model.category_name = ds.Tables[0].Rows[0]["category_name"].ToString();
                model.comment_name = ds.Tables[0].Rows[0]["comment_name"].ToString();
                model.recom_type = ds.Tables[0].Rows[0]["recom_type"].ToString();
                if (ds.Tables[0].Rows[0]["is_cover"].ToString() != "")
                {
                    model.is_cover = int.Parse(ds.Tables[0].Rows[0]["is_cover"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_albums"].ToString() != "")
                {
                    model.is_albums = int.Parse(ds.Tables[0].Rows[0]["is_albums"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_attach"].ToString() != "")
                {
                    model.is_attach = int.Parse(ds.Tables[0].Rows[0]["is_attach"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_comment"].ToString() != "")
                {
                    model.is_comment = int.Parse(ds.Tables[0].Rows[0]["is_comment"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_customer"].ToString() != "")
                {
                    model.is_customer = int.Parse(ds.Tables[0].Rows[0]["is_customer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_group_price"].ToString() != "")
                {
                    model.is_group_price = int.Parse(ds.Tables[0].Rows[0]["is_group_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["page_size"].ToString() != "")
                {
                    model.page_size = int.Parse(ds.Tables[0].Rows[0]["page_size"].ToString());
                }
                if (ds.Tables[0].Rows[0]["deep_layer"].ToString() != "")
                {
                    model.deep_layer = int.Parse(ds.Tables[0].Rows[0]["deep_layer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["attach_size"].ToString() != "")
                {
                    model.attach_size = int.Parse(ds.Tables[0].Rows[0]["attach_size"].ToString());
                }
                if (ds.Tables[0].Rows[0]["img_size"].ToString() != "")
                {
                    model.img_size = int.Parse(ds.Tables[0].Rows[0]["img_size"].ToString());
                }
                if (ds.Tables[0].Rows[0]["img_maxheight"].ToString() != "")
                {
                    model.img_maxheight = int.Parse(ds.Tables[0].Rows[0]["img_maxheight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["img_maxwidth"].ToString() != "")
                {
                    model.img_maxwidth = int.Parse(ds.Tables[0].Rows[0]["img_maxwidth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["thumbnail_height"].ToString() != "")
                {
                    model.thumbnail_height = int.Parse(ds.Tables[0].Rows[0]["thumbnail_height"].ToString());
                }
                if (ds.Tables[0].Rows[0]["thumbnail_width"].ToString() != "")
                {
                    model.thumbnail_width = int.Parse(ds.Tables[0].Rows[0]["thumbnail_width"].ToString());
                }
                if (ds.Tables[0].Rows[0]["beyond_type"].ToString() != "")
                {
                    model.beyond_type = int.Parse(ds.Tables[0].Rows[0]["beyond_type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_category_call"].ToString() != "")
                {
                    model.is_category_call = int.Parse(ds.Tables[0].Rows[0]["is_category_call"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_category_link"].ToString() != "")
                {
                    model.is_category_link = int.Parse(ds.Tables[0].Rows[0]["is_category_link"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_category_into"].ToString() != "")
                {
                    model.is_category_into = int.Parse(ds.Tables[0].Rows[0]["is_category_into"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_category_seo"].ToString() != "")
                {
                    model.is_category_seo = int.Parse(ds.Tables[0].Rows[0]["is_category_seo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_category_img"].ToString() != "")
                {
                    model.is_category_img = int.Parse(ds.Tables[0].Rows[0]["is_category_img"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_content_call"].ToString() != "")
                {
                    model.is_content_call = int.Parse(ds.Tables[0].Rows[0]["is_content_call"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_content_link"].ToString() != "")
                {
                    model.is_content_link = int.Parse(ds.Tables[0].Rows[0]["is_content_link"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_content_into"].ToString() != "")
                {
                    model.is_content_into = int.Parse(ds.Tables[0].Rows[0]["is_content_into"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_content_seo"].ToString() != "")
                {
                    model.is_content_seo = int.Parse(ds.Tables[0].Rows[0]["is_content_seo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_channel_img"].ToString() != "")
                {
                    model.is_channel_img = int.Parse(ds.Tables[0].Rows[0]["is_channel_img"].ToString());
                }
                model.channel_img = ds.Tables[0].Rows[0]["channel_img"].ToString();
                if (ds.Tables[0].Rows[0]["is_channel_descript"].ToString() != "")
                {
                    model.is_channel_descript = int.Parse(ds.Tables[0].Rows[0]["is_channel_descript"].ToString());
                }
                model.channel_descript = ds.Tables[0].Rows[0]["channel_descript"].ToString();
                #endregion

                #region  子表信息
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("select id,channel_id,field_id from " + databaseprefix + "channel_field ");
                strSql2.Append(" where channel_id=@channel_id ");
                SqlParameter[] parameters2 = {
					new SqlParameter("@channel_id", SqlDbType.Int,4)};
                parameters2[0].Value = id;

                DataSet ds2 = DbHelperSQL.Query(conn, trans, strSql2.ToString(), parameters2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    int i = ds2.Tables[0].Rows.Count;
                    List<Model.channel_field> models = new List<Model.channel_field>();
                    Model.channel_field modelt;
                    for (int n = 0; n < i; n++)
                    {
                        modelt = new Model.channel_field();
                        if (ds2.Tables[0].Rows[n]["id"].ToString() != "")
                        {
                            modelt.id = int.Parse(ds2.Tables[0].Rows[n]["id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["channel_id"].ToString() != "")
                        {
                            modelt.channel_id = int.Parse(ds2.Tables[0].Rows[n]["channel_id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["field_id"].ToString() != "")
                        {
                            modelt.field_id = int.Parse(ds2.Tables[0].Rows[n]["field_id"].ToString());
                        }
                        models.Add(modelt);
                    }
                    model.channel_fields = models;
                }
                #endregion

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
            strSql.Append(" id,category_id,name,title,content_name,category_name,comment_name,recom_type,is_cover,is_albums,is_attach,is_comment,is_customer,is_group_price,page_size,deep_layer,attach_size,img_size,img_maxheight,img_maxwidth,thumbnail_height,thumbnail_width,beyond_type,is_category_call,is_category_link,is_category_into,is_category_seo,is_category_img,is_content_call,is_content_link,is_content_into,is_content_seo,sort_id,is_channel_img,channel_img,is_channel_descript,channel_descript ");
            strSql.Append(" FROM " + databaseprefix + "channel ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM " + databaseprefix + "channel");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        #endregion

        #region 扩展方法=========================================
        /// <summary>
        /// 根据频道的名称查询ID
        /// </summary>
        public int GetChannelId(string channel_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id FROM " + databaseprefix + "channel");
            strSql.Append(" where name=@name");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50)};
            parameters[0].Value = channel_name;
            string str = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
            return Utils.StrToInt(str, 0);
        }

        /// <summary>
        /// 根据频道的ID查询名称
        /// </summary>
        public string GetChannelName(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 name FROM " + databaseprefix + "channel");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            string name = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
            if (string.IsNullOrEmpty(name))
            {
                return string.Empty;
            }
            return name;
        }

        /// <summary>
        /// 根据频道的名称查询ID
        /// </summary>
        public Model.channel GetModel(string channel_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,category_id,name,title,content_name,category_name,comment_name,recom_type,is_cover,is_albums,is_attach,is_comment,is_customer,is_group_price,page_size,deep_layer,attach_size,img_size,img_maxheight,img_maxwidth,thumbnail_height,thumbnail_width,beyond_type,is_category_call,is_category_link,is_category_into,is_category_seo,is_category_img,is_content_call,is_content_link,is_content_into,is_content_seo,sort_id,is_channel_img,channel_img,is_channel_descript,channel_descript from " + databaseprefix + "channel ");
            strSql.Append(" where name=@name ");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,250)};
            parameters[0].Value = channel_name;

            Model.channel model = new Model.channel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                #region  父表信息
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["category_id"].ToString() != "")
                {
                    model.category_id = int.Parse(ds.Tables[0].Rows[0]["category_id"].ToString());
                }
                model.name = ds.Tables[0].Rows[0]["name"].ToString();
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.content_name = ds.Tables[0].Rows[0]["content_name"].ToString();
                model.category_name = ds.Tables[0].Rows[0]["category_name"].ToString();
                model.comment_name = ds.Tables[0].Rows[0]["comment_name"].ToString();
                model.recom_type = ds.Tables[0].Rows[0]["recom_type"].ToString();
                if (ds.Tables[0].Rows[0]["is_cover"].ToString() != "")
                {
                    model.is_cover = int.Parse(ds.Tables[0].Rows[0]["is_cover"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_albums"].ToString() != "")
                {
                    model.is_albums = int.Parse(ds.Tables[0].Rows[0]["is_albums"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_attach"].ToString() != "")
                {
                    model.is_attach = int.Parse(ds.Tables[0].Rows[0]["is_attach"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_comment"].ToString() != "")
                {
                    model.is_comment = int.Parse(ds.Tables[0].Rows[0]["is_comment"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_customer"].ToString() != "")
                {
                    model.is_customer = int.Parse(ds.Tables[0].Rows[0]["is_customer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_group_price"].ToString() != "")
                {
                    model.is_group_price = int.Parse(ds.Tables[0].Rows[0]["is_group_price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["page_size"].ToString() != "")
                {
                    model.page_size = int.Parse(ds.Tables[0].Rows[0]["page_size"].ToString());
                }
                if (ds.Tables[0].Rows[0]["deep_layer"].ToString() != "")
                {
                    model.deep_layer = int.Parse(ds.Tables[0].Rows[0]["deep_layer"].ToString());
                }
                if (ds.Tables[0].Rows[0]["attach_size"].ToString() != "")
                {
                    model.attach_size = int.Parse(ds.Tables[0].Rows[0]["attach_size"].ToString());
                }
                if (ds.Tables[0].Rows[0]["img_size"].ToString() != "")
                {
                    model.img_size = int.Parse(ds.Tables[0].Rows[0]["img_size"].ToString());
                }
                if (ds.Tables[0].Rows[0]["img_maxheight"].ToString() != "")
                {
                    model.img_maxheight = int.Parse(ds.Tables[0].Rows[0]["img_maxheight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["img_maxwidth"].ToString() != "")
                {
                    model.img_maxwidth = int.Parse(ds.Tables[0].Rows[0]["img_maxwidth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["thumbnail_height"].ToString() != "")
                {
                    model.thumbnail_height = int.Parse(ds.Tables[0].Rows[0]["thumbnail_height"].ToString());
                }
                if (ds.Tables[0].Rows[0]["thumbnail_width"].ToString() != "")
                {
                    model.thumbnail_width = int.Parse(ds.Tables[0].Rows[0]["thumbnail_width"].ToString());
                }
                if (ds.Tables[0].Rows[0]["beyond_type"].ToString() != "")
                {
                    model.beyond_type = int.Parse(ds.Tables[0].Rows[0]["beyond_type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_category_call"].ToString() != "")
                {
                    model.is_category_call = int.Parse(ds.Tables[0].Rows[0]["is_category_call"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_category_link"].ToString() != "")
                {
                    model.is_category_link = int.Parse(ds.Tables[0].Rows[0]["is_category_link"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_category_into"].ToString() != "")
                {
                    model.is_category_into = int.Parse(ds.Tables[0].Rows[0]["is_category_into"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_category_seo"].ToString() != "")
                {
                    model.is_category_seo = int.Parse(ds.Tables[0].Rows[0]["is_category_seo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_category_img"].ToString() != "")
                {
                    model.is_category_img = int.Parse(ds.Tables[0].Rows[0]["is_category_img"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_content_call"].ToString() != "")
                {
                    model.is_content_call = int.Parse(ds.Tables[0].Rows[0]["is_content_call"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_content_link"].ToString() != "")
                {
                    model.is_content_link = int.Parse(ds.Tables[0].Rows[0]["is_content_link"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_content_into"].ToString() != "")
                {
                    model.is_content_into = int.Parse(ds.Tables[0].Rows[0]["is_content_into"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_content_seo"].ToString() != "")
                {
                    model.is_content_seo = int.Parse(ds.Tables[0].Rows[0]["is_content_seo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_channel_img"].ToString() != "")
                {
                    model.is_channel_img = int.Parse(ds.Tables[0].Rows[0]["is_channel_img"].ToString());
                }
                model.channel_img = ds.Tables[0].Rows[0]["channel_img"].ToString();
                if (ds.Tables[0].Rows[0]["is_channel_descript"].ToString() != "")
                {
                    model.is_channel_descript = int.Parse(ds.Tables[0].Rows[0]["is_channel_descript"].ToString());
                }
                model.channel_descript = ds.Tables[0].Rows[0]["channel_descript"].ToString();
                #endregion  父表信息end

                #region  子表信息
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("select id,channel_id,field_id from " + databaseprefix + "channel_field ");
                strSql2.Append(" where channel_id=@channel_id ");
                SqlParameter[] parameters2 = {
					new SqlParameter("@channel_id", SqlDbType.Int,4)};
                parameters2[0].Value = model.id;

                DataSet ds2 = DbHelperSQL.Query(strSql2.ToString(), parameters2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    int i = ds2.Tables[0].Rows.Count;
                    List<Model.channel_field> models = new List<Model.channel_field>();
                    Model.channel_field modelt;
                    for (int n = 0; n < i; n++)
                    {
                        modelt = new Model.channel_field();
                        if (ds2.Tables[0].Rows[n]["id"].ToString() != "")
                        {
                            modelt.id = int.Parse(ds2.Tables[0].Rows[n]["id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["channel_id"].ToString() != "")
                        {
                            modelt.channel_id = int.Parse(ds2.Tables[0].Rows[n]["channel_id"].ToString());
                        }
                        if (ds2.Tables[0].Rows[n]["field_id"].ToString() != "")
                        {
                            modelt.field_id = int.Parse(ds2.Tables[0].Rows[n]["field_id"].ToString());
                        }
                        models.Add(modelt);
                    }
                    model.channel_fields = models;
                }
                #endregion  子表信息end

                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获取分页大小
        /// </summary>
        public int GetPageSize(string channel_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 page_size FROM " + databaseprefix + "channel");
            strSql.Append(" where name=@name");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50)};
            parameters[0].Value = channel_name;

            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString(), parameters));
        }
        /// <summary>
        /// 删除已移除的频道扩展字段
        /// </summary>
        public void FieldDelete(SqlConnection conn, SqlTransaction trans, List<Model.channel_field> models, int channel_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,field_id from " + databaseprefix + "channel_field");
            strSql.Append(" where channel_id=" + channel_id);
            DataSet ds = DbHelperSQL.Query(conn, trans, strSql.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Model.channel_field model = models.Find(p => p.field_id == int.Parse(dr["field_id"].ToString())); //查找对应的字段ID
                if (model == null)
                {
                    DbHelperSQL.ExecuteSql(conn, trans, "delete from " + databaseprefix + "channel_field where channel_id=" + channel_id + " and field_id=" + dr["field_id"].ToString()); //删除该字段
                }
            }
        }
        /// <summary>
        /// 删除及重建该频道视图
        /// </summary>
        public void RehabChannelViews(SqlConnection conn, SqlTransaction trans, Model.channel model, string old_name)
        {
            //删除旧的视图
            StringBuilder strSql1 = new StringBuilder();
            //strSql1.Append("if exists (select 1 from sysobjects where id = object_id('view_channel_" + old_name + "') and type = 'V')");
            strSql1.Append("drop VIEW view_channel_" + old_name);
            DbHelperSQL.ExecuteSql(conn, trans, strSql1.ToString());
            //添加视图
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("CREATE VIEW view_channel_" + model.name + " AS");
            strSql2.Append(" SELECT " + databaseprefix + "article.*");
            if (model.channel_fields != null)
            {
                foreach (Model.channel_field modelt in model.channel_fields)
                {
                    Model.article_attribute_field fieldModel = new DAL.article_attribute_field(databaseprefix).GetModel(modelt.field_id);
                    if (fieldModel != null)
                    {
                        strSql2.Append("," + databaseprefix + "article_attribute_value." + fieldModel.name);
                    }
                }
            }
            if (model.deep_layer > 0)
            {
                strSql2.Append("," + databaseprefix + "article_category.title AS category_title");
            }
            strSql2.Append(" FROM ");
            if (model.channel_fields != null && model.channel_fields.Count > 0)
            {
                strSql2.Append(" (" + databaseprefix + "article_attribute_value INNER JOIN");
                strSql2.Append(" " + databaseprefix + "article ON " + databaseprefix + "article_attribute_value.article_id = " + databaseprefix + "article.id)");
                if (model.deep_layer > 0)
                {
                    strSql2.Append(" INNER JOIN " + databaseprefix + "article_category ON " + databaseprefix + "article.category_id = " + databaseprefix + "article_category.id");
                }
            }
            else
            {
                if (model.deep_layer > 0)
                {
                    strSql2.Append(" " + databaseprefix + "article_category INNER JOIN");
                    strSql2.Append(" " + databaseprefix + "article ON " + databaseprefix + "article.category_id = " + databaseprefix + "article_category.id");
                }
                else
                {
                    strSql2.Append(" " + databaseprefix + "article");
                }
            }
            //strSql2.Append(" FROM (" + databaseprefix + "article_attribute_value INNER JOIN");
            //strSql2.Append(" " + databaseprefix + "article ON " + databaseprefix + "article_attribute_value.article_id = " + databaseprefix + "article.id)");
            //if (model.deep_layer > 0)
            //{
            //    strSql2.Append(" INNER JOIN " + databaseprefix + "article_category ON " + databaseprefix + "article.category_id = " + databaseprefix + "article_category.id");
            //}
            strSql2.Append(" WHERE " + databaseprefix + "article.channel_id=" + model.id);
            DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString());
        }
        #endregion
    }
}