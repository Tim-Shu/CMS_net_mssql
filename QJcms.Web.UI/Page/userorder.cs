﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using QJcms.Common;

namespace QJcms.Web.UI.Page
{
    public partial class userorder : Web.UI.UserPage
    {
        protected string action = string.Empty;
        protected int page;         //当前页码
        protected int totalcount;   //OUT数据总数

        /// <summary>
        /// 重写虚方法,此方法在Init事件执行
        /// </summary>
        protected override void InitPage()
        {
            action = QJRequest.GetQueryString("action");
            page = QJRequest.GetQueryInt("page", 1);
        }

    }
}
