using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QJcms.Common;

namespace QJcms.Web.admin.plugin
{
    public partial class search_keyword_edit : Web.UI.ManagePage
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
                if (!new BLL.search_keyword().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("tools_search_keyword", QJEnums.ActionEnum.View.ToString()); //检查权限
                if (action == QJEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.search_keyword bll = new BLL.search_keyword();
            Model.search_keyword model = bll.GetModel(_id);

            txtTitle.Text = model.title;
            txtLinkUrl.Text = model.link_url;
            rblIsLock.SelectedValue = model.is_lock.ToString();
            txtSortId.Text = model.sort_id.ToString();
            rblTarget.SelectedValue = model.target;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.search_keyword model = new Model.search_keyword();
            BLL.search_keyword bll = new BLL.search_keyword();
            model.title = txtTitle.Text.Trim();
            model.link_url = txtLinkUrl.Text.Trim();
            model.is_lock = Utils.StrToInt(rblIsLock.SelectedValue, 0);
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);
            model.target = rblTarget.SelectedValue;
            if (bll.Add(model) > 0)
            {
                AddAdminLog(QJEnums.ActionEnum.Add.ToString(), "添加关键词：" + model.title); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.search_keyword bll = new BLL.search_keyword();
            Model.search_keyword model = bll.GetModel(_id);
            model.title = txtTitle.Text.Trim();
            model.link_url = txtLinkUrl.Text.Trim();
            model.is_lock = Utils.StrToInt(rblIsLock.SelectedValue, 0);
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);
            model.target = rblTarget.SelectedValue; 
            if (bll.Update(model))
            {
                AddAdminLog(QJEnums.ActionEnum.Edit.ToString(), "修改关键词：" + model.title); //记录日志
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
                ChkAdminLevel("tools_search_keyword", QJEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改关键词！", "search_keyword_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("tools_search_keyword", QJEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加关键词！", "search_keyword_list.aspx", "Success");
            }
        }
    }
}