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
    public class InformationController : BaseController
    {
        // GET: Admin/Information
        public ActionResult Index()
        {
            if (Session[commonConst.user_session] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            userLogin userLogin = Session[commonConst.user_session] as userLogin;
            ViewBag.ID = userLogin.userID;
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
            if (ModelState.IsValid)
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
    }
}