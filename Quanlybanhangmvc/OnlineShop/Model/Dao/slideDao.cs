using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class slideDao
    {

        onlineShop db = null;
        public slideDao()
        {
            db = new onlineShop();
        }

        public List<m_slide> listAll()
        {
            return db.m_slide.Where(x => x.Status_p == true).OrderBy(y => y.DisplayOrder).ToList();
        }

        public int Insert(m_chat content)
        {
            db.m_chat.Add(content);
            db.SaveChanges();
            return content.Id;
        }
    }
}
