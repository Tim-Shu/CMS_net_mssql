using QJcms.Common;

namespace QJcms.BLL
{
    /// <summary>
    /// 下载附件
    /// </summary>
    public partial class article_attach
    {
        private readonly DAL.article_attach dal;
        public article_attach()
        {
            dal = new DAL.article_attach(QJKey.DatabasePrefix);
        }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 获取下载次数
        /// </summary>
        public int GetDownNum(int id)
        {
            return dal.GetDownNum(id);
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.article_attach GetModel(int id)
        {
            return dal.GetModel(id);
        }

        //删除更新的旧文件
        public void DeleteFile(int id, string filePath)
        {
            Model.article_attach model = GetModel(id);
            if (model != null && model.file_path != filePath)
            {
                Utils.DeleteFile(model.file_path);
            }
        }

        #endregion  Method

        /// <summary>
        /// 获取第一条附件路径
        /// </summary>
        public string GetFirstPath(int article_id)
        {
            return dal.GetFirstPath(article_id);
        }

    }
}