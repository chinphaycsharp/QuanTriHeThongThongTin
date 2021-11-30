using Model.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopV4.Models
{
    public class orderHistory
    {
        [Display(Name ="Mã hóa đơn")]
        public long ProductBillId { get; set; }
        [Display(Name ="Mã người mua")]
        public long CustomerId { get; set; }
        [Display(Name ="Giá bán")]
        public decimal? Price { get; set; }
        [Display(Name ="Ngày mua")]
        public DateTime? DateBuy { get; set; }
        [Display(Name ="Sản phẩm")]
        public List<m_product> products { get; set; }
    }

    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
    }
}