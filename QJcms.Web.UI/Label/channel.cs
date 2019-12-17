using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QJcms.Web.UI
{
    public partial class BasePage : System.Web.UI.Page
    {
        /// <summary>
        /// 返回频道列表
        /// </summary>
        /// <param name="category_id">频道类别ID</param>
        /// <returns>DataTable</returns>
        protected DataTable get_channel_list(int categoryid)
        {
            DataTable dt = new DataTable();
            BLL.channel bll = new BLL.channel();
            dt = bll.GetList(0, "category_id=" + categoryid, "sort_id asc,id desc").Tables[0];
            return dt;
        }

        /// <summary>
        /// 根据ID返回频道实体类
        /// </summary>
        /// <param name="channel_id">频道ID</param>
        /// <returns></returns>
        protected Model.channel get_channel_model(int channel_id)
        {
            Model.channel model = new BLL.channel().GetModel(channel_id);
            return model;
        }

        /// <summary>
        /// 根据ID返回频道名称
        /// </summary>
        /// <param name="channel_id">频道ID</param>
        /// <returns></returns>
        protected string get_channel_name(int channel_id)
        {
            Model.channel model = new BLL.channel().GetModel(channel_id);
            return model.name;
        }
        /// <summary>
        /// 根据名称返回频道标题
        /// </summary>
        /// <param name="channel_id">频道名称</param>
        /// <returns></returns>
        protected string get_channel_title(string channel_name)
        {
            Model.channel model = new BLL.channel().GetModel(channel_name);
            return model.title;
        }

        /// <summary>
        /// 根据频道名称返回频道实体类
        /// </summary>
        /// <param name="channel_id">频道名称</param>
        /// <returns></returns>
        protected Model.channel get_channel_model(string channel_name)
        {
            Model.channel model = new BLL.channel().GetModel(channel_name);
            return model;
        }
    }
}
