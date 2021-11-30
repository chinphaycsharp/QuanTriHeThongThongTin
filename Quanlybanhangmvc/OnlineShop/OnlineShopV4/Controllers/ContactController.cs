using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopV4.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            var model = new ContactDao().getActiveContact();
            return View(model);
        }

        [HttpPost]
        public JsonResult Send(string name,string phone,string address,string email,string content)
        {
            var feedBack = new m_feedback();
            feedBack.Name = name;
            feedBack.Email = email;
            feedBack.CreatedDate = DateTime.Now;
            feedBack.Phone = phone;
            feedBack.Content = content;
            feedBack.Addrres = address;

            var id = new ContactDao().insert(feedBack);
            if(id > 0)
            {
                return Json(new
                {
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }
    }
}