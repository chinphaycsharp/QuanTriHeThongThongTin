using Model.Dao;
using Model.EF;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopV4.Areas.Admin.Controllers
{
    public class ProductBillController : BaseController
    {
        // GET: Admin/PopUp
        public ActionResult Index(string Search, int page = 1, int pageSize = 5)
        {
            var model = new ProductBillDao().listAllPaging(Search, page, pageSize);
            ViewBag.Search = Search;
            
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = new ProductBillDao().viewDetail(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(m_product_bill acc)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductBillDao();
                var result = dao.update(acc);
                if (result)
                {
                    setAleart("Sửa tài khoản thành công !", "Success");
                    return RedirectToAction("Index", "ProductBill");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhập không thành công");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(m_product_bill user)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductBillDao();
                long id = dao.Insert(user);
                if (id > 0)
                {
                    setAleart("Thêm tài khoản thành công !", "Success");
                    return RedirectToAction("Index", "ProductBill");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user khong thành công");
                }
            }
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProductBillDao().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult changeStatus(int id)
        {
            var result = new ProductBillDao().changeStatus(id);
            return Json(new
            {
                stutus = result
            });
        }

        public ActionResult DetailBill(int id)
        {
            ViewBag.ShipName = new ProductBillDao().getNameBill(id);
            ViewBag.CreateDate = new ProductBillDao().getCreateBill(id);
            ViewBag.PhoneBill = new ProductBillDao().getPhoneBill(id);
            ViewBag.AddressBill = new ProductBillDao().getAddressBill(id);
            ViewBag.EmailBill = new ProductBillDao().getEmailBill(id);
            ViewBag.IdBill = new ProductBillDao().getIdBill(id);
            bool b = new ProductBillDao().getStatusBill(id);
            if(b)
            {
                ViewBag.StatusBill = "Đã giao hàng vào ngày " + DateTime.Now;
            }
            else
            {
                ViewBag.StatusBill = "Chưa giao hàng";
            }
            return View();
        }

        public ActionResult getAll()
        {
            var getAll = new ProductBillDao().getAll();
            return View(getAll);
        }

        public ActionResult PrintPDF()
        {
            var pdf = new ActionAsPdf("getAll");
            return pdf;
        }
    }
}