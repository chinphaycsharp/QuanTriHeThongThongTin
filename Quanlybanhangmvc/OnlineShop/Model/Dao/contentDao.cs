using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class contentDao
    {
        onlineShop db = null;

        public contentDao()
        {
            db = new onlineShop();
        }

        public m_information getById(long id)
        {
            return db.m_information.Find(id);
        }

        public IEnumerable<m_information> listAllPaging(string Search, int page, int pageSize)
        {
            IQueryable<m_information> model = db.m_information;
            if (!string.IsNullOrEmpty(Search))
            {
                model = model.Where(x => x.Name.Contains(Search) || x.CreateDate.ToString().Contains(Search));
            }

            return model.OrderByDescending(x => x.Id).ToPagedList(page, pageSize);
        }

        public m_information viewDetail(long id)
        {
            return db.m_information.Find(id);
        }

        public long Insert(m_information content)
        {
            db.m_information.Add(content);
            db.SaveChanges();
            return content.Id;
        }

        public bool update(m_information ennity)
        {
            try
            {
                var c = db.m_information.Find(ennity.Id);
                c.Name = ennity.Name;
                c.Metatile = ennity.Metatile;
                c.content = ennity.content;
                c.Status_I = ennity.Status_I;
                c.IdCategory = ennity.IdCategory;
                c.CreateBy = ennity.CreateBy;
                c.CreateDate = ennity.CreateDate;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var user = db.m_information.Find(id);
                db.m_information.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
