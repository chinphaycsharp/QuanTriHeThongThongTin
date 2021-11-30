using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopV4.Areas.Employee.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        public ActionResult Index(string Search, int page = 1, int pageSize = 2)
        {
            var dao = new contentDao();
            var model = dao.listAllPaging(Search, page, pageSize);
            ViewBag.Search = Search;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(m_information model)
        {
            if(ModelState.IsValid)
            {
                var dao = new contentDao();
                long id = dao.Insert(model);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Content");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user thành công");
                }
            }
            SetViewBag();
            return View();
        }
        
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new contentDao();
            var content = dao.getById(id);
            var detail = new contentDao().viewDetail(id);

            SetViewBag(content.IdCategory);
            return View(detail);
        }

        [HttpPost]
        public ActionResult Edit(m_information model)
        {
            if(ModelState.IsValid)
            {
                var dao = new contentDao();
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
            SetViewBag(model.IdCategory);
            return View("Index");
        }

        public void SetViewBag(long? selectedId = null)
        {
            var dao = new CatetoryDao();
            ViewBag.CatetoryID = new SelectList(dao.ListAll(), "ID", "Name",selectedId);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new contentDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}