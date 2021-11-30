using Model.EF;
using OnlineShopV4.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductBillDao
    {
        onlineShop db = null;

        public ProductBillDao()
        {
            db = new onlineShop();
        }

        public long Insert(m_product_bill login)
        {
            db.m_product_bill.Add(login);
            db.SaveChanges();
            return login.Id;
        }
        public m_product_bill viewDetail(int id)
        {
            return db.m_product_bill.Find(id);
        }

        public IEnumerable<m_product_bill> listAllPaging(string Search, int page, int pageSize)
        {
            IQueryable<m_product_bill> model = db.m_product_bill;
            if (!string.IsNullOrEmpty(Search))
            {
                model = model.Where(x => x.ShipName.Contains(Search) || x.CreatedDate.ToString().Contains(Search));
            }

            return model.OrderByDescending(x => x.Id).ToPagedList(page, pageSize);
        }

        public IEnumerable<orderHistory> GetOrderHistories(int cusID, int page, int pageSize)
        {
            var model = from a in db.m_product_bill
                        join b in db.m_order_bill on a.Id equals b.ProductBill
                        join c in db.m_product on b.ProductId equals c.ID
                        where a.CustomerID == cusID
                        select new { a,c };
            var lst = from m in model
                      group m by new { m.a.Id, m.a.CustomerID, m.a.CreatedDate, m.a.Price } into gr
                      select new orderHistory
                      {
                          ProductBillId = gr.Key.Id,
                          CustomerId = gr.Key.CustomerID??-1,
                          DateBuy = gr.Key.CreatedDate,
                          Price = gr.Key.Price,
                          products = gr.Select(x => x.c).ToList()
                      };
            return lst.OrderByDescending(x=>x.CustomerId).ToPagedList(page,pageSize);
        }

        public List<m_product_bill> ListAll()
        {
            return db.m_product_bill.Where(x => x.status_b == true).ToList();
        }

        public bool update(m_product_bill ennity)
        {
            try
            {
                var user = db.m_product_bill.Find(ennity.Id);
                user.CreatedDate = ennity.CreatedDate;
                user.CustomerID = ennity.CustomerID;
                user.shipPhone = ennity.shipPhone;
                user.ShipAddress = ennity.ShipAddress;
                user.ShipEmail = ennity.ShipEmail;
                user.ShipName = ennity.ShipName;
                user.status_b = ennity.status_b;
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
                var user = db.m_product_bill.Find(id);
                db.m_product_bill.Remove(user);
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
            var user = db.m_product_bill.Find(id);

            user.status_b = !user.status_b;
            db.SaveChanges();
            return user.status_b;
        }

        public string getNameBill(int id)
        {
            var name = db.m_product_bill.Where(x => x.Id == id).Select(x => x.ShipName).Single();
            return name;    
        }
        public DateTime getCreateBill(int id)
        {
            var date = (DateTime)db.m_product_bill.Where(x => x.Id == id).Select(x => x.CreatedDate).Single();
            return date;
        }
        public string getPhoneBill(int id)
        {
            var phone = db.m_product_bill.Where(x => x.Id == id).Select(x => x.shipPhone).Single();
            return phone;
        }
        public string getAddressBill(int id)
        {
            var Address = db.m_product_bill.Where(x => x.Id == id).Select(x => x.ShipAddress).Single();
            return Address;
        }
        public string getEmailBill(int id)
        {
            var email = db.m_product_bill.Where(x => x.Id == id).Select(x => x.ShipEmail).Single();
            return email;
        }
        public bool getStatusBill(int id)
        {
            var status = db.m_product_bill.Where(x => x.Id == id).Select(x => x.status_b).Single();
            return status;
        }

        public long getIdBill(int id)
        {
            var idbill = db.m_product_bill.Where(x => x.Id == id).Select(x => x.Id).Single();
            return idbill;
        }

        public List<m_product_bill> getAll()
        {
            return db.m_product_bill.ToList();
        }
    }
}
