using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class OrderDao
    {
        onlineShop db = null;

        public OrderDao()
        {
            db = new onlineShop();
        }

        public long Insert(m_product_bill order)
        {
            db.m_product_bill.Add(order);
            db.SaveChanges();
            return order.Id;
        }
    }
}
