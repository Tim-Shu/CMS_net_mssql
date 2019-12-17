using System;
using System.Collections.Generic;

namespace QJcms.Model
{
    /// <summary>
    /// ϵͳƵ����
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
        private string _content_name = "���ݹ���";
        private string _category_name = "��Ŀ���";
        private string _comment_name = "���۹���";
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
        /// ����ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ����ID
        /// </summary>
        public int category_id
        {
            set { _category_id = value; }
            get { return _category_id; }
        }
        /// <summary>
        /// Ƶ������
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// Ƶ������
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// ���ݹ�����ʾ���� �ӵ����˵���Ч
        /// </summary>
        public string content_name
        {
            set { _content_name = value; }
            get { return _content_name; }
        }
        /// <summary>
        /// ��Ŀ�����ʾ���� �ӵ����˵���Ч
        /// </summary>
        public string category_name
        {
            set { _category_name = value; }
            get { return _category_name; }
        }
        /// <summary>
        /// ���۹�����ʾ���� �ӵ����˵���Ч
        /// </summary>
        public string comment_name
        {
            set { _comment_name = value; }
            get { return _comment_name; }
        }
        /// <summary>
        /// �Ƽ������б� ��,�ֿ�
        /// </summary>
        public string recom_type
        {
            set { _recom_type = value; }
            get { return _recom_type; }
        }
        /// <summary>
        /// �Ƿ�������ͼƬ����ͼ�ϴ���
        /// </summary>
        public int is_cover
        {
            set { _is_cover = value; }
            get { return _is_cover; }
        }
        /// <summary>
        /// �Ƿ�����Ṧ��
        /// </summary>
        public int is_albums
        {
            set { _is_albums = value; }
            get { return _is_albums; }
        }
        /// <summary>
        /// �Ƿ�����������
        /// </summary>
        public int is_attach
        {
            set { _is_attach = value; }
            get { return _is_attach; }
        }
        /// <summary>
        /// �Ƿ������۹���
        /// </summary>
        public int is_comment
        {
            set { _is_comment = value; }
            get { return _is_comment; }
        }
        /// <summary>
        /// �Ƿ������޸�Ȩ��
        /// </summary>
        public int is_customer
        {
            set { _is_customer = value; }
            get { return _is_customer; }
        }
        /// <summary>
        /// �Ƿ�����Ա��۸�
        /// </summary>
        public int is_group_price
        {
            set { _is_group_price = value; }
            get { return _is_group_price; }
        }
        /// <summary>
        /// ÿҳ��ʾ����
        /// </summary>
        public int page_size
        {
            set { _page_size = value; }
            get { return _page_size; }
        }
        /// <summary>
        /// ����������
        /// </summary>
        public int deep_layer
        {
            set { _deep_layer = value; }
            get { return _deep_layer; }
        }
        /// <summary>
        /// ������С ������������Ч Ϊ0ʱ����ȫ������ 1Ϊ������
        /// </summary>
        public int attach_size
        {
            set { _attach_size = value; }
            get { return _attach_size; }
        }
        /// <summary>
        /// ͼƬ��С ����ͼƬ�ϴ�����Ч Ϊ0ʱ����ȫ������ 1Ϊ������
        /// </summary>
        public int img_size
        {
            set { _img_size = value; }
            get { return _img_size; }
        }
        /// <summary>
        /// ͼƬ���߶� ����ͼƬ�ϴ�����Ч Ϊ0ʱ����ȫ������ 1Ϊ������
        /// </summary>
        public int img_maxheight
        {
            set { _img_maxheight = value; }
            get { return _img_maxheight; }
        }
        /// <summary>
        /// ͼƬ����� ����ͼƬ�ϴ�����Ч Ϊ0ʱ����ȫ������ 1Ϊ������
        /// </summary>
        public int img_maxwidth
        {
            set { _img_maxwidth = value; }
            get { return _img_maxwidth; }
        }
        /// <summary>
        /// ����ͼ�߶� Ϊ0ʱ����������ͼ
        /// </summary>
        public int thumbnail_height
        {
            set { _thumbnail_height = value; }
            get { return _thumbnail_height; }
        }
        /// <summary>
        /// ����ͼ��� Ϊ0ʱ����������ͼ
        /// </summary>
        public int thumbnail_width
        {
            set { _thumbnail_width = value; }
            get { return _thumbnail_width; }
        }
        /// <summary>
        /// �������������:1.�ü� 2.ѹ�� 3.�ȱȿ� 4.�ȱȸ�
        /// </summary>
        public int beyond_type
        {
            set { _beyond_type = value; }
            get { return _beyond_type; }
        }
        /// <summary>
        /// ����������
        /// </summary>
        public int is_category_call
        {
            set { _is_category_call = value; }
            get { return _is_category_call; }
        }
        /// <summary>
        /// �����ת����
        /// </summary>
        public int is_category_link
        {
            set { _is_category_link = value; }
            get { return _is_category_link; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public int is_category_into
        {
            set { _is_category_into = value; }
            get { return _is_category_into; }
        }
        /// <summary>
        /// ����Ż�
        /// </summary>
        public int is_category_seo
        {
            set { _is_category_seo = value; }
            get { return _is_category_seo; }
        }
        /// <summary>
        /// ���ͼƬ���� 0:�ر� 1:��ͼ 2:��ͼ
        /// </summary>
        public int is_category_img
        {
            set { _is_category_img = value; }
            get { return _is_category_img; }
        }
        /// <summary>
        /// ���ݱ�������
        /// </summary>
        public int is_content_call
        {
            set { _is_content_call = value; }
            get { return _is_content_call; }
        }
        /// <summary>
        /// ������ת����
        /// </summary>
        public int is_content_link
        {
            set { _is_content_link = value; }
            get { return _is_content_link; }
        }
        /// <summary>
        /// ����ժҪ���
        /// </summary>
        public int is_content_into
        {
            set { _is_content_into = value; }
            get { return _is_content_into; }
        }
        /// <summary>
        /// �����Ż�
        /// </summary>
        public int is_content_seo
        {
            set { _is_content_seo = value; }
            get { return _is_content_seo; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public int sort_id
        {
            set { _sort_id = value; }
            get { return _sort_id; }
        }
        /// <summary>
        /// �Ƿ���Ƶ������
        /// </summary>
        public int is_channel_img
        {
            get { return _is_channel_img; }
            set { _is_channel_img = value; }
        }
        /// <summary>
        /// Ƶ������ͼƬ
        /// </summary>
        public string channel_img
        {
            get { return _channel_img; }
            set { _channel_img = value; }
        }
        /// <summary>
        /// �Ƿ���Ƶ������
        /// </summary>
        public int is_channel_descript
        {
            get { return _is_channel_descript; }
            set { _is_channel_descript = value; }
        }
        /// <summary>
        /// Ƶ��������Ϣ
        /// </summary>
        public string channel_descript
        {
            get { return _channel_descript; }
            set { _channel_descript = value; }
        }
        #endregion Model

        private List<channel_field> _channel_fields;
        /// <summary>
        /// ��չ�ֶ� 
        /// </summary>
        public List<channel_field> channel_fields
        {
            set { _channel_fields = value; }
            get { return _channel_fields; }
        }
    }
}