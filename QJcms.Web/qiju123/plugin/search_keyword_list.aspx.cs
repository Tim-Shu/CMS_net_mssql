using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QJcms.Common;
using System.Text;

namespace QJcms.Web.admin.plugin
{
    public partial class search_keyword_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = QJRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(10); //每页数量
            BindPower();
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("tools_search_keyword", QJEnums.ActionEnum.View.ToString()); //检查权限
                RptBind("id>0" + CombSqlTxt(this.keywords), "is_lock asc,sort_id asc");
            }
        }

        private void BindPower()
        {
            //添加删除权限
            Model.manager rolemodel = GetAdminInfo();
            BLL.manager_role rolebll = new BLL.manager_role();
            bool result = rolebll.Exists(rolemodel.role_id, "tools_search_keyword", QJEnums.ActionEnum.Add.ToString());
            if (!result)
            {
                tool_add.Visible = false;
            }
            result = rolebll.Exists(rolemodel.role_id, "tools_search_keyword", QJEnums.ActionEnum.Edit.ToString());
            if (!result)
            {
                tool_edit.Visible = false;
            }
            result = rolebll.Exists(rolemodel.role_id, "tools_search_keyword", QJEnums.ActionEnum.Delete.ToString());
            if (!result)
            {
                tool_del.Visible = false;
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = QJRequest.GetQueryInt("page", 1);
            this.txtKeywords.Text = this.keywords;
            BLL.search_keyword bll = new BLL.search_keyword();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();
            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("search_keyword_list.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and title like '%" + _keywords + "%'");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回图文每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("search_keyword_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //设置操作
        protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ChkAdminLevel("tools_search_keyword", QJEnums.ActionEnum.Edit.ToString()); //检查权限
            int id = Convert.ToInt32(((HiddenField)e.Item.FindControl("hidId")).Value);
            BLL.search_keyword bll = new BLL.search_keyword();
            Model.search_keyword model = bll.GetModel(id);
            switch (e.CommandName.ToLower())
            {
                case "lbtnislock":
                    if (model.is_lock == 1)
                        bll.UpdateField(id, "is_lock=0");
                    else
                        bll.UpdateField(id, "is_lock=1");
                    break;
            }
            this.RptBind("id>0" + CombSqlTxt(this.keywords), "is_lock asc,sort_id asc");
        }

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("search_keyword_list.aspx", "keywords={0}", txtKeywords.Text));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("search_keyword_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("search_keyword_list.aspx", "keywords={0}", this.keywords));
        }

        //保存排序
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("tools_search_keyword", QJEnums.ActionEnum.Edit.ToString()); //检查权限
            BLL.search_keyword bll = new BLL.search_keyword();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                int sortId;
                if (!int.TryParse(((TextBox)rptList.Items[i].FindControl("txtSortId")).Text.Trim(), out sortId))
                {
                    sortId = 99;
                }
                bll.UpdateField(id, "sort_id=" + sortId.ToString());
            }
            AddAdminLog(QJEnums.ActionEnum.Edit.ToString(), "修改搜索关键词排序:"); //记录日志
            JscriptMsg("保存排序成功！", Utils.CombUrlTxt("search_keyword_list.aspx", "keywords={0}", this.keywords), "Success");
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("tools_search_keyword", QJEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.search_keyword bll = new BLL.search_keyword();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(QJEnums.ActionEnum.Delete.ToString(), "删除搜索关键词成功" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！", Utils.CombUrlTxt("search_keyword_list.aspx", "keywords={0}", this.keywords), "Success");
        }
    }
}