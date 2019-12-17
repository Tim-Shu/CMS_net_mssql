using QJcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QJcms.Web.admin.article
{
    public partial class article_multi_add : Web.UI.ManagePage
    {
        protected string action = QJEnums.ActionEnum.Add.ToString(); //操作类型
        protected string channel_name = string.Empty; //频道名称
        protected int channel_id;
        protected bool isWater = false;
        protected bool isThumbnail = false;
        protected int upImgSize = 0;
        protected Model.channel chanModel = new Model.channel();
        private bool isAlbum = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.channel_id = QJRequest.GetQueryInt("channel_id");
            string _action = QJRequest.GetQueryString("action");
            if (this.channel_id == 0)
            {
                JscriptMsg("频道参数不正确！", "back", "Error");
                return;
            }
            chanModel = new BLL.channel().GetModel(channel_id);
            this.channel_name = chanModel.name; //取得频道名称
            if (chanModel.is_albums == 1) { isAlbum = true; }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("channel_" + this.channel_name + "_list", QJEnums.ActionEnum.View.ToString()); //检查权限

                if (chanModel.deep_layer > 0)
                {
                    TreeBind(this.channel_id); //绑定类别
                    rblManner.Items.Add(new ListItem("类名", "2"));
                }
                else { dlCategory.Visible = false; }
            }
        }
        #region 绑定类别=================================
        private void TreeBind(int _channel_id)
        {
            BLL.article_category bll = new BLL.article_category();
            DataTable dt = bll.GetList(0, _channel_id);
            this.ddlCategoryId.Items.Clear();
            this.ddlCategoryId.Items.Add(new ListItem("请选择类别...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                int ClassLayer = int.Parse(dr["class_layer"].ToString());
                string Title = dr["title"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    this.ddlCategoryId.Items.Add(new ListItem(Title, Id));
                }
                else
                {
                    Title = "├ " + Title;
                    Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                    this.ddlCategoryId.Items.Add(new ListItem(Title, Id));
                }
            }
        }
        #endregion
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string strTitle = txtTitle.Text; string oldTitle = txtTitle.Text;
            int count = Regex.Matches(strTitle, @"#").Count;
            int start = Utils.StrToInt(txtStart.Text, 1);
            int manner_type = Utils.StrToInt(rblManner.SelectedValue, 0);
            string sChar = "", sCount = "";
            for (int s = 0; s < count; s++)
            {
                sChar += "#";
                sCount += "0";
            }
            string[] albumArr = Request.Form.GetValues("hid_photo_name");
            string[] titleArr = Request.Form.GetValues("hid_photo_title");
            string[] remarkArr = Request.Form.GetValues("hid_photo_remark");
            if (albumArr != null && albumArr.Length > 0)
            {
                for (int i = 0; i < albumArr.Length; i++)
                {
                    string[] imgArr = albumArr[i].Split('|');
                    if (imgArr.Length == 3)
                    {
                        switch (manner_type)
                        {
                            case 0:
                                strTitle = oldTitle.Replace(sChar, (start + i).ToString(sCount));
                                break;
                            case 1:
                                strTitle = titleArr[i].Remove(titleArr[i].LastIndexOf('.'));
                                break;
                            case 2:
                                strTitle = ddlCategoryId.SelectedItem.Text;
                                break;
                        }
                        addModels(strTitle, imgArr, remarkArr, i);
                    }
                }
            }
        }

        private void addModels(string _title, string[] _imgArr, string[] _remarkArr, int _index)
        {
            int category_id = Utils.StrToInt(ddlCategoryId.SelectedValue, 0);

            Model.article model = new Model.article();
            model.channel_id = channel_id;
            model.category_id = category_id;
            model.title = _title;
            model.img_url = _imgArr[1];
            model.content = "";
            if (!string.IsNullOrEmpty(_remarkArr[_index]))
            {
                model.content = _remarkArr[_index];
            }
            model.user_name = "admin"; //获得当前登录用户名
            model.add_time = DateTime.Now.AddSeconds(_index);
            model.fields = SetFieldValues(this.channel_id); //扩展字段赋值
            if (isAlbum)
            {
                List<Model.article_albums> ls = new List<Model.article_albums>();
                ls.Add(new Model.article_albums { original_path = _imgArr[1], thumb_path = _imgArr[2] });
                model.albums = ls;
            }
            new BLL.article().Add(model);
        }

        #region 扩展字段赋值=============================
        private Dictionary<string, string> SetFieldValues(int _channel_id)
        {
            DataTable dt = new BLL.article_attribute_field().GetList(_channel_id, "").Tables[0];
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (DataRow dr in dt.Rows)
            {
                //查找相应的控件
                switch (dr["control_type"].ToString())
                {
                    case "single-text": //单行文本
                        dic.Add(dr["name"].ToString(), "");
                        break;
                    case "multi-text": //多行文本
                        goto case "single-text";
                    case "editor": //编辑器
                        dic.Add(dr["name"].ToString(), "");
                        break;
                    case "images": //图片上传
                        goto case "single-text";
                    case "number": //数字
                        goto case "single-text";
                    case "checkbox": //复选框
                        dic.Add(dr["name"].ToString(), "0");
                        break;
                    case "multi-radio": //多项单选
                        dic.Add(dr["name"].ToString(), "");
                        break;
                    case "multi-checkbox": //多项多选
                        dic.Add(dr["name"].ToString(), "");
                        break;
                    case "data-property":
                        dic.Add(dr["name"].ToString(), "");
                        break;
                }
            }
            return dic;
        }
        #endregion
    }
}