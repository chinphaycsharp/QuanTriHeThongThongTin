namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class m_information
    {
        
        public int Id { get; set; }
        [Display(Name = "Ngaỳ tạo")]
        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Người tạo")]
        public string CreateBy { get; set; }
        [Display(Name = "Mã danh mục")]
        public int? IdCategory { get; set; }
        [Display(Name = "Trạng thái")]
        public bool? Status_I { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên bài viết")]
        public string Name { get; set; }

        [StringLength(250)]
        public string Image_P { get; set; }

        [StringLength(4000)]
        [Display(Name = "Nội dung bài viết")]
        [AllowHtml]
        public string content { get; set; }

        [StringLength(50)]
        [Display(Name = "Tiêu đề")]
        public string Metatile { get; set; }
    }
}
