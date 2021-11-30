namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_supplier
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Address_S { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public DateTime? TimeJoin { get; set; }

        public bool? Status_S { get; set; }
    }
}
