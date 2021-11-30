using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class FooterDao
    {
        onlineShop db = null;
        public FooterDao()
        {
            db = new onlineShop();
        }

        public m_last_footer GetFooter()
        {
            return db.m_last_footer.SingleOrDefault(x => x.Status_f == true);
        }
    }
}
