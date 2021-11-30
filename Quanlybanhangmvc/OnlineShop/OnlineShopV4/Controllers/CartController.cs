using Model.Dao;
using OnlineShopV4.Common;
using OnlineShopV4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Model.EF;
using System.Configuration;
using Common;

namespace OnlineShopV4.Controllers
{
    public class CartController : Controller
    {
        public const string cartSession = "cartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[cartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        public JsonResult Update(string cartModel)
        {
            var cart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[cartSession];

            foreach (var item in sessionCart)
            {
                var jsonitem = cart.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if(jsonitem != null)
                {
                    item.Quantity = jsonitem.Quantity;
                }
            }
            Session[cartSession] = sessionCart;
            return Json(new { 
                status = true
            });
        }

        public JsonResult DeleteAll()
        {
            Session[cartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[cartSession];
            var o = sessionCart.Find(x => x.Product.ID == id);
            sessionCart.Remove(o);
            Session[cartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[cartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list) ;
        }

        [HttpPost]
        public ActionResult Payment(string shipname, string mobile, string address,string email)
        {
            var order = new m_product_bill();
            order.CreatedDate = DateTime.Now;
            order.ShipAddress = address;
            order.shipPhone = mobile;
            order.ShipName = shipname;
            order.ShipEmail = email;
            if (Session[commonConst.user_client] != null)
            {
                userLogin a = Session[commonConst.user_client] as userLogin;
                order.CustomerID = Convert.ToInt64(a.userID);
            }
            try
            {
                var id = new OrderDao().Insert(order);
                var cart = (List<CartItem>)Session[cartSession];
                var detailDao = new OrderBillDao();
                decimal total = 0;
                foreach (var item in cart)
                {
                    var orderDetail = new m_order_bill();
                    orderDetail.ProductId = item.Product.ID;
                    orderDetail.ProductBill = id;
                    orderDetail.Price = item.Product.Price;
                    orderDetail.Quantity = item.Quantity;
                    detailDao.Insert(orderDetail);
                    total += (item.Product.Price.GetValueOrDefault(0) * item.Quantity);
                }
                Session["cartSession"] = null;
                //string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/client/template/neworder.html"));
                //content = content.Replace("{{CustomerName}}", shipname);
                //content = content.Replace("{{Phone}}", mobile);
                //content = content.Replace("{{Email}}", email);
                //content = content.Replace("{{Address}}", address);
                //content = content.Replace("{{Total}}", total.ToString("N0"));
                //var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                //new MailHelper().SendMail(email, "Đơn hàng mới từ OnlineShop", content);
                //new MailHelper().SendMail(toEmail, "Đơn hàng mới từ OnlineShop", content);
            }
            catch(Exception ex)
            {
                return Redirect("/loi-thanh-toan");
            }
            return Redirect("/hoan-thanh");
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult AddItem(long productID, string NotesSiteName, int quantity)
        {
            var product = new ProductDao().viewDetail(productID);
            var cart = Session[cartSession];
            if(cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x=>x.Product.ID== productID))
                {
                    foreach (var item in list)
                    {
                        if (item.Product == product)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                Session[cartSession] = list;
            }
            else
            {
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var listItem = new List<CartItem>();
                listItem.Add(item);
                Session[cartSession] = listItem;
            }
            ViewBag.NotesSiteName = NotesSiteName;
            return RedirectToAction("Index");
        }
    }
}