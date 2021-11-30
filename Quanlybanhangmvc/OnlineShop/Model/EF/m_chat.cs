namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_chat
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Name_receive { get; set; }
        [StringLength(20)]
        public string Name_send { get; set; }

        [StringLength(500)]
        public string Content { get; set; }

        public DateTime? SendDate { get; set; }
    }
}
