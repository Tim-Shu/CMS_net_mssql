using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QJcms.Common;

namespace QJcms.Web.admin.article
{
    public partial class category_edit : Web.UI.ManagePage
    {
        private string action = QJEnums.ActionEnum.Add.ToString(); //操作类型
        protected string channel_name = string.Empty; //频道名称
        protected int channel_id;
        protected bool isWater = false;
        protected bool isThumbnail = false;
        protected int upImgSize = 0;
        private int id = 0;
        private Model.channel chanModel = new Model.channel();
        private bool isSys = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = QJRequest.GetQueryString("action");
            this.channel_id = QJRequest.GetQueryInt("channel_id");
            this.id = QJRequest.GetQueryInt("id");

            if (this.channel_id == 0)
            {
                JscriptMsg("频道参数不正确！", "back", "Error");
                return;
            }
            chanModel = new BLL.channel().GetModel(channel_id);
            this.channel_name = chanModel.name; //取得频道名称
            if (!string.IsNullOrEmpty(_action) && _action == QJEnums.ActionEnum.Edit.ToString())
            {
                this.action = QJEnums.ActionEnum.Edit.ToString();//修改类型
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.article_category().Exists(this.id))
                {
                    JscriptMsg("类别不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("channel_" + this.channel_name + "_category", QJEnums.ActionEnum.View.ToString()); //检查权限
                if (chanModel.deep_layer > 1)
                {
                    TreeBind(this.channel_id); //绑定类别
                }
                if (action == QJEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                else
                {
                    if (this.id > 0)
                    {
                        this.ddlParentId.SelectedValue = this.id.ToString();
                    }
                }
            }
            ChannelBind();
        }

        /// <summary>
        /// 配置频道权限
        /// </summary>
        private void ChannelBind()
        {
            Model.manager rolemodel = GetAdminInfo();
            BLL.manager_role rolebll = new BLL.manager_role();
            isSys = rolebll.Exists(rolemodel.role_id, "channel_" + this.channel_name + "_category", QJEnums.ActionEnum.System.ToString());
            if (!isSys)
            {
                dlSystem.Visible = false;
            }
            if (chanModel.deep_layer <= 1)
            {
                ddlParentId.Visible = false;
                dlParent.Visible = false;
            }
            if (chanModel.is_category_call == 0) { dlCall.Visible = false; }
            else { txtTitle.Attributes.Add("onBlur", "change2cn(this.value, this.form.txtCallIndex)"); }
            if (chanModel.is_category_link == 0) { dlLink.Visible = false; }
            if (chanModel.is_category_into == 0) { tab_into.Visible = false; content_into.Visible = false; }
            if (chanModel.is_category_seo == 0) { tab_seo.Visible = false; content_seo.Visible = false; }
            switch (chanModel.is_category_img)
            {
                case 1:
                    dlImg.Visible = true;
                    dlAlbums.Visible = false;
                    break;
                case 2:
                    dlImg.Visible = false;
                    dlAlbums.Visible = true;
                    break;
                default:
                    dlImg.Visible = false;
                    dlAlbums.Visible = false;
                    break;
            }
            if (chanModel.is_category_img > 0)
            {
                isWater = siteConfig.watermarkstatus == 1 ? true : false;
                if (chanModel.thumbnail_height > 0 || chanModel.thumbnail_width > 0)
                {
                    isThumbnail = true;
                }
                switch (chanModel.img_size)
                {
                    case 0:
                        upImgSize = siteConfig.imgsize;
                        break;
                    case 1:
                        upImgSize = 0;
                        break;
                    default:
                        upImgSize = chanModel.img_size;
                        break;
                }
            }
        }

        #region 绑定类别=================================
        private void TreeBind(int _channel_id)
        {
            BLL.article_category bll = new BLL.article_category();
            DataTable dt = bll.GetList(0, _channel_id);
            this.ddlParentId.Items.Clear();
            this.ddlParentId.Items.Add(new ListItem("无父级分类", "0"));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                int ClassLayer = int.Parse(dr["class_layer"].ToString());
                string Title = dr["title"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    this.ddlParentId.Items.Add(new ListItem(Title, Id));
                }
                else
                {
                    Title = "├ " + Title;
                    Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                    this.ddlParentId.Items.Add(new ListItem(Title, Id));
                }
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.article_category bll = new BLL.article_category();
            Model.article_category model = bll.GetModel(_id);

            if (chanModel.deep_layer > 1) { ddlParentId.SelectedValue = model.parent_id.ToString(); }
            if (chanModel.is_category_call == 1)
            {
                txtCallIndex.Text = model.call_index;
                if (model.call_index != "") txtCallIndex.Enabled = false;
            }
            txtTitle.Text = model.title;
            txtSubTitle.Text = model.sub_title;
            if (model.is_sys == 1)
            {
                cbIsSys.Checked = true;
            }
            txtSortId.Text = model.sort_id.ToString();
            if (chanModel.is_category_seo == 1)
            {
                txtSeoTitle.Text = model.seo_title;
                txtSeoKeywords.Text = model.seo_keywords;
                txtSeoDescription.Text = model.seo_description;
            }
            if (chanModel.is_category_link == 1) { txtLinkUrl.Text = model.link_url; }
            if (chanModel.is_category_img == 1) { txtImgUrl.Text = model.img_url; }
            else if (chanModel.is_category_img == 2)
            {
                //绑定图片相册
                hidFocusPhoto.Value = model.img_url; //封面图片
                rptAlbumList.DataSource = model.albums;
                rptAlbumList.DataBind();
            }
            if (chanModel.is_category_into == 1) { txtContent.Value = model.content; }
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            try
            {
                Model.article_category model = new Model.article_category();
                BLL.article_category bll = new BLL.article_category();
                model.channel_id = this.channel_id;
                model.title = txtTitle.Text.Trim();
                model.sub_title = txtSubTitle.Text.Trim();
                if (isSys && cbIsSys.Checked)
                {
                    model.is_sys = 1; //默认可以删除
                }
                if (chanModel.deep_layer > 1)
                {
                    model.parent_id = int.Parse(ddlParentId.SelectedValue);
                }
                else { model.parent_id = 0; }
                model.sort_id = int.Parse(txtSortId.Text.Trim());
                if (chanModel.is_category_call == 1) { model.call_index = txtCallIndex.Text.Trim(); }
                if (chanModel.is_category_seo == 1)
                {
                    model.seo_title = txtSeoTitle.Text;
                    model.seo_keywords = txtSeoKeywords.Text;
                    model.seo_description = txtSeoDescription.Text;
                }
                if (chanModel.is_category_link == 1) { model.link_url = txtLinkUrl.Text.Trim(); }
                if (chanModel.is_category_img == 1) { model.img_url = txtImgUrl.Text.Trim(); }
                else if (chanModel.is_category_img == 2)
                {
                    #region 保存相册====================
                    model.img_url = hidFocusPhoto.Value;
                    string[] albumArr = Request.Form.GetValues("hid_photo_name");
                    string[] remarkArr = Request.Form.GetValues("hid_photo_remark");
                    if (albumArr != null && albumArr.Length > 0)
                    {
                        List<Model.article_category_albums> ls = new List<Model.article_category_albums>();
                        for (int i = 0; i < albumArr.Length; i++)
                        {
                            string[] imgArr = albumArr[i].Split('|');
                            if (imgArr.Length == 3)
                            {
                                if (!string.IsNullOrEmpty(remarkArr[i]))
                                {
                                    ls.Add(new Model.article_category_albums { original_path = imgArr[1], thumb_path = imgArr[2], remark = remarkArr[i] });
                                }
                                else
                                {
                                    ls.Add(new Model.article_category_albums { original_path = imgArr[1], thumb_path = imgArr[2] });
                                }
                            }
                        }
                        model.albums = ls;
                    }
                    #endregion
                }
                if (chanModel.is_category_into == 1) { model.content = txtContent.Value; }
                if (bll.Add(model) > 0)
                {
                    AddAdminLog(QJEnums.ActionEnum.Add.ToString(), "添加" + this.channel_name + "频道栏目分类:" + model.title); //记录日志
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            try
            {
                BLL.article_category bll = new BLL.article_category();
                Model.article_category model = bll.GetModel(_id);
                int parentId = 0;
                if (chanModel.deep_layer > 1)
                {
                    parentId = int.Parse(ddlParentId.SelectedValue);
                }

                model.channel_id = this.channel_id;
                model.title = txtTitle.Text.Trim();
                model.sub_title = txtSubTitle.Text.Trim();
                if (isSys)
                {
                    if (cbIsSys.Checked)
                    {
                        model.is_sys = 1; //默认可以删除
                    }
                    else { model.is_sys = 0; }
                }
                //如果选择的父ID不是自己,则更改
                if (parentId != model.parent_id)
                {
                    model.parent_id = parentId;
                }
                model.sort_id = int.Parse(txtSortId.Text.Trim());
                if (chanModel.is_category_call == 1) { model.call_index = txtCallIndex.Text.Trim(); }
                else { model.call_index = ""; }
                if (chanModel.is_category_seo == 1)
                {
                    model.seo_title = txtSeoTitle.Text;
                    model.seo_keywords = txtSeoKeywords.Text;
                    model.seo_description = txtSeoDescription.Text;
                }
                else
                {
                    model.seo_title = "";
                    model.seo_keywords = "";
                    model.seo_description = "";
                }
                if (chanModel.is_category_link == 1) { model.link_url = txtLinkUrl.Text.Trim(); }
                else { model.link_url = ""; }
                switch (chanModel.is_category_img)
                {
                    case 0:
                        model.img_url = "";
                        break;
                    case 1:
                        model.img_url = txtImgUrl.Text.Trim();
                        break;
                    case 2:
                        #region 保存相册====================
                        model.img_url = hidFocusPhoto.Value;
                        if (model.albums != null)
                        {
                            model.albums.Clear();
                        }
                        string[] albumArr = Request.Form.GetValues("hid_photo_name");
                        string[] remarkArr = Request.Form.GetValues("hid_photo_remark");
                        if (albumArr != null)
                        {
                            List<Model.article_category_albums> ls = new List<Model.article_category_albums>();
                            for (int i = 0; i < albumArr.Length; i++)
                            {
                                string[] imgArr = albumArr[i].Split('|');
                                int img_id = Utils.StrToInt(imgArr[0], 0);
                                if (imgArr.Length == 3)
                                {
                                    if (!string.IsNullOrEmpty(remarkArr[i]))
                                    {
                                        ls.Add(new Model.article_category_albums { id = img_id, category_id = _id, original_path = imgArr[1], thumb_path = imgArr[2], remark = remarkArr[i] });
                                    }
                                    else
                                    {
                                        ls.Add(new Model.article_category_albums { id = img_id, category_id = _id, original_path = imgArr[1], thumb_path = imgArr[2] });
                                    }
                                }
                            }
                            model.albums = ls;
                        }
                        #endregion
                        break;
                    default:
                        model.img_url = "";
                        break;
                }
                if (chanModel.is_category_into == 1) { model.content = txtContent.Value; }
                else { model.content = ""; }
                if (bll.Update(model))
                {
                    AddAdminLog(QJEnums.ActionEnum.Edit.ToString(), "修改" + this.channel_name + "频道栏目分类:" + model.title); //记录日志
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        #endregion

        //保存类别
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == QJEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("channel_" + this.channel_name + "_category", QJEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {

                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改类别成功！", "category_list.aspx?channel_id=" + channel_id, "Success");
            }
            else //添加
            {
                ChkAdminLevel("channel_" + this.channel_name + "_category", QJEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加类别成功！", "category_list.aspx?channel_id=" + channel_id, "Success");
            }
        }

    }
}