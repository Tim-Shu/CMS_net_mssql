using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Text;
using QJcms.Common;

namespace QJcms.Web.UI.Page
{
    public partial class feedback : Web.UI.BasePage
    {
        protected string page = string.Empty;

        /// <summary>
        /// 重写虚方法,此方法将在Init事件前执行
        /// </summary>
        public feedback()
        {
            page = QJRequest.GetQueryString("page");
        }

    }
}
