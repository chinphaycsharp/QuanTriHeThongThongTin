
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopV4.Areas.Admin.Data
{
    public class loginModel
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage ="Mời nhập username")]
        public string username { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Mời nhập password")]
        public string password { get; set; }
        public bool rememberme { get; set; }
    }
}