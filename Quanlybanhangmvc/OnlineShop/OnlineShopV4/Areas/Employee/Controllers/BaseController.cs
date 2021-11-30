using OnlineShopV4.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShopV4.Areas.Employee.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuting(ActionExecutingContext filerContext)
        {
            var sess = (userLogin)Session[commonConst.user_employee];
            if (sess == null)
            {
                filerContext.Result = new RedirectToRouteResult
                    (new RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Employee" }));
            }
            base.OnActionExecuting(filerContext);
        }

        protected void setAleart(string Message ,string type)
        {
            TempData["AlertMessage"] = Message;
            if(type == "Success")
            {
                TempData["AlertType"] = "sufee-alert alert with-close alert-primary alert-dismissible fade show";
            }
            else if(type == "warning")
            {
                TempData["AlertType"] = "sufee-alert alert with-close alert-warning alert-dismissible fade show";
            }
            else if(type == "error")
            {
                TempData["AlertType"] = "sufee-alert alert with-close alert-danger alert-dismissible fade show";
            }
        }
    }
}