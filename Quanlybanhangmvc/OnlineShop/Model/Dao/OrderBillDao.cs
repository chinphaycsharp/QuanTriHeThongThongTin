using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class OrderBillDao
    {
        onlineShop db = null;

        public OrderBillDao()
        {
            db = new onlineShop();
        }

        public bool Insert(m_order_bill order)
        {
            try
            {
                db.m_order_bill.Add(order);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int countID()
        {
            return db.m_order_bill.Count();
        }
    }
}
