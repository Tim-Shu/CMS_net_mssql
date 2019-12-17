using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QJcms.Common;

namespace QJcms.Web.admin
{
    public partial class index : Web.UI.ManagePage
    {
        protected Model.manager admin_info;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                admin_info = GetAdminInfo();
            }
        }

        //安全退出
        protected void lbtnExit_Click(object sender, EventArgs e)
        {
            Session[QJConst.SESSION_ADMIN_INFO] = null;
            Utils.WriteCookie("AdminName", "QJcms", -14400);
            Utils.WriteCookie("AdminPwd", "QJcms", -14400);
            Response.Redirect("qijudl.aspx");
        }

    }
}
              