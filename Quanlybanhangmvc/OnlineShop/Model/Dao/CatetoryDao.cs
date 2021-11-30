using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CatetoryDao
    {
        private onlineShop db = null;

        public CatetoryDao()
        {
            db = new onlineShop();
        }

        public List<m_catetory> ListAll()
        {
            return db.m_catetory.Where(x => x.Status_P == true).ToList();
        }

        public m_productCatetory viewDetail(long id)
        {
            return db.m_productCatetory.Find(id);
        }
    }
}
