using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QJcms.Common;

namespace QJcms.Web.admin.settings
{
    public partial class seo_edit : Web.UI.ManagePage
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
                if (!new BLL.seo_list().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("sys_seo", QJEnums.ActionEnum.View.ToString()); //检查权限
                if (action == QJEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.seo_list bll = new BLL.seo_list();
            Model.seo_list model = bll.GetModel(_id);
            txtCallIndex.Text = model.call_index;
            txtTitle.Text = model.title;
            txtSeoTitle.Text = model.seo_title;
            txtSeoKeywords.Text = model.seo_keywords;
            txtSeoDescription.Text = model.seo_description;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.seo_list model = new Model.seo_list();
            BLL.seo_list bll = new BLL.seo_list();
            model.call_index = txtCallIndex.Text.Trim();
            model.title = txtTitle.Text.Trim();
            model.seo_title = txtSeoTitle.Text;
            model.seo_keywords = txtSeoKeywords.Text;
            model.seo_description = txtSeoDescription.Text;
            if (bll.Add(model) > 0)
            {
                AddAdminLog(QJEnums.ActionEnum.Add.ToString(), "添加优化关键词：" + model.title); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.seo_list bll = new BLL.seo_list();
            Model.seo_list model = bll.GetModel(_id);
            Model.manager managerModel = GetAdminInfo();

            model.call_index = txtCallIndex.Text.Trim();
            model.title = txtTitle.Text.Trim();
            model.seo_title = txtSeoTitle.Text;
            model.seo_keywords = txtSeoKeywords.Text;
            model.seo_description = txtSeoDescription.Text;
            if (bll.Update(model))
            {
                AddAdminLog(QJEnums.ActionEnum.Edit.ToString(), "修改优化关键词：" + model.title); //记录日志
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
                ChkAdminLevel("sys_seo", QJEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改优化项目成功！", "seo_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("sys_seo", QJEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加优化项目成功！", "seo_list.aspx", "Success");
            }
        }
    }
}