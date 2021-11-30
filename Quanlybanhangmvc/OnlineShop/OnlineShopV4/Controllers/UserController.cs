using BotDetect.Web.Mvc;
using Facebook;
using Model.Dao;
using Model.EF;
using OnlineShopV4.Common;
using OnlineShopV4.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Xml.Linq;

namespace OnlineShopV4.Controllers
{
    public class UserController : Controller
    {
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }

        // GET: User
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session[commonConst.user_client] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LoginFacebook()

        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FBkeyID"],

                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],

                redirect_uri = RedirectUri.AbsoluteUri,

                response_type = "code",

                scope = "email"

            });

            return Redirect(loginUrl.AbsoluteUri);

        }
        public ActionResult FacebookCallback(string code)

        {

            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new

            {

                client_id = ConfigurationManager.AppSettings["FBkeyID"],

                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],

                redirect_uri = RedirectUri.AbsoluteUri,

                code = code

            });

            var accessToken = result.access_token;
            Session["AccessToken"] = accessToken;
            fb.AccessToken = accessToken;
            if (!string.IsNullOrEmpty(accessToken))
            {
                dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
                string email = me.email;
                string Name_user = me.email;
                string firstname = me.first_name;
                string lastname = me.last_name;
                string middlename = me.middle_name;


                var user = new m_login();
                user.Name_user = firstname + " " + middlename + " " + lastname;
                user.Email = email;
                user.Status_user = true;
                user.Name = firstname + " " + middlename + " " + lastname;
                user.CreatedDate = DateTime.Now;
                user.Permission = 2;
                user.Addrress = null;
                user.Birthday = DateTime.Now;
                user.Phone = null;
                user.Pass = encryptor.MD5Hash("123456");

                var resultInsert = new userDao().InsertForFacebook(user);
                if (resultInsert > 0)
                {
                    var userSession = new userLogin();
                    userSession.userID = user.Id;
                    userSession.Name_user = user.Name_user;
                    userSession.Pass = user.Pass;
                    userSession.Name = user.Name;
                    userSession.Permission = user.Permission;
                    userSession.CreatedTime = user.CreatedDate;
                    userSession.Address = user.Addrress;
                    userSession.Phone = user.Phone;
                    userSession.Email = user.Email;
                    userSession.Birthday = user.Birthday;
                    Session.Add(commonConst.user_client, userSession);

                }
                FormsAuthentication.SetAuthCookie(email, false);
            }
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new userDao();
                var result = dao.Login(model.Username, encryptor.MD5Hash(model.PassWord));
                if (result == 2)
                {
                    var user = dao.getById(model.Username);
                    var userSession = new userLogin();
                    userSession.userID = user.Id;
                    userSession.Name_user = user.Name_user;
                    userSession.Pass = user.Pass;
                    userSession.Name = user.Name;
                    userSession.Permission = user.Permission;
                    userSession.CreatedTime = user.CreatedDate;
                    userSession.Address = user.Addrress;
                    userSession.Phone = user.Phone;
                    userSession.Email = user.Email;
                    userSession.Birthday = user.Birthday;
                    Session.Add(commonConst.user_client, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 1)
                {
                    var user = dao.getById(model.Username);
                    var userSession = new userLogin();
                    userSession.userID = user.Id;
                    userSession.Name_user = user.Name_user;
                    userSession.Pass = user.Pass;
                    userSession.Name = user.Name;
                    userSession.Permission = user.Permission;
                    userSession.CreatedTime = user.CreatedDate;
                    userSession.Address = user.Addrress;
                    userSession.Phone = user.Phone;
                    userSession.Email = user.Email;
                    userSession.Birthday = user.Birthday;
                    Session.Add(commonConst.user_client, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    var user = dao.getById(model.Username);
                    var userSession = new userLogin();
                    userSession.userID = user.Id;
                    userSession.Name_user = user.Name_user;
                    userSession.Pass = user.Pass;
                    userSession.Name = user.Name;
                    userSession.Permission = user.Permission;
                    userSession.CreatedTime = user.CreatedDate;
                    userSession.Address = user.Addrress;
                    userSession.Phone = user.Phone;
                    userSession.Email = user.Email;
                    userSession.Birthday = user.Birthday;
                    Session.Add(commonConst.user_client, userSession);
                    return RedirectToAction("Index", "Home");
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
            return View("Login");
        }

        [HttpPost]
        [CaptchaValidationActionFilter("CaptchaCode", "RegisterCaptcha", "Sai mã xác nhận ")]
        public ActionResult Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                var dao = new userDao();
                if(dao.chechUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (dao.checkEmaik(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var user = new m_login();
                    user.Name_user = model.Name;
                    user.Name = model.Name;
                    user.Pass = encryptor.MD5Hash(model.PassWord);
                    user.Phone = model.Phone;
                    user.Email = model.Email;
                    user.Birthday = model.Birthday;
                    user.Addrress = model.Address;
                    user.CreatedDate = DateTime.Now;
                    user.Status_user = true;
                    if(!string.IsNullOrEmpty(model.ProvinceID))
                    {
                        user.ProvinceID = int.Parse(model.ProvinceID);
                    }
                    if (!string.IsNullOrEmpty(model.DistrictID))
                    {
                        user.DistrictID =int.Parse(model.DistrictID);
                    }
                    var result = dao.Insert(user);
                    if(result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ViewBag.Success = "Đăng không ký thành công";
                    }
                }
            }
            return View(model);
        }

        public JsonResult LoadProvince ()
        {
            var xmlDoc = XDocument.Load(Server.MapPath(@"~/Assets/client/data/Provinces_Data.xml"));
            var xElement = xmlDoc.Element("Root").Elements("Item").Where(x => x.Attribute("type").Value == "province");
            var list = new List<ProvinceModel>();
            ProvinceModel pm = null;
            foreach (var item in xElement)
            {
                pm = new ProvinceModel();
                pm.ID = Convert.ToInt32(item.Attribute("id").Value);
                pm.Name = item.Attribute("value").Value;
                list.Add(pm);
            }
            return Json(new
            {
                data = list,
                status = true
            });
        }

        public JsonResult LoadDistrict(int ProvinceID)
        {
            var xmlDoc = XDocument.Load(Server.MapPath(@"~/Assets/client/data/Provinces_Data.xml"));
            var xElement = xmlDoc.Element("Root").Elements("Item").Single(x => x.Attribute("type").Value == "province" && int.Parse(x.Attribute("id").Value) == ProvinceID);
            var list = new List<DistrictModel>();
            DistrictModel district = null;
            foreach (var item in xElement.Elements("Item").Where(x=>x.Attribute("type").Value == "district"))
            {
                district = new DistrictModel();
                district.ID = Convert.ToInt32(item.Attribute("id").Value);
                district.Name = item.Attribute("value").Value;
                district.ProviceID = Convert.ToInt32(xElement.Attribute("id").Value);
                list.Add(district);
            }
            return Json(new
            {
                data = list,
                status = true
            });
        }
    }
}