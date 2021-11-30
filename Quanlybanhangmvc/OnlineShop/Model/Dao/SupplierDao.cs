using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class SupplierDao
    {
        private onlineShop db = null;

        public SupplierDao()
        {
            db = new onlineShop();
        }

        public List<m_supplier> ListAll()
        {
            return db.m_supplier.Where(x => x.Status_S == true).ToList();
        }
    }
}
