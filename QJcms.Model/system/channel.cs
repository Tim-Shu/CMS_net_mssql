using System;
using System.Collections.Generic;

namespace QJcms.Model
{
    /// <summary>
    /// 系统频道表
    /// </summary>
    [Serializable]
    public partial class channel
    {
        public channel()
        { }
        #region Model
        private int _id;
        private int _category_id = 0;
        private string _name;
        private string _title = "";
        private string _content_name = "内容管理";
        private string _category_name = "栏目类别";
        private string _comment_name = "评论管理";
        private string _recom_type = "";
        private int _is_cover = 0;
        private int _is_albums = 0;
        private int _is_attach = 0;
        private int _is_comment = 0;
        private int _is_customer = 0;
        private int _is_group_price = 0;
        private int _page_size = 0;
        private int _deep_layer = 0;
        private int _attach_size = 0;
        private int _img_size = 0;
        private int _img_maxheight = 0;
        private int _img_maxwidth = 0;
        private int _thumbnail_height = 0;
        private int _thumbnail_width = 0;
        private int _beyond_type = 1;
        private int _is_category_call = 0;
        private int _is_category_link = 0;
        private int _is_category_into = 0;
        private int _is_category_seo = 0;
        private int _is_category_img = 0;
        private int _is_content_call = 0;
        private int _is_content_link = 0;
        private int _is_content_into = 0;
        private int _is_content_seo = 0;
        private int _sort_id = 99;
        private int _is_channel_img = 0;
        private string _channel_img = "";
        private int _is_channel_descript = 0;
        private string _channel_descript = "";
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 分类ID
        /// </summary>
        public int category_id
        {
            set { _category_id = value; }
            get { return _category_id; }
        }
        /// <summary>
        /// 频道名称
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 频道标题
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 内容管理显示名称 子导航菜单有效
        /// </summary>
        public string content_name
        {
            set { _content_name = value; }
            get { return _content_name; }
        }
        /// <summary>
        /// 栏目类别显示名称 子导航菜单有效
        /// </summary>
        public string category_name
        {
            set { _category_name = value; }
            get { return _category_name; }
        }
        /// <summary>
        /// 评论管理显示名称 子导航菜单有效
        /// </summary>
        public string comment_name
        {
            set { _comment_name = value; }
            get { return _comment_name; }
        }
        /// <summary>
        /// 推荐类型列表 以,分开
        /// </summary>
        public string recom_type
        {
            set { _recom_type = value; }
            get { return _recom_type; }
        }
        /// <summary>
        /// 是否开启封面图片（单图上传）
        /// </summary>
        public int is_cover
        {
            set { _is_cover = value; }
            get { return _is_cover; }
        }
        /// <summary>
        /// 是否开启相册功能
        /// </summary>
        public int is_albums
        {
            set { _is_albums = value; }
            get { return _is_albums; }
        }
        /// <summary>
        /// 是否开启附件功能
        /// </summary>
        public int is_attach
        {
            set { _is_attach = value; }
            get { return _is_attach; }
        }
        /// <summary>
        /// 是否开启评论功能
        /// </summary>
        public int is_comment
        {
            set { _is_comment = value; }
            get { return _is_comment; }
        }
        /// <summary>
        /// 是否开启客修改权限
        /// </summary>
        public int is_customer
        {
            set { _is_customer = value; }
            get { return _is_customer; }
        }
        /// <summary>
        /// 是否开启会员组价格
        /// </summary>
        public int is_group_price
        {
            set { _is_group_price = value; }
            get { return _is_group_price; }
        }
        /// <summary>
        /// 每页显示数量
        /// </summary>
        public int page_size
        {
            set { _page_size = value; }
            get { return _page_size; }
        }
        /// <summary>
        /// 分类最大深度
        /// </summary>
        public int deep_layer
        {
            set { _deep_layer = value; }
            get { return _deep_layer; }
        }
        /// <summary>
        /// 附件大小 开启附件后生效 为0时调用全局配置 1为不限制
        /// </summary>
        public int attach_size
        {
            set { _attach_size = value; }
            get { return _attach_size; }
        }
        /// <summary>
        /// 图片大小 开启图片上传后生效 为0时调用全局配置 1为不限制
        /// </summary>
        public int img_size
        {
            set { _img_size = value; }
            get { return _img_size; }
        }
        /// <summary>
        /// 图片最大高度 开启图片上传后生效 为0时调用全局配置 1为不限制
        /// </summary>
        public int img_maxheight
        {
            set { _img_maxheight = value; }
            get { return _img_maxheight; }
        }
        /// <summary>
        /// 图片最大宽度 开启图片上传后生效 为0时调用全局配置 1为不限制
        /// </summary>
        public int img_maxwidth
        {
            set { _img_maxwidth = value; }
            get { return _img_maxwidth; }
        }
        /// <summary>
        /// 缩略图高度 为0时不生成缩略图
        /// </summary>
        public int thumbnail_height
        {
            set { _thumbnail_height = value; }
            get { return _thumbnail_height; }
        }
        /// <summary>
        /// 缩略图宽度 为0时不生成缩略图
        /// </summary>
        public int thumbnail_width
        {
            set { _thumbnail_width = value; }
            get { return _thumbnail_width; }
        }
        /// <summary>
        /// 超出后操作类型:1.裁剪 2.压缩 3.等比宽 4.等比高
        /// </summary>
        public int beyond_type
        {
            set { _beyond_type = value; }
            get { return _beyond_type; }
        }
        /// <summary>
        /// 类别别名访问
        /// </summary>
        public int is_category_call
        {
            set { _is_category_call = value; }
            get { return _is_category_call; }
        }
        /// <summary>
        /// 类别跳转链接
        /// </summary>
        public int is_category_link
        {
            set { _is_category_link = value; }
            get { return _is_category_link; }
        }
        /// <summary>
        /// 类别介绍
        /// </summary>
        public int is_category_into
        {
            set { _is_category_into = value; }
            get { return _is_category_into; }
        }
        /// <summary>
        /// 类别优化
        /// </summary>
        public int is_category_seo
        {
            set { _is_category_seo = value; }
            get { return _is_category_seo; }
        }
        /// <summary>
        /// 类别图片类型 0:关闭 1:单图 2:多图
        /// </summary>
        public int is_category_img
        {
            set { _is_category_img = value; }
            get { return _is_category_img; }
        }
        /// <summary>
        /// 内容别名访问
        /// </summary>
        public int is_content_call
        {
            set { _is_content_call = value; }
            get { return _is_content_call; }
        }
        /// <summary>
        /// 内容跳转链接
        /// </summary>
        public int is_content_link
        {
            set { _is_content_link = value; }
            get { return _is_content_link; }
        }
        /// <summary>
        /// 内容摘要简介
        /// </summary>
        public int is_content_into
        {
            set { _is_content_into = value; }
            get { return _is_content_into; }
        }
        /// <summary>
        /// 内容优化
        /// </summary>
        public int is_content_seo
        {
            set { _is_content_seo = value; }
            get { return _is_content_seo; }
        }
        /// <summary>
        /// 排序数字
        /// </summary>
        public int sort_id
        {
            set { _sort_id = value; }
            get { return _sort_id; }
        }
        /// <summary>
        /// 是否开启频道封面
        /// </summary>
        public int is_channel_img
        {
            get { return _is_channel_img; }
            set { _is_channel_img = value; }
        }
        /// <summary>
        /// 频道封面图片
        /// </summary>
        public string channel_img
        {
            get { return _channel_img; }
            set { _channel_img = value; }
        }
        /// <summary>
        /// 是否开启频道描述
        /// </summary>
        public int is_channel_descript
        {
            get { return _is_channel_descript; }
            set { _is_channel_descript = value; }
        }
        /// <summary>
        /// 频道描述信息
        /// </summary>
        public string channel_descript
        {
            get { return _channel_descript; }
            set { _channel_descript = value; }
        }
        #endregion Model

        private List<channel_field> _channel_fields;
        /// <summary>
        /// 扩展字段 
        /// </summary>
        public List<channel_field> channel_fields
        {
            set { _channel_fields = value; }
            get { return _channel_fields; }
        }
    }
}