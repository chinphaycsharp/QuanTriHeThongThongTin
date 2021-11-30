using Model.Dao;
using OnlineShopV4.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopV4.Controllers
{
    public class ProductBillController : Controller
    {
        // GET: ProductBill
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            int cusID = 0;
            if (Session[commonConst.user_client] != null)
            {
                userLogin a = Session[commonConst.user_client] as userLogin;
                cusID = a.userID;
            }
            var dao = new ProductBillDao();
            var model = dao.GetOrderHistories(cusID, page, pageSize);
            //ViewBag.Search = Search;
            return View(model);
        }
    }
}