using Model.Dao;
using Model.EF;
using OnlineShopV4.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopV4.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string Search, int page = 1, int pageSize = 5)
        {
            var dao = new userDao();
            var model = dao.listAllPaging(Search, page, pageSize);
            ViewBag.Search = Search;
            return View(model);
        }

        public ActionResult DateCreateAccount(string Search, int page = 1, int pageSize = 5)
        {
            var dao = new userDao();
            var model = dao.listAllCreate(Search, page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(m_login user)
        {
            if (ModelState.IsValid)
            {
                var dao = new userDao();
                var encrypPass = encryptor.MD5Hash(user.Pass);
                user.Pass = encrypPass;
                int id = dao.Insert(user);
                if (id > 0)
                {
                    setAleart("Thêm tài khoản thành công !", "Success");
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user khong thành công");
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var user = new userDao().viewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(m_login acc)
        {
            if (!ModelState.IsValid)
            {
                var dao = new userDao();

                
                if (!string.IsNullOrEmpty(acc.Pass))
                {
                    var encrypPass = encryptor.MD5Hash(acc.Pass);
                    acc.Pass = encrypPass;
                }
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
            return View();
        }

        public ActionResult EditPermission(int id)
        {
            var user = new userDao().viewDetail(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult EditPermission(m_login acc)
        {
            if (!ModelState.IsValid)
            {
                var dao = new userDao();
                var result = dao.updatePermission(acc);
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
            return View();
        }



        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new userDao().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult changeStatus(int id)
        {
            var result = new userDao().changeStatus(id);
            return Json(new
            {
                stutus = result
            }) ;
        }
    }
}