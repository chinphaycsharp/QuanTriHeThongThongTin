using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class productCatetoryDao
    {
        onlineShop db = null;
        public productCatetoryDao()
        {
            db = new onlineShop();
        }

        public List<m_productCatetory> ListAll()
        {
            return db.m_productCatetory.Where(x => x.Status_P == true).OrderBy(x => x.DisplayOrder).ToList();
        }

        public m_productCatetory Detail(long id)
        {
            return db.m_productCatetory.Find(id);
        }
    }
}
