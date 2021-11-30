using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopV4.Areas.Admin.Controllers
{
    public class SupplierProductController : Controller
    {
        // GET: Admin/Supplier
        public ActionResult Index(string Search, int page = 1, int pageSize = 5)
        {
            var dao = new SupplierProductDao();
            var model = dao.listAllPaging(Search, page, pageSize);
            ViewBag.Search = Search;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag_Supplier();
            SetViewBag_Product();
            return View();
        }

        [HttpPost]
        public ActionResult Create(m_supplier_product model)
        {
            if (ModelState.IsValid)
            {
                var dao = new SupplierProductDao();
                long id = dao.Insert(model);
                if (id > 0)
                {
                    return RedirectToAction("Index", "SupplierProduct");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user thành công");
                }
            }
            SetViewBag_Product();
            SetViewBag_Supplier();
            return View();
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new SupplierProductDao();
            var content = dao.getById(id);
            var detail = new SupplierProductDao().viewDetail(id);

            SetViewBag_Product(content.Id_Product);
            SetViewBag_Supplier(content.Id_supplier);
            return View(detail);
        }

        [HttpPost]
        public ActionResult Edit(m_supplier_product model)
        {
            if (ModelState.IsValid)
            {
                var dao = new SupplierProductDao();
                var result = dao.update(model);
                if (result)
                {
                    return RedirectToAction("Index", "Content");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhập không thành công");
                }
            }
            SetViewBag_Product(model.Id_Product);
            SetViewBag_Supplier(model.Id_supplier);
            return View("Index");
        }

        public void SetViewBag_Product(long? selectedId = null)
        {
            var dao = new ProductDao();
            ViewBag.Id_supplier = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }

        public void SetViewBag_Supplier(long? selectedId = null)
        {
            var dao = new SupplierDao();
            ViewBag.Id_Product = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new contentDao().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult changeStatus(int id)
        {
            var result = new SupplierProductDao().changeStatus(id);
            return Json(new
            {
                stutus = result
            });
        }
    }
}