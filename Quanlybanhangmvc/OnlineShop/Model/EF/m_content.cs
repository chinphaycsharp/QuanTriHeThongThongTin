namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_content
    {
        public long ID { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên tin tức")]
        public string Name { get; set; }

        [StringLength(250)]
        [Display(Name = "Tiêu đề")]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        [Display(Name = "Mô tả")]
        public string Descreption { get; set; }

        [StringLength(250)]
        [Display(Name = "Ảnh sản phẩm")]
        public string Image_C { get; set; }
        [Display(Name = "Mã danh mục")]
        public long? CatetoryID { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Thông tin tiết")]
        public string Detail { get; set; }

        public int? Warranty { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CrratedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }
        [Display(Name = "Trạng thái")]
        public bool? Status_p { get; set; }
        [Display(Name = "Ngày trên top")]
        public DateTime? Tophot { get; set; }
        [Display(Name = "Số người xem")]
        public int? ViewCount { get; set; }

        [StringLength(500)]
        public string Tag { get; set; }
    }
}
