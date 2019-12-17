using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using QJcms.Common;

namespace QJcms.Web.UI.Page
{
    public partial class userorder_show : Web.UI.UserPage
    {
        protected int id;
        protected Model.orders model;

        /// <summary>
        /// 重写虚方法,此方法在Init事件执行
        /// </summary>
        protected override void InitPage()
        {
            id = QJRequest.GetQueryInt("id");
            BLL.orders bll = new BLL.orders();
            if (!bll.Exists(id))
            {
                HttpContext.Current.Response.Redirect(linkurl("error", "error.aspx?msg=" + Utils.UrlEncode("出错啦，您要浏览的页面不存在或已删除啦！")));
                return;
            }
            model = bll.GetModel(id);
        }

    }
}
