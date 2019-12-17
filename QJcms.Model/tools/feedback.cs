using System;

namespace QJcms.Model
{
    /// <summary>
    /// 在线留言:实体类
    /// </summary>
    [Serializable]
    public partial class feedback
    {
        public feedback()
        { }
        #region Model
        private int _id;
        private int _type_id = 0;
        private int _user_id = 0;
        private int _obj_id = 0;
        private string _order_no = "";
        private string _title = "";
        private string _content = "";
        private string _user_name = "";
        private string _user_tel = "";
        private string _user_mobile = "";
        private string _user_qq = "";
        private string _user_weix = "";
        private string _user_email = "";
        private string _address = "";
        private DateTime _add_time = DateTime.Now;
        private int _is_view = 0;
        private DateTime? _view_time;
        private string _reply_content = "";
        private DateTime? _reply_time;
        private int _is_lock = 0;
        private decimal _payment_amount = 0M;
        private int _order_status = 0;
        private int _payment_status = 0;
                
        
        /// <summary>
        /// 自增D
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 留言标题
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 留言内容
        /// </summary>
        public string content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string user_name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string user_tel
        {
            set { _user_tel = value; }
            get { return _user_tel; }
        }
        /// <summary>
        /// 联系QQ
        /// </summary>
        public string user_qq
        {
            set { _user_qq = value; }
            get { return _user_qq; }
        }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string user_email
        {
            set { _user_email = value; }
            get { return _user_email; }
        }
        /// <summary>
        /// 留言时间
        /// </summary>
        public DateTime add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        /// <summary>
        /// 回复内容
        /// </summary>
        public string reply_content
        {
            set { _reply_content = value; }
            get { return _reply_content; }
        }
        /// <summary>
        /// 回复时间
        /// </summary>
        public DateTime? reply_time
        {
            set { _reply_time = value; }
            get { return _reply_time; }
        }
        /// <summary>
        /// 是否锁定1是0否
        /// </summary>
        public int is_lock
        {
            set { _is_lock = value; }
            get { return _is_lock; }
        }

        /// <summary>
        /// 类别 0留言 1预约 2预定
        /// </summary>
        public int type_id
        {
            get { return _type_id; }
            set { _type_id = value; }
        }
        /// <summary>
        /// 会员ID（会员登录后有效）
        /// </summary>
        public int user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }
        /// <summary>
        /// 相关项目ID
        /// </summary>
        public int obj_id
        {
            get { return _obj_id; }
            set { _obj_id = value; }
        }
        /// <summary>
        /// 订单、预约号
        /// </summary>
        public string order_no
        {
            get { return _order_no; }
            set { _order_no = value; }
        }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string user_mobile
        {
            get { return _user_mobile; }
            set { _user_mobile = value; }
        }
        /// <summary>
        /// 微信号
        /// </summary>
        public string user_weix
        {
            get { return _user_weix; }
            set { _user_weix = value; }
        }
        /// <summary>
        /// 联系地址
        /// </summary>
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }
        /// <summary>
        /// 是否已阅读 0未读 1已读
        /// </summary>
        public int is_view
        {
            get { return _is_view; }
            set { _is_view = value; }
        }
        /// <summary>
        /// 阅读时期
        /// </summary>
        public DateTime? view_time
        {
            get { return _view_time; }
            set { _view_time = value; }
        }
        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal payment_amount
        {
            get { return _payment_amount; }
            set { _payment_amount = value; }
        }
        /// <summary>
        /// 预约状态 0未受理 1已受理
        /// </summary>
        public int order_status
        {
            get { return _order_status; }
            set { _order_status = value; }
        }
        /// <summary>
        /// 支付状态 0未支付 1已支付
        /// </summary>
        public int payment_status
        {
            get { return _payment_status; }
            set { _payment_status = value; }
        }
        #endregion Model

    }
}
