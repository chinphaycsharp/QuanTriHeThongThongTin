namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_menutype
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string name { get; set; }
    }
}
