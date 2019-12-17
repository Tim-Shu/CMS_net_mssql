using QJcms.Common;
using System.Collections.Generic;

namespace QJcms.BLL
{
    public class article_images_size
    {
        private readonly DAL.article_images_size dal;

        public article_images_size()
		{
            dal = new DAL.article_images_size(QJKey.DatabasePrefix);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.article_images_size> GetCategoryImageSizeById(int category_id)
        {
            return dal.GetCategoryImageSizeById(category_id);
        }
    }
}
