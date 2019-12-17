using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using QJcms.Common;

namespace QJcms.Web.UI.Page
{
    public partial class order : Web.UI.BasePage
    {
        protected int id;         //当前ID
        protected Model.article model = new Model.article();

        /// <summary>
        /// 重写虚方法,此方法在Init事件执行
        /// </summary>
        protected override void ShowPage()
        {
            id = QJRequest.GetQueryInt("id",0);
            BLL.article bll = new BLL.article();
            if (id > 0) //如果ID获取到，将使用ID
            {
                if (!bll.Exists(id))
                {
                    HttpContext.Current.Response.Redirect(linkurl("error", "?msg=" + Utils.UrlEncode("出错啦，您要浏览的页面不存在或已删除啦！")));
                    return;
                }
                model = bll.GetModel(id);
            }
        }

    }
}
