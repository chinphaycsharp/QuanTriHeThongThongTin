using Model.Dao;
using OnlineShopV4.Common;
using OnlineShopV4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace OnlineShopV4.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Slides = new slideDao().listAll();
            var productDao = new ProductDao();
            ViewBag.NewProducts = productDao.ListNewProduct(5);
            ViewBag.NewFeatureProducts = productDao.ListFeatureProduct(5);
            return View();
        }

        [ChildActionOnly]

        public ActionResult MainMenu()
        {
            var model = new MenuDao().ListByGroupID(1);
            return PartialView(model);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600 * 24, VaryByParam = "None")]
        public ActionResult Footer()
        
        {
            var model = new FooterDao().GetFooter();
            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[commonConst.cartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }
    }
} 