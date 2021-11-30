using Model.Dao;
using Model.EF;
using OnlineShopV4.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopV4.Areas.Admin.Controllers
{
    public class ChatController : BaseController
    {
        // GET: Admin/Chat
        public string adminmess = "", usermess = "";
        public ActionResult Index()
        {
            if (Session[commonConst.user_session] != null)
            {
                userLogin a = Session[commonConst.user_session] as userLogin;
                ViewBag.Name = a.Name_user;
                adminmess = a.Name_user;
            }

            if(Session[commonConst.user_client] != null)
            {
                userLogin a = Session[commonConst.user_client] as userLogin;
                ViewBag.NameClient = a.Name_user;
                usermess = a.Name_user;
            }

            if (Session[commonConst.user_employee] != null)
            {
                userLogin a = Session[commonConst.user_employee] as userLogin;
                ViewBag.NameEmployee = a.Name_user;
            }
            return View();
        }

        [HttpGet]
        public JsonResult GetUserMess()
        {
            string usermess = "";
            if (Session[commonConst.user_client] != null)
            {
                userLogin a = Session[commonConst.user_client] as userLogin;
                ViewBag.Name = a.Name_user;
                usermess = a.Name_user;
            }

            if (Session[commonConst.user_employee] != null)
            {
                userLogin a = Session[commonConst.user_employee] as userLogin;
                ViewBag.NameEmployee = a.Name_user;
            }

            var dao = new ChatDao();
            var result = dao.getAllMessUser(usermess);
            return Json(
                result,
                JsonRequestBehavior.AllowGet
            );
        }

        [HttpGet]
        public JsonResult GetAdminMess()
        {
            string adminmess = "";
            if (Session[commonConst.user_client] != null)
            {
                userLogin a = Session[commonConst.user_client] as userLogin;
                ViewBag.Name = a.Name_user;

            }

            if (Session[commonConst.user_employee] != null)
            {
                userLogin a = Session[commonConst.user_employee] as userLogin;
                ViewBag.NameEmployee = a.Name_user;
                adminmess = a.Name_user;
            }

            var dao = new ChatDao();
            var result = dao.getAllMessAdmin(adminmess);
            return Json(
                result,
                JsonRequestBehavior.AllowGet
            );
        }

        [HttpPost]
        public JsonResult Create(m_chat model)
        {
            var dao = new ChatDao();
            var result = dao.Insert(model);
            return Json(new
            {
                stutus = result
            });
        }
    }
}