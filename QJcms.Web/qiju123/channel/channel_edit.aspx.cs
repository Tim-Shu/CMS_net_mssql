using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QJcms.Common;

namespace QJcms.Web.admin.channel
{
    public partial class channel_edit : Web.UI.ManagePage
    {
        private string action = QJEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = QJRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == QJEnums.ActionEnum.Edit.ToString())
            {
                this.action = QJEnums.ActionEnum.Edit.ToString();//修改类型
                this.id = QJRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.channel().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("site_channel_list", QJEnums.ActionEnum.View.ToString()); //检查权限
                TreeBind(); //绑定类别
                FieldBind(); //绑定扩展字段
                if (action == QJEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                else
                {
                    txtTitle.Attributes.Add("onBlur", "change2cn(this.value, this.form.txtName)");
                    txtName.Attributes.Add("ajaxurl", "../../tools/admin_ajax.ashx?action=channel_validate");
                }
            }
        }

        #region 返回页面的类型===========================
        protected string GetPageTypeTxt(string type_name)
        {
            string result = "";
            switch (type_name)
            {
                case "index":
                    result = "首页";
                    break;
                case "category":
                    result = "栏目页";
                    break;
                case "list":
                    result = "列表页";
                    break;
                case "detail":
                    result = "详细页";
                    break;
            }
            return result;
        }
        #endregion

        #region 返回页面继承类===========================
        private string GetInherit(string page_type)
        {
            string result = "";
            switch (page_type)
            {
                case "index":
                    result = "QJcms.Web.UI.Page.article";
                    break;
                case "category":
                    result = "QJcms.Web.UI.Page.category";
                    break;
                case "list":
                    result = "QJcms.Web.UI.Page.article_list";
                    break;
                case "detail":
                    result = "QJcms.Web.UI.Page.article_show";
                    break;
            }
            return result;
        }
        #endregion

        #region 绑定类别=================================
        private void TreeBind()
        {
            BLL.channel_category bll = new BLL.channel_category();
            DataTable dt = bll.GetList(0, "", "sort_id asc,id desc").Tables[0];

            this.ddlCategoryId.Items.Clear();
            this.ddlCategoryId.Items.Add(new ListItem("请选择类别...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                this.ddlCategoryId.Items.Add(new ListItem(dr["title"].ToString(), dr["id"].ToString()));
            }
        }
        #endregion

        #region 绑定扩展字段=============================
        private void FieldBind()
        {
            BLL.article_attribute_field bll = new BLL.article_attribute_field();
            DataTable dt = bll.GetList(0, "", "sort_id asc,id desc").Tables[0];

            this.cblAttributeField.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                this.cblAttributeField.Items.Add(new ListItem(dr["title"].ToString(), dr["id"].ToString()));
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.channel bll = new BLL.channel();
            Model.channel model = bll.GetModel(_id);

            txtTitle.Text = model.title;
            txtName.Text = model.name;
            txtName.Attributes.Add("ajaxurl", "../../tools/admin_ajax.ashx?action=channel_validate&old_channel_name=" + Utils.UrlEncode(model.name));
            txtName.Focus(); //设置焦点，防止JS无法提交
            ddlCategoryId.SelectedValue = model.category_id.ToString();
            txtContentName.Text = model.content_name;
            txtCagegoryName.Text = model.category_name;
            txtCommentName.Text = model.comment_name;
            txtPageSize.Text = model.page_size.ToString();
            txtDeepLayer.Text = model.deep_layer.ToString();
            txtSortId.Text = model.sort_id.ToString();
            #region 功能权限配置
            if (model.is_channel_img == 1) { cbIsChannelImg.Checked = true; }
            if (model.is_channel_descript == 1) { cbIsChannelDesc.Checked = true; }
            if (model.is_cover == 1) { cbIsCover.Checked = true; }
            if (model.is_albums == 1) { cbIsAlbums.Checked = true; }
            if (model.is_attach == 1) { cbIsAttach.Checked = true; }
            if (model.is_comment == 1) { cbIsComment.Checked = true; }
            if (model.is_customer == 1) { cbIsCustomer.Checked = true; }
            if (siteConfig.memberstatus == 1 && siteConfig.membergroupstatus == 1)
            {
                if (model.is_group_price == 1)
                {
                    cbIsGroupPrice.Checked = true;
                }
            }
            else
            {
                dlIsGroupPrice.Visible = false;
            }
            foreach (ListItem item in cblRecomItem.Items)
            {
                bool exist = model.recom_type.Contains(item.Value);
                if (exist)
                {
                    item.Selected = true;
                }
            }
            #endregion
            #region 类别权限配置
            if (model.is_category_call == 1) { cbCategoryCall.Checked = true; }
            if (model.is_category_link == 1) { cbCategoryLink.Checked = true; }
            if (model.is_category_into == 1) { cbCategoryInto.Checked = true; }
            if (model.is_category_seo == 1) { cbCategorySeo.Checked = true; }
            rblCategoryPhoto.SelectedValue = model.is_category_img.ToString();
            #endregion
            #region 内容权限配置
            if (model.is_content_call == 1) { cbContentCall.Checked = true; }
            if (model.is_content_link == 1) { cbContentLink.Checked = true; }
            if (model.is_content_into == 1) { cbContentInto.Checked = true; }
            if (model.is_content_seo == 1) { cbContentSeo.Checked = true; }
            #endregion
            #region 上传配置
            txtAttachSize.Text = model.attach_size.ToString();
            txtImgSize.Text = model.img_size.ToString();
            txtImgMaxHeight.Text = model.img_maxheight.ToString();
            txtImgMaxWidth.Text = model.img_maxwidth.ToString();
            txtThumbnailHeight.Text = model.thumbnail_height.ToString();
            txtThumbnailWidth.Text = model.thumbnail_width.ToString();
            rblBeyond.SelectedValue = model.beyond_type.ToString();
            #endregion

            //赋值扩展字段
            if (model.channel_fields != null)
            {
                for (int i = 0; i < cblAttributeField.Items.Count; i++)
                {
                    Model.channel_field modelt = model.channel_fields.Find(p => p.field_id == int.Parse(cblAttributeField.Items[i].Value)); //查找对应的字段ID
                    if (modelt != null)
                    {
                        cblAttributeField.Items[i].Selected = true;
                    }
                }
            }

            //绑定URL配置列表
            rptList.DataSource = new BLL.url_rewrite().GetList(model.name);
            rptList.DataBind();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.channel model = new Model.channel();
            BLL.channel bll = new BLL.channel();

            model.category_id = Utils.StrToInt(ddlCategoryId.SelectedValue, 0);
            model.name = txtName.Text.Trim();
            model.title = txtTitle.Text.Trim();
            model.content_name = txtContentName.Text.Trim();
            model.category_name = txtCagegoryName.Text.Trim();
            model.page_size = Utils.StrToInt(txtPageSize.Text.Trim(), 10);
            model.deep_layer = Utils.StrToInt(txtDeepLayer.Text.Trim(), 0);
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);
            #region 功能权限配置
            if (cbIsChannelImg.Checked) { model.is_channel_img = 1; }
            if (cbIsChannelDesc.Checked) { model.is_channel_descript = 1; }
            if (cbIsCover.Checked) { model.is_cover = 1; }
            if (cbIsAlbums.Checked) { model.is_albums = 1; }
            if (cbIsAttach.Checked) { model.is_attach = 1; }
            if (cbIsComment.Checked)
            {
                model.is_comment = 1;
                model.comment_name = txtCommentName.Text.Trim();
            }
            if (cbIsCustomer.Checked) { model.is_customer = 1; }
            if (siteConfig.memberstatus == 1 && siteConfig.membergroupstatus == 1)
            {
                if (cbIsGroupPrice.Checked)
                {
                    model.is_group_price = 1;
                }
            }
            foreach (ListItem item in cblRecomItem.Items)
            {
                if (item.Selected)
                {
                    model.recom_type += item.Value + ",";
                }
            }
            model.recom_type = Utils.DelLastChar(model.recom_type, ",");
            #endregion
            #region 类别权限配置
            if (cbCategoryCall.Checked) { model.is_category_call = 1; }
            if (cbCategoryLink.Checked) { model.is_category_link = 1; }
            if (cbCategoryInto.Checked) { model.is_category_into = 1; }
            if (cbCategorySeo.Checked) { model.is_category_seo = 1; }
            model.is_category_img = Utils.StrToInt(rblCategoryPhoto.SelectedValue, 0);
            #endregion
            #region 内容权限配置
            if (cbContentCall.Checked) { model.is_content_call = 1; }
            if (cbContentLink.Checked) { model.is_content_link = 1; }
            if (cbContentInto.Checked) { model.is_content_into = 1; }
            if (cbContentSeo.Checked) { model.is_content_seo = 1; }
            #endregion
            #region 上传配置
            model.attach_size = Utils.StrToInt(txtAttachSize.Text, 0);
            model.img_size = Utils.StrToInt(txtImgSize.Text, 0);
            model.img_maxheight = Utils.StrToInt(txtImgMaxHeight.Text, 0);
            model.img_maxwidth = Utils.StrToInt(txtImgMaxWidth.Text, 0);
            model.thumbnail_height = Utils.StrToInt(txtThumbnailHeight.Text, 0);
            model.thumbnail_width = Utils.StrToInt(txtThumbnailWidth.Text, 0);
            model.beyond_type = Utils.StrToInt(rblBeyond.SelectedValue, 1);
            #endregion

            //添加频道扩展字段
            List<Model.channel_field> ls = new List<Model.channel_field>();
            for (int i = 0; i < cblAttributeField.Items.Count; i++)
            {
                if (cblAttributeField.Items[i].Selected)
                {
                    ls.Add(new Model.channel_field { field_id = Utils.StrToInt(cblAttributeField.Items[i].Value, 0) });
                }
            }
            model.channel_fields = ls;

            if (bll.Add(model) < 1)
            {
                return false;
            }

            #region 保存URL配置
            BLL.url_rewrite urlBll = new BLL.url_rewrite();
            urlBll.Remove("channel", model.name); //先删除
            string[] itemTypeArr = Request.Form.GetValues("item_type");
            string[] itemNameArr = Request.Form.GetValues("item_name");
            string[] itemPageArr = Request.Form.GetValues("item_page");
            string[] itemTempletArr = Request.Form.GetValues("item_templet");
            string[] itemRewriteArr = Request.Form.GetValues("item_rewrite");

            if (itemTypeArr != null && itemNameArr != null && itemPageArr != null && itemTempletArr != null && itemRewriteArr != null)
            {
                if ((itemTypeArr.Length == itemNameArr.Length) && (itemNameArr.Length == itemPageArr.Length)
                    && (itemPageArr.Length == itemTempletArr.Length) && (itemTempletArr.Length == itemRewriteArr.Length))
                {
                    for (int i = 0; i < itemTypeArr.Length; i++)
                    {
                        Model.url_rewrite urlModel = new Model.url_rewrite();
                        urlModel.name = itemNameArr[i].Trim();
                        urlModel.type = itemTypeArr[i].Trim();
                        urlModel.page = itemPageArr[i].Trim();
                        urlModel.inherit = GetInherit(urlModel.type);
                        urlModel.templet = itemTempletArr[i].Trim();
                        urlModel.channel = model.name;

                        List<Model.url_rewrite_item> itemLs = new List<Model.url_rewrite_item>();
                        string[] urlRewriteArr = itemRewriteArr[i].Split('&'); //分解URL重写字符串
                        for (int j = 0; j < urlRewriteArr.Length; j++)
                        {
                            string[] urlItemArr = urlRewriteArr[j].Split(',');
                            if (urlItemArr.Length == 3)
                            {
                                itemLs.Add(new Model.url_rewrite_item { path = urlItemArr[0], pattern = urlItemArr[1], querystring = urlItemArr[2] });
                            }
                        }
                        urlModel.url_rewrite_items = itemLs;
                        urlBll.Add(urlModel);
                    }
                }
            }
            #endregion

            AddAdminLog(QJEnums.ActionEnum.Add.ToString(), "添加频道" + model.title); //记录日志
            return true;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            BLL.channel bll = new BLL.channel();
            Model.channel model = bll.GetModel(_id);

            string old_name = model.name;
            model.category_id = Utils.StrToInt(ddlCategoryId.SelectedValue, 0);
            model.name = txtName.Text.Trim();
            model.title = txtTitle.Text.Trim();
            model.content_name = txtContentName.Text.Trim();
            model.category_name = txtCagegoryName.Text.Trim();
            model.page_size = Utils.StrToInt(txtPageSize.Text.Trim(), 10);
            model.deep_layer = Utils.StrToInt(txtDeepLayer.Text.Trim(), 0);
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);
            #region 功能权限配置
            model.is_channel_img = model.is_channel_descript = model.is_cover = model.is_albums = model.is_attach = model.is_comment = model.is_customer = 0;
            if (cbIsChannelImg.Checked == true) { model.is_channel_img = 1; }
            if (cbIsChannelDesc.Checked == true) { model.is_channel_descript = 1; }
            if (cbIsCover.Checked == true) { model.is_cover = 1; }
            if (cbIsAlbums.Checked == true) { model.is_albums = 1; }
            if (cbIsAttach.Checked == true) { model.is_attach = 1; }
            if (cbIsComment.Checked == true)
            {
                model.is_comment = 1;
                model.comment_name = txtCommentName.Text.Trim();
            }
            if (cbIsCustomer.Checked == true) { model.is_customer = 1; }
            model.is_group_price = 0;
            if (siteConfig.memberstatus == 1 && siteConfig.membergroupstatus == 1)
            {
                if (cbIsGroupPrice.Checked == true)
                {
                    model.is_group_price = 1;
                }
            }
            model.recom_type = "";
            foreach (ListItem item in cblRecomItem.Items)
            {
                if (item.Selected)
                {
                    model.recom_type += item.Value + ",";
                }
            }
            model.recom_type = Utils.DelLastChar(model.recom_type, ",");
            #endregion
            #region 类别权限配置
            model.is_category_call = 0; model.is_category_link = 0; model.is_category_into = 0; model.is_category_seo = 0; model.is_category_img = 0;
            if (cbCategoryCall.Checked) { model.is_category_call = 1; }
            if (cbCategoryLink.Checked) { model.is_category_link = 1; }
            if (cbCategoryInto.Checked) { model.is_category_into = 1; }
            if (cbCategorySeo.Checked) { model.is_category_seo = 1; }
            model.is_category_img = Utils.StrToInt(rblCategoryPhoto.SelectedValue, 0);
            #endregion
            #region 内容权限配置
            model.is_content_call = 0; model.is_content_link = 0; model.is_content_into = 0; model.is_content_seo = 0;
            if (cbContentCall.Checked) { model.is_content_call = 1; }
            if (cbContentLink.Checked) { model.is_content_link = 1; }
            if (cbContentInto.Checked) { model.is_content_into = 1; }
            if (cbContentSeo.Checked) { model.is_content_seo = 1; }
            #endregion
            #region 上传配置
            model.attach_size = Utils.StrToInt(txtAttachSize.Text, 0);
            model.img_size = Utils.StrToInt(txtImgSize.Text, 0);
            model.img_maxheight = Utils.StrToInt(txtImgMaxHeight.Text, 0);
            model.img_maxwidth = Utils.StrToInt(txtImgMaxWidth.Text, 0);
            model.thumbnail_height = Utils.StrToInt(txtThumbnailHeight.Text, 0);
            model.thumbnail_width = Utils.StrToInt(txtThumbnailWidth.Text, 0);
            model.beyond_type = Utils.StrToInt(rblBeyond.SelectedValue, 1);
            #endregion
            //添加频道扩展字段
            List<Model.channel_field> ls = new List<Model.channel_field>();
            for (int i = 0; i < cblAttributeField.Items.Count; i++)
            {
                if (cblAttributeField.Items[i].Selected)
                {
                    ls.Add(new Model.channel_field { channel_id = model.id, field_id = Utils.StrToInt(cblAttributeField.Items[i].Value, 0) });
                }
            }
            model.channel_fields = ls;

            if (!bll.Update(model))
            {
                return false;
            }

            #region 保存URL配置
            BLL.url_rewrite urlBll = new BLL.url_rewrite();
            urlBll.Remove("channel", old_name); //先删除旧的
            string[] itemTypeArr = Request.Form.GetValues("item_type");
            string[] itemNameArr = Request.Form.GetValues("item_name");
            string[] itemPageArr = Request.Form.GetValues("item_page");
            string[] itemTempletArr = Request.Form.GetValues("item_templet");
            string[] itemRewriteArr = Request.Form.GetValues("item_rewrite");

            if (itemTypeArr != null && itemNameArr != null && itemPageArr != null && itemTempletArr != null && itemRewriteArr != null)
            {
                if ((itemTypeArr.Length == itemNameArr.Length) && (itemNameArr.Length == itemPageArr.Length)
                    && (itemPageArr.Length == itemTempletArr.Length) && (itemTempletArr.Length == itemRewriteArr.Length))
                {
                    for (int i = 0; i < itemTypeArr.Length; i++)
                    {
                        Model.url_rewrite urlModel = new Model.url_rewrite();
                        urlModel.name = itemNameArr[i].Trim();
                        urlModel.type = itemTypeArr[i].Trim();
                        urlModel.page = itemPageArr[i].Trim();
                        urlModel.inherit = GetInherit(urlModel.type);
                        urlModel.templet = itemTempletArr[i].Trim();
                        urlModel.channel = model.name;

                        List<Model.url_rewrite_item> itemLs = new List<Model.url_rewrite_item>();
                        string[] urlRewriteArr = itemRewriteArr[i].Split('&'); //分解URL重写字符串
                        for (int j = 0; j < urlRewriteArr.Length; j++)
                        {
                            string[] urlItemArr = urlRewriteArr[j].Split(',');
                            if (urlItemArr.Length == 3)
                            {
                                itemLs.Add(new Model.url_rewrite_item { path = urlItemArr[0], pattern = urlItemArr[1], querystring = urlItemArr[2] });
                            }
                        }
                        urlModel.url_rewrite_items = itemLs;
                        urlBll.Add(urlModel);
                    }
                }
            }
            #endregion

            AddAdminLog(QJEnums.ActionEnum.Edit.ToString(), "修改频道" + model.title); //记录日志
            return true;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == QJEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("site_channel_list", QJEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改频道信息成功！", "channel_list.aspx", "Success", "parent.loadMenuTree");
            }
            else //添加
            {
                ChkAdminLevel("site_channel_list", QJEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加频道信息成功！", "channel_list.aspx", "Success", "parent.loadMenuTree");
            }
        }
    }
}