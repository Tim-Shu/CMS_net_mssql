using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using QJcms.Common;
using LitJson;

namespace QJcms.Web.UI
{
    /// <summary>
    /// 购物车帮助类
    /// </summary>
    public partial class ShopCart
    {
        #region 基本增删改方法====================================
        /// <summary>
        /// 获得购物车列表
        /// </summary>
        public static IList<Model.cart_items> GetList(int group_id)
        {
            IDictionary<string, int> dic = GetCart();
            if (dic != null)
            {
                IList<Model.cart_items> iList = new List<Model.cart_items>();

                foreach (var item in dic)
                {
                    BLL.article bll = new BLL.article();
                    if (item.Key.IndexOf('|') < 0)
                    {
                        continue;
                    }
                    int id = Convert.ToInt32(item.Key.Split('|')[0]);
                    decimal price = Convert.ToDecimal(item.Key.Split('|')[1]);
                    Model.article model = bll.GetModel(id);
                    if (model == null || price <= 0)
                    {
                        continue;
                    }
                    Model.cart_items modelt = new Model.cart_items();
                    modelt.id = model.id;
                    modelt.title = model.title;
                    modelt.img_url = model.img_url;
                    modelt.point = int.Parse(price.ToString("0"));
                    if (model.fields.ContainsKey("point"))
                    {
                        modelt.point = Utils.StrToInt(model.fields["point"], 0);
                    }
                    modelt.price = price;
                    modelt.user_price = price;
                    if (model.fields.ContainsKey("stock_quantity"))
                    {
                        modelt.stock_quantity = Utils.StrToInt(model.fields["stock_quantity"], 0);
                    }
                    //会员价格
                    if (model.group_price != null)
                    {
                        Model.user_group_price gmodel = model.group_price.Find(p => p.group_id == group_id);
                        if (gmodel != null)
                        {
                            modelt.user_price = gmodel.price;
                        }
                    }
                    modelt.quantity = item.Value;

                    DataTable dt = new DataTable();
                    dt.Columns.Add("name", Type.GetType("System.String"));
                    dt.Columns.Add("value", Type.GetType("System.String"));

                    if (!string.IsNullOrEmpty(model.fields["property"]))
                    {
                        string[] proplist = model.fields["property"].Split(',');
                        foreach (string prop in proplist)
                        {
                            if (prop.IndexOf('|') > 0)
                            {
                                DataRow dr = dt.NewRow();
                                dr["name"] = prop.Split('|')[0]; //名称
                                dr["value"] = prop.Split('|')[1]; //参数
                                dt.Rows.Add(dr);
                            }
                        }
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (price == Utils.StrToDecimal(dt.Rows[i]["value"].ToString(), 0))
                        {
                            modelt.property_index = i; break;
                        }
                    }
                    iList.Add(modelt);
                }
                return iList;
            }
            return null;
        }

        /// <summary>
        /// 添加到购物车
        /// </summary>
        public static bool Add(string Key, int Quantity)
        {
            IDictionary<string, int> dic = GetCart();
            if (dic != null)
            {
                if (dic.ContainsKey(Key))
                {
                    dic[Key] += Quantity;
                    AddCookies(JsonMapper.ToJson(dic));
                    return true;
                }
            }
            else
            {
                dic = new Dictionary<string, int>();
            }
            //不存在的则新增
            dic.Add(Key, Quantity);
            AddCookies(JsonMapper.ToJson(dic));
            return true;
        }

        /// <summary>
        /// 更新购物车数量
        /// </summary>
        public static bool Update(string Key, int Quantity)
        {
            if (Quantity == 0)
            {
                Clear(Key);
                return true;
            }
            IDictionary<string, int> dic = GetCart();
            if (dic != null && dic.ContainsKey(Key))
            {
                dic[Key] = Quantity;
                AddCookies(JsonMapper.ToJson(dic));
                return true;
            }
            return false;
        }

        /// <summary>
        /// 移除购物车
        /// </summary>
        /// <param name="Key">主键 0为清理所有的购物车信息</param>
        public static void Clear(string Key)
        {
            if (Key == "0")//为0的时候清理全部购物车cookies
            {
                Utils.WriteCookie(QJConst.COOKIE_SHOPPING_CART, "", -43200);
            }
            else
            {
                IDictionary<string, int> dic = GetCart();
                if (dic != null)
                {
                    dic.Remove(Key);
                    AddCookies(JsonMapper.ToJson(dic));
                }
            }
        }
        #endregion

        #region 扩展方法==========================================
        public static Model.cart_total GetTotal(int group_id)
        {
            Model.cart_total model = new Model.cart_total();
            IList<Model.cart_items> iList = GetList(group_id);
            if (iList != null)
            {
                foreach (Model.cart_items modelt in iList)
                {
                    model.total_num++;
                    model.total_quantity += modelt.quantity;
                    model.payable_amount += modelt.price * modelt.quantity;
                    model.real_amount += modelt.user_price * modelt.quantity;
                    model.total_point += modelt.point * modelt.quantity;
                }
            }
            return model;
        }
        #endregion

        #region 私有方法==========================================
        /// <summary>
        /// 获取cookies值
        /// </summary>
        private static IDictionary<string, int> GetCart()
        {
            IDictionary<string, int> dic = new Dictionary<string, int>();
            if (!string.IsNullOrEmpty(GetCookies()))
            {
                return JsonMapper.ToObject<Dictionary<string, int>>(GetCookies());
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 添加对象到cookies
        /// </summary>
        /// <param name="strValue"></param>
        private static void AddCookies(string strValue)
        {
            Utils.WriteCookie(QJConst.COOKIE_SHOPPING_CART, strValue, 43200); //存储一个月
        }

        /// <summary>
        /// 获取cookies
        /// </summary>
        /// <returns></returns>
        private static string GetCookies()
        {
            return Utils.GetCookie(QJConst.COOKIE_SHOPPING_CART);
        }

        #endregion
    }

}
