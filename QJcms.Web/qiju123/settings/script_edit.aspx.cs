using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QJcms.Common;

namespace QJcms.Web.admin.settings
{
    public partial class script_edit : Web.UI.ManagePage
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
                if (!new BLL.script_list().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("sys_script", QJEnums.ActionEnum.View.ToString()); //检查权限
                if (action == QJEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.script_list bll = new BLL.script_list();
            Model.script_list model = bll.GetModel(_id);

            txtTitle.Text = model.title;
            rblIsLock.SelectedValue = model.is_lock.ToString();
            txtSortId.Text = model.sort_id.ToString();
            txtContent.Text = model.content;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.script_list model = new Model.script_list();
            BLL.script_list bll = new BLL.script_list();
            Model.manager managerModel = GetAdminInfo();
            model.title = txtTitle.Text.Trim();
            model.is_lock = Utils.StrToInt(rblIsLock.SelectedValue, 0);
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);
            model.content = txtContent.Text;
            model.user_name = managerModel.user_name;
            model.login_ip = QJRequest.GetIP();
            model.login_time = DateTime.Now;
            model.login_history = "<p>时间：" + model.login_time + " 操作IP：" + model.login_ip + " 操作人员：" + model.user_name + "</p><p>代码内容：" + model.content + "</p>";
            if (bll.Add(model) > 0)
            {
                AddAdminLog(QJEnums.ActionEnum.Add.ToString(), "添加统计代码：" + model.title); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.script_list bll = new BLL.script_list();
            Model.script_list model = bll.GetModel(_id);
            Model.manager managerModel = GetAdminInfo();
            model.title = txtTitle.Text.Trim();
            model.is_lock = Utils.StrToInt(rblIsLock.SelectedValue, 0);
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);
            model.content = txtContent.Text;
            model.user_name = managerModel.user_name;
            model.login_ip = QJRequest.GetIP();
            model.login_time = DateTime.Now;
            model.login_history += "<p>时间：" + model.login_time + " 操作IP：" + model.login_ip + " 操作人员：" + model.user_name + "</p><p>代码内容：" + model.content + "</p>";
            if (bll.Update(model))
            {
                AddAdminLog(QJEnums.ActionEnum.Edit.ToString(), "修改统计代码：" + model.title); //记录日志
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
                ChkAdminLevel("sys_script", QJEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改统计代码！", "script_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("sys_script", QJEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加统计代码！", "script_list.aspx", "Success");
            }
        }
    }
}