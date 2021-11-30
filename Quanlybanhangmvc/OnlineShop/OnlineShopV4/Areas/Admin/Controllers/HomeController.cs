using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopV4.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index(string Search, int page = 1, int pageSize = 4 )
        {
            var model = new ProductBillDao().listAllPaging(Search, page, pageSize);
            ViewBag.Search = Search;
            ProductDao product = new ProductDao();
            OrderBillDao o = new OrderBillDao();
            ViewBag.countIDP = product.countID();
            ViewBag.countIDO = o.countID();
            return View(model);
        }
    }
}