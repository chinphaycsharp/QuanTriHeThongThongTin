using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ChatDao
    {
        private onlineShop db = null;

        public ChatDao()
        {
            db = new onlineShop();
        }

        public int Insert(m_chat content)
        {
            db.m_chat.Add(content);
            db.SaveChanges();
            return content.Id;
        }

        public List<m_chat> getAllMessUser(string username)
        {
            var result = db.m_chat.Where(x => x.Name_send == username).OrderBy(x=>x.SendDate).ToList();
            return result;
        }

        public List<m_chat> getAllMessAdmin(string admin)
        {
            var result = db.m_chat.Where(x => x.Name_receive == admin).OrderBy(x => x.SendDate).ToList(); ;
            return result;
        }
    }
}
