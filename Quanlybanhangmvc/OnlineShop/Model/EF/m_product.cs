namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class m_product
    {
        public long ID { get; set; }

        [StringLength(250)]
        [Display(Name= "Tên sản phẩm")]
        public string Name { get; set; }

        [StringLength(10)]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [StringLength(250)]
        [Display(Name = "Tiêu đề")]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        [Display(Name = "Mô tả")]
        public string Descreption { get; set; }

        [StringLength(250)]
        [Display(Name = "Ảnh sản phẩm")]
        public string Image_P { get; set; }

        [Column(TypeName = "xml")]
        public string More_Images { get; set; }
        [Display(Name = "Giá nhập")]
        public decimal? Price { get; set; }
        [Display(Name = "Giá bán")]
        public decimal? ProductPrice { get; set; }

        public bool? IncludeVAT { get; set; }

        public int? Quality { get; set; }

        [Display(Name = "Mã danh mục")]
        public long? CatetoryID { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Mô tả chi tiết sản phẩm")]
        [AllowHtml]
        public string Detail { get; set; }

        public int? Warranty { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status_p { get; set; }
        [Display(Name = "Sản phẩm hot")]
        public DateTime? Tophot { get; set; }
        [Display(Name = "Số người xem")]
        public int? Viewcount { get; set; }
    }
}
