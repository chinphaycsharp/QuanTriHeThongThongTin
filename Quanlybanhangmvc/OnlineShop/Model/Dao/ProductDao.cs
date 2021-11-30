using Model.EF;
using Model.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductDao
    {
        private onlineShop db = null;

        public ProductDao()
        {
            db = new onlineShop();
        }

        public List<m_productCatetory> ListAll()
        {
            return db.m_productCatetory.Where(x => x.Status_P == true).ToList();
        }

        public List<m_product> ListNewProduct(int top)
        {
            return db.m_product.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        public List<m_product> ListFeatureProduct(int top)
        {
            return db.m_product.Where(x => x.Tophot != null && x.Tophot > DateTime.Now).OrderByDescending(x => x.CreatedDate).Take(top).ToList(); 
        }

        public List<m_product> ListRelatedProduct(long productId)
        {
            var product = db.m_product.Find(productId);
            return db.m_product.Where(x => x.ID != productId && x.CatetoryID == product.CatetoryID).ToList() ;
        }

        //public List<m_product> ListbyCatetoryId(long cateId, int pageIndex = 1 , int pageSize =2)
        //{
        //    return db.m_product.Where(x => x.CatetoryID == cateId).ToList();
        //}

        public List<ProductViewModel> ListbyCatetoryId(long cateId, ref int total, int pageIndex = 1, int pageSize = 2)
        {
            total = db.m_product.Where(x => x.CatetoryID == cateId).Count();
            var model = from a in db.m_product
                        join b in db.m_productCatetory
                        on a.CatetoryID equals b.Id
                        where a.CatetoryID == cateId
                        select new ProductViewModel
                        {
                            CateMetaTitle = b.MetaTitle,
                            CateName = b.Name,
                            CreateDate = a.CreatedDate,
                            ID = a.ID,
                            Images = a.Image_P,
                            Name = a.Name,
                            MetaTitle = a.MetaTitle,
                            Price = a.Price,
                            Status = a.Status_p,
                            Quality = a.Quality ??-1
                        };
            model.OrderByDescending(x => x.CreateDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }

        public List<ProductViewModel> Search(string keyword, ref int total, int pageIndex = 1, int pageSize = 2)
        {
            total = db.m_product.Where(x => x.Name == keyword).Count();
            var model = (from a in db.m_product
                         join b in db.m_productCatetory
                         on a.CatetoryID equals b.Id
                         where a.Name.Contains(keyword)
                         select new
                         {
                             CateMetaTitle = b.MetaTitle,
                             CateName = b.Name,
                             CreatedDate = a.CreatedDate,
                             ID = a.ID,
                             Images = a.Image_P,
                             Name = a.Name,
                             MetaTitle = a.MetaTitle,
                             Price = a.Price,
                             Status = a.Status_p,
                             Quality = a.Quality ?? -1
                         }).AsEnumerable().Select(x => new ProductViewModel()
                         {
                             CateMetaTitle = x.MetaTitle,
                             CateName = x.Name,
                             CreateDate = x.CreatedDate,
                             ID = x.ID,
                             Images = x.Images,
                             Name = x.Name,
                             MetaTitle = x.MetaTitle,
                             Price = x.Price,
                             Status = x.Status,
                         });
            model.OrderByDescending(x => x.CreateDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }

        public m_product viewDetail(long id)
        {
            return db.m_product.Find(id);
        }

        public long Insert(m_product login)
        {
            db.m_product.Add(login);
            db.SaveChanges();
            return login.ID;
        }

        public IEnumerable<m_product> listAllPaging(string Search, int page, int pageSize)
        {
            IQueryable<m_product> model = db.m_product;
            if (!string.IsNullOrEmpty(Search))
            {
                model = model.Where(x => x.Name.Contains(Search) || x.CreatedDate.ToString().Contains(Search) || x.Descreption.Contains(Search));
            }

            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }

        public m_product getById(long id)
        {
            return db.m_product.Find(id);
        }

        public bool update(m_product ennity)
        {
            try
            {
                var product = db.m_product.Find(ennity.ID);
                product.Name = ennity.Name;
                product.Descreption = ennity.Descreption;
                product.Image_P = ennity.Image_P;
                product.Price = ennity.Price;
                product.ProductPrice = ennity.ProductPrice;
                product.CatetoryID = ennity.CatetoryID;
                product.Detail = ennity.Detail;
                product.CreatedDate = ennity.CreatedDate;
                product.Status_p = ennity.Status_p;
                product.Tophot = ennity.Tophot;
                product.Viewcount = ennity.Viewcount;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                var user = db.m_product.Find(id);
                db.m_product.Remove(user);
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
            var user = db.m_product.Find(id);

            user.Status_p = !user.Status_p;
            db.SaveChanges();
            return user.Status_p;
        }

        public List<string> listName(string keyword)
        {
            return db.m_product.Where(x => x.Name.Contains(keyword)).Select(x => x.Name).ToList();
        }

        public long countID()
        {
            var count = db.m_product.Count();
            return count;
        }
    }
}
