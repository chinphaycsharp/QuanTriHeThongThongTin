using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopV4.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { get; set; }
        [Display(Name="Tên đăng nhập")]
        [Required(ErrorMessage ="Yêu nhập tên đăng nhập")]
        public string UserName { get; set; }
        [Display(Name="Mật khẩu")]
        [StringLength(20,MinimumLength = 6 , ErrorMessage ="Độ dài phải lớn hơn 6")]
        [Required(ErrorMessage = "Yêu nhập tên mật khẩu")]
        public string PassWord { get; set; }
        [Compare("PassWord", ErrorMessage ="Xác nhận mật khẩu không đúng")]
        [Display(Name = "Xác nhận mật khẩu")]
        public string ConfirmPassWord { get; set; }
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Yêu nhập tên họ tên")]
        public string Name { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Yêu nhập tên email")]
        public string Email { get; set; }
        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Yêu nhập ngày sinh")]
        public DateTime Birthday { get; set; }
        [Display(Name = "Điện thoại")]
        public string Phone { get; set; }
        [Display(Name="Tinh/thành")]
        public string ProvinceID { get; set; }
        [Display(Name = "Quận/huyện")]
        public string DistrictID { get; set; }
    }
}