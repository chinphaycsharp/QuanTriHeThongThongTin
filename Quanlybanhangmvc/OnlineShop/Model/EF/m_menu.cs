namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_menu
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string Text_M { get; set; }

        [StringLength(50)]
        public string Link { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(50)]
        public string Target_m { get; set; }

        public bool? Status_m { get; set; }

        public int? TypeID { get; set; }
    }
}
