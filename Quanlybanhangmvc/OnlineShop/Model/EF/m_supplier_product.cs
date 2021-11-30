namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_supplier_product
    {
        public int Id { get; set; }
        [Display(Name = "Nhà cung cấp")]
        [Required(ErrorMessage = "Bạn phải nhập đầy đủ thông tin")]
        public int? Id_supplier { get; set; }
        [Display(Name = "Loại sản phẩm")]
        [Required(ErrorMessage = "Bạn phải nhập đầy đủ thông tin")]
        public int? Id_Product { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên nhà cung cấp")]
        [Required(ErrorMessage = "Bạn phải nhập đầy đủ thông tin")]
        public string Name_supplier { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Bạn phải nhập đầy đủ thông tin")]
        [Display(Name = "tên sản phẩm")]
        public string Name_Product { get; set; }
        [Display(Name = "Ngày tạo")]
        [Required(ErrorMessage = "Bạn phải nhập đầy đủ thông tin")]
        public DateTime? CreatedDate { get; set; }
        [Display(Name = "Giá sản phẩm")]
        [Required(ErrorMessage = "Bạn phải nhập đầy đủ thông tin")]
        public decimal? Price { get; set; }
        [Display(Name = "Số lượng")]
        [Required(ErrorMessage = "Bạn phải nhập đầy đủ thông tin")]
        public int? Amount { get; set; }
        [Display(Name = "Trạng thái")]
        [Required(ErrorMessage = "Bạn phải nhập đầy đủ thông tin")]
        public bool Status_SP { get; set; }
    }
}
