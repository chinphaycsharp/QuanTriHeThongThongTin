using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class MenuDao
    {
        onlineShop db = new onlineShop();
        public MenuDao()
        {
            db = new onlineShop();
        }

        public List<m_menu> ListByGroupID(int groupID)
        {
            return db.m_menu.Where(x => x.TypeID == groupID).ToList();
        }
    }
}
