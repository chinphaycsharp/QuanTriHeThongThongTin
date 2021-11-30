namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_bill
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public decimal? Price { get; set; }

        [StringLength(15)]
        public string TaxCode { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool? StatusBill { get; set; }
    }
}
