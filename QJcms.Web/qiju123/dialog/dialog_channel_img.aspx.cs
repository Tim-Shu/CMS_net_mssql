using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QJcms.Common;

namespace QJcms.Web.admin.dialog
{
    public partial class dialog_channel_img : Web.UI.ManagePage
    {
        protected int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = QJRequest.GetQueryInt("id");
            if (this.id == 0)
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }
            if (!new BLL.channel().Exists(this.id))
            {
                JscriptMsg("记录不存在或已删除！", "back", "Error");
                return;
            }
            if (!Page.IsPostBack)
            {
                ShowInfo(id);
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.channel bll = new BLL.channel();
            Model.channel model = bll.GetModel(_id);
            if (model.channel_img.Length > 0)
            {
                txtImgUrl.Text = imgChannel.Src = model.channel_img;
            }
        }
        #endregion
    }
}