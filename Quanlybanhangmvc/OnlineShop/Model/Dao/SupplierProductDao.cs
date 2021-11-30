using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class SupplierProductDao
    {
        onlineShop db = null;

        public SupplierProductDao()
        {
            db = new onlineShop();
        }

        public m_supplier_product getById(long id)
        {
            return db.m_supplier_product.Find(id);
        }

        public IEnumerable<m_supplier_product> listAllPaging(string Search, int page, int pageSize)
        {
            IQueryable<m_supplier_product> model = db.m_supplier_product;
            if (!string.IsNullOrEmpty(Search))
            {
                model = model.Where(x => x.Name_Product.Contains(Search) || x.Name_supplier.ToString().Contains(Search));
            }

            return model.OrderByDescending(x => x.Id).ToPagedList(page, pageSize);
        }

        public m_supplier_product viewDetail(long id)
        {
            return db.m_supplier_product.Find(id);
        }

        public long Insert(m_supplier_product content)
        {
            db.m_supplier_product.Add(content);
            db.SaveChanges();
            return content.Id;
        }

        public bool update(m_supplier_product ennity)
        {
            try
            {
                var content = db.m_supplier_product.Find(ennity.Id);
                content.Id_Product = ennity.Id_Product;
                content.Id_supplier = ennity.Id_supplier;
                content.Name_Product = ennity.Name_Product;
                content.Name_supplier = ennity.Name_supplier;
                content.CreatedDate = ennity.CreatedDate;
                content.Price = ennity.Price;
                content.Amount = ennity.Amount;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<m_product> ListAll()
        {
            return db.m_product.Where(x => x.Status_p == true).ToList();
        }

        public bool Delete(int id)
        {
            try
            {
                var user = db.m_supplier.Find(id);
                db.m_supplier.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool changeStatus(int id)
        {
            var user = db.m_supplier_product.Find(id);

            user.Status_SP = !user.Status_SP;
            db.SaveChanges();
            return user.Status_SP;
        }
    }
}
