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

        public string Inspection_Title { get; set; }

        public int Sculpture_ID { get; set; }

        public string Damage_Picture { get; set; }

        public string Treatment_Type { get; set; }

        public string Damage_Type { get; set; }

        public string Treatment_Plan { get; set; }


    }
}

