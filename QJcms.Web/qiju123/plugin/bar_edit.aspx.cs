using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using QJcms.Common;

namespace QJcms.Web.admin.plugin
{
    public partial class bar_edit : Web.UI.ManagePage
    {
        private string action = QJEnums.ActionEnum.Add.ToString(); //操作类型
        protected int aid = 0; //广告位ID
        protected int id = 0;

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
                if (!new BLL.advert_banner().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            else
            {
                this.aid = QJRequest.GetQueryInt("aid");
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("tools_advert", QJEnums.ActionEnum.View.ToString()); //检查权限
                TreeBind(); //绑定广告位
                if (action == QJEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                else if (this.aid > 0)
                {
                    ddlAdvertId.SelectedValue = this.aid.ToString();
                }
            }
        }

        #region 绑定广告位===============================
        private void TreeBind()
        {
            BLL.advert bll = new BLL.advert();
            DataTable dt = bll.GetList("").Tables[0];

            this.ddlAdvertId.Items.Clear();
            this.ddlAdvertId.Items.Add(new ListItem("所有广告位", ""));
            foreach (DataRow dr in dt.Rows)
            {
                this.ddlAdvertId.Items.Add(new ListItem(dr["title"].ToString(), dr["id"].ToString()));
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.advert_banner bll = new BLL.advert_banner();
            Model.advert_banner model = bll.GetModel(_id);

            this.aid = model.aid;
            ddlAdvertId.SelectedValue = model.aid.ToString();
            txtTitle.Text = model.title;
            rblIsLock.SelectedValue = model.is_lock.ToString();
            txtSortId.Text = model.sort_id.ToString();
            if (model.start_time.ToString("yyyy-MM-dd") == "1901-01-01" && model.end_time.ToString("yyyy-MM-dd") == "2099-12-31")
            {
                rblEffective.SelectedValue = "0";
            }
            else
            {
                rblEffective.SelectedValue = "1";
                timeEffective.Attributes.Add("style", "display:block;");
                txtStartTime.Text = model.start_time.ToString("yyyy-MM-dd");
                txtEndTime.Text = model.end_time.ToString("yyyy-MM-dd");
            }            
            txtLinkUrl.Text = model.link_url;
            txtFilePath.Text = model.file_path;
            txtContent.Text = model.content;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.advert_banner model = new Model.advert_banner();
            BLL.advert_banner bll = new BLL.advert_banner();

            model.aid = int.Parse(ddlAdvertId.SelectedValue);
            model.title = txtTitle.Text.Trim();
            if (rblEffective.SelectedValue == "0")
            {
                model.start_time = DateTime.Parse("1901-01-01");
                model.end_time = DateTime.Parse("2099-12-31");
            }
            else if (rblEffective.SelectedValue == "1")
            {
                model.start_time = DateTime.Parse(this.txtStartTime.Text.Trim());
                model.end_time = DateTime.Parse(this.txtEndTime.Text.Trim());
            }
            model.file_path = txtFilePath.Text.Trim();
            model.link_url = txtLinkUrl.Text.Trim();
            model.content = txtContent.Text;
            model.sort_id = int.Parse(txtSortId.Text.Trim());
            model.is_lock = int.Parse(rblIsLock.SelectedValue);
            model.add_time = DateTime.Now;
            this.aid = model.aid;

            if (bll.Add(model) > 0)
            {
                AddAdminLog(QJEnums.ActionEnum.Add.ToString(), "添加广告内容：" + model.title); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.advert_banner bll = new BLL.advert_banner();
            Model.advert_banner model = bll.GetModel(_id);

            model.aid = int.Parse(ddlAdvertId.SelectedValue);
            model.title = txtTitle.Text.Trim();
            if (rblEffective.SelectedValue == "0")
            {
                model.start_time = DateTime.Parse("1901-01-01");
                model.end_time = DateTime.Parse("2099-12-31");
            }
            else if (rblEffective.SelectedValue == "1")
            {
                model.start_time = DateTime.Parse(this.txtStartTime.Text.Trim());
                model.end_time = DateTime.Parse(this.txtEndTime.Text.Trim());
            }
            model.file_path = txtFilePath.Text.Trim();
            model.link_url = txtLinkUrl.Text.Trim();
            model.content = txtContent.Text;
            model.sort_id = int.Parse(txtSortId.Text.Trim());
            model.is_lock = int.Parse(rblIsLock.SelectedValue);
            this.aid = model.aid;

            if (bll.Update(model))
            {
                AddAdminLog(QJEnums.ActionEnum.Edit.ToString(), "修改广告内容：" + model.title); //记录日志
                result = true;
            }

            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == QJEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("tools_advert", QJEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("编辑成功！", "bar_list.aspx?aid=" + this.aid.ToString(), "Success");
            }
            else //添加
            {
                ChkAdminLevel("tools_advert", QJEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加成功！", "bar_list.aspx?aid=" + this.aid.ToString(), "Success");
            }
        }

    }
}