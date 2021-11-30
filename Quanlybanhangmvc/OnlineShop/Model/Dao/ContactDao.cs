using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ContactDao
    {
        private onlineShop db = null;

        public ContactDao()
        {
            db = new onlineShop();
        }

        public m_contact getActiveContact()
        {
            return db.m_contact.Single(x => x.Status_C == true);
        }

        public long insert(m_feedback fb)
        {
            db.m_feedback.Add(fb);
            db.SaveChanges();
            return fb.ID;
        }
    }
}
