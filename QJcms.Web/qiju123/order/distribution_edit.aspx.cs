using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QJcms.Common;
using System.Text;
using System.Data;

namespace QJcms.Web.admin.order
{
    public partial class distribution_edit : Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("order_distribution", QJEnums.ActionEnum.View.ToString()); //检查权限     
                BindProvince();
            }
        }

        private void BindProvince()
        {
            StringBuilder strLI = new StringBuilder();
            DataTable dt = new BLL.province().GetList(0, "", "").Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    strLI.Append("<li class=\"provinceLI-").Append(dr["id"].ToString()).Append("\"><span><a href=\"javascript:loadCity(").Append(dr["id"].ToString()).Append(")\">").Append(dr["province_name"].ToString()).Append("</a></span>");
                    strLI.Append("<div class=\"rule-single-checkbox option-lock\">"); 
                    strLI.Append("<input type=\"checkbox\" name=\"cbIsLockP-").Append(dr["id"].ToString()).Append("\" id=\"cbIsLockP-").Append(dr["id"].ToString()).Append("\" ");
                    if (dr["is_lock"].ToString() == "0")
                        strLI.Append("checked=\"checked\"");
                    strLI.Append("/></div>").Append("</li>");
                }
                provinceList.InnerHtml += strLI.ToString();
            }
        }
    }
}