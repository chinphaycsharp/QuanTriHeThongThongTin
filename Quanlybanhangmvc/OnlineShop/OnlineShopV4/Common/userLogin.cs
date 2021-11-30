using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopV4.Common
{
    [Serializable]
    public class userLogin
    {
        public int userID { get; set; }
        public string Name_user { get; set; }
        public string Pass { get; set; }
        public int Permission { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime Lastlogin { get; set; }
        public bool StatusUser { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
    }
}