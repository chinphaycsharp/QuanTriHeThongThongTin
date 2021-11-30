using Model.Dao;
using OnlineShopV4.Areas.Admin.Data;
using OnlineShopV4.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopV4.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(loginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new userDao();
                var result = dao.Login(model.username, encryptor.MD5Hash(model.password));
                if (result == 2)
                {
                    var user = dao.getById(model.username);
                    var userSession = new userLogin();
                    userSession.userID = user.Id;
                    userSession.Name_user = user.Name_user;
                    userSession.Name = user.Name;
                    userSession.Permission = user.Permission;
                    userSession.CreatedTime = user.CreatedDate;
                    userSession.Address = user.Addrress;
                    userSession.Phone = user.Phone;
                    userSession.Email = user.Email;
                    userSession.Birthday = user.Birthday;
                    Session.Add(commonConst.user_session, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 1)
                {
                    ModelState.AddModelError("", "Bạn không có quyền vào trang này !");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Bạn không có quyền vào trang này !");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa !");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng !");
                }
            }
            return View("Index");
        }
    }
}