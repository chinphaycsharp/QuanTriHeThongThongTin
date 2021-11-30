using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class NewsDao
    {
        private onlineShop db = null;

        public NewsDao()
        {
            db = new onlineShop();
        }

        public List<m_information> ListNew(int top)
        {
            return db.m_information.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }

        public m_information viewDetail(long id)
        {
            return db.m_information.Find(id);
        }
    }
}
