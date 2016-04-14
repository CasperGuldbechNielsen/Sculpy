namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Inspection")]
    public partial class Inspection
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Inspection_Date { get; set; }

        [Required]
        [StringLength(1000)]
        public string Inspection_Note { get; set; }

        public int Sculpture_ID { get; set; }

        public byte[] Damage_Picture { get; set; }
    }
}
