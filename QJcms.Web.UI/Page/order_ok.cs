using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using QJcms.Common;

namespace QJcms.Web.UI.Page
{
    public partial class order_ok : Web.UI.BasePage
    {
        protected string order_no = string.Empty;

        /// <summary>
        /// 重写虚方法,此方法在Init事件执行
        /// </summary>
        protected override void ShowPage()
        {
            order_no = QJRequest.GetQueryString("order_no");
            //if (!string.IsNullOrEmpty(order_no)) //如果ID获取到，将使用ID
            //{
            //    if (!bll.Exists(order_no))
            //    {
            //        HttpContext.Current.Response.Redirect(linkurl("error", "?msg=" + Utils.UrlEncode("出错啦，您要浏览的页面不存在或已删除啦！")));
            //        return;
            //    }
            //    model = bll.GetModel(order_no);
            //}
        }

    }
}
