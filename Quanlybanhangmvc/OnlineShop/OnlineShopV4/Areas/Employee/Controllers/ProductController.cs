using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopV4.Areas.Employee.Controllers
{
    public class ProductController : BaseController
    {
        public ActionResult Index(string Search, int page = 1, int pageSize = 2)
        {
            var dao = new ProductDao();
            var model = dao.listAllPaging(Search, page, pageSize);
            ViewBag.Search = Search;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag_Supplier();
            return View();
        }

        [HttpPost]
        public ActionResult Create(m_product user)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                long id = dao.Insert(user);
                if (id > 0)
                {
                    setAleart("Thêm tài khoản thành công !", "Success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user khong thành công");
                }
            }
            SetViewBag_Supplier();
            return View();
        }

        public ActionResult Edit(long id)
        {
            var dao = new ProductDao();
            var content = dao.getById(id);
            var detail = new ProductDao().viewDetail(id);

            SetViewBag_Supplier(content.CatetoryID);
            return View(detail);
        }
        [HttpPost]
        public ActionResult Edit(m_product acc)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var result = dao.update(acc);
                if (result)
                {
                    setAleart("Sửa tài khoản thành công !", "Success");
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhập không thành công");
                }
            }
            SetViewBag_Supplier();
            return View();
        }

        public void SetViewBag_Supplier(long? selectedId = null)
        {
            var dao = new ProductDao();
            ViewBag.CatetoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new ProductDao().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult changeStatus(int id)
        {
            var result = new ProductDao().changeStatus(id);
            return Json(new
            {
                stutus = result
            });
        }
    }
}