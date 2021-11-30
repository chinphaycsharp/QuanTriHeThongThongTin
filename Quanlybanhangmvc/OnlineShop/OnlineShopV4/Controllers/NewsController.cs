using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopV4.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            var productDao = new NewsDao();
            ViewBag.News = productDao.ListNew(5);
            return View();
        }

        public ActionResult DetailNews(int idN)
        {
            var product = new NewsDao().viewDetail(idN);
            return View(product);
        }
    }
}