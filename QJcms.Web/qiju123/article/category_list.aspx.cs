using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QJcms.Common;

namespace QJcms.Web.admin.article
{
    public partial class category_list : Web.UI.ManagePage
    {
        protected int channel_id;
        protected string channel_name = string.Empty; //频道名称
        protected Model.channel chanModel = new Model.channel();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.channel_id = QJRequest.GetQueryInt("channel_id");
            this.channel_name = new BLL.channel().GetChannelName(this.channel_id); //取得频道名称
            if (this.channel_id == 0)
            {
                JscriptMsg("频道参数不正确！", "back", "Error");
                return;
            }
            ChannelBind();
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("channel_" + this.channel_name + "_category", QJEnums.ActionEnum.View.ToString()); //检查权限
                RptBind();
            }
        }
        /// <summary>
        /// 配置频道权限
        /// </summary>
        private void ChannelBind()
        {
            chanModel = new BLL.channel().GetModel(channel_id);

            //添加删除权限
            Model.manager rolemodel = GetAdminInfo();
            BLL.manager_role rolebll = new BLL.manager_role();
            bool result = rolebll.Exists(rolemodel.role_id, "channel_" + chanModel.name + "_category", QJEnums.ActionEnum.Add.ToString());
            if (!result)
            {
                tool_add.Visible = false;
            }
            result = rolebll.Exists(rolemodel.role_id, "channel_" + chanModel.name + "_category", QJEnums.ActionEnum.Delete.ToString());
            if (!result)
            {
                tool_del.Visible = false;
            }
            //if (chanModel.is_customer == 0)//客户增删权限
            //{
            //    tool_add.Visible = false;
            //    tool_del.Visible = false;
            //}
        }

        //数据绑定
        private void RptBind()
        {
            BLL.article_category bll = new BLL.article_category();
            DataTable dt = bll.GetList(0, this.channel_id);
            this.rptList.DataSource = dt;
            this.rptList.DataBind();
        }

        //美化列表
        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Literal LitFirst = (Literal)e.Item.FindControl("LitFirst");
                HiddenField hidLayer = (HiddenField)e.Item.FindControl("hidLayer");
                HiddenField hidId = (HiddenField)e.Item.FindControl("hidId");
                HiddenField hidParent = (HiddenField)e.Item.FindControl("hidParent");
                int classLayer = Convert.ToInt32(hidLayer.Value);
                int isParent = Convert.ToInt32(hidParent.Value);

                string LitStyle = "<span style=\"display:inline-block;width:{0}px;\"></span>{1}{2}";
                string LitImg0 = "<span class=\"expandable-close\" data=\"" + hidId.Value + "\"></span>";
                string LitImg0_ = "<span class=\"expandable-open\"></span>";
                string LitImg1 = "<span class=\"folder-close\"></span>";
                string LitImg1_ = "<span class=\"folder-open\"></span>";
                string LitImg2 = "<span class=\"folder-line\"></span>";

                
                if (classLayer == 1)
                {
                    if (isParent == 1)
                    {
                        LitFirst.Text = LitImg0 + LitImg1;
                    }
                    else
                    {
                        LitFirst.Text = LitImg1_;
                    }
                }
                else
                {
                    if (isParent == 1)
                    {
                        LitFirst.Text += string.Format(LitStyle, (classLayer - 2) * 24, LitImg2, LitImg0 + LitImg1);
                    }
                    else
                    {
                        LitFirst.Text += string.Format(LitStyle, (classLayer - 2) * 24, LitImg2, LitImg1_);
                    }
                }
                //控制最大类别层深
                HyperLink hlChild = (HyperLink)e.Item.FindControl("hlChild");
                if (classLayer >= this.chanModel.deep_layer)
                {
                    hlChild.Visible = false;
                }
                else
                {
                    hlChild.NavigateUrl = "category_edit.aspx?action=" + QJEnums.ActionEnum.Add + "&channel_id=" + this.channel_id + "&id=" + hidId.Value;
                }
            }
        }

        //保存排序
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("channel_" + this.channel_name + "_category", QJEnums.ActionEnum.Edit.ToString()); //检查权限
            BLL.article_category bll = new BLL.article_category();
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
            AddAdminLog(QJEnums.ActionEnum.Edit.ToString(), "保存" + this.channel_name + "频道栏目分类排序"); //记录日志
            JscriptMsg("保存排序成功！", Utils.CombUrlTxt("category_list.aspx", "channel_id={0}", this.channel_id.ToString()), "Success");
        }

        //删除类别
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("channel_" + this.channel_name + "_category", QJEnums.ActionEnum.Delete.ToString()); //检查权限
            BLL.article_category bll = new BLL.article_category();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.Delete(id);
                }
            }
            AddAdminLog(QJEnums.ActionEnum.Edit.ToString(), "删除" + this.channel_name + "频道栏目分类数据"); //记录日志
            JscriptMsg("删除数据成功！", Utils.CombUrlTxt("category_list.aspx", "channel_id={0}", this.channel_id.ToString()), "Success");
        }
    }
}