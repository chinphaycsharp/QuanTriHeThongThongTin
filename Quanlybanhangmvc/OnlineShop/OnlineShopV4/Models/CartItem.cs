using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopV4.Models
{
    [Serializable]
    public class CartItem
    {

        public m_product Product { get; set; }
        public int Quantity { get; set; }
    }
}