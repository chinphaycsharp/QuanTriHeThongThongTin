namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_login
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage ="Vui lòng nhập tài khoản")]
        public string Name_user { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string Pass { get; set; }
        [Display(Name="Quyền")]
        public int Permission { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? Lastlogin { get; set; }
        [Display(Name = "Trạng thái")]
        public bool Status_user { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Addrress { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public DateTime Birthday { get; set; }

        public int? ProvinceID { get; set; }

        public int? DistrictID { get; set; }
    }
}
