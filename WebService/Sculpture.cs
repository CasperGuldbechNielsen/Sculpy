namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sculpture")]
    public partial class Sculpture
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Sculpture_Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Sculpture_Placement { get; set; }

        [StringLength(50)]
        public string Sculpture_Address { get; set; }

        [StringLength(500)]
        public string Sculpture_Description { get; set; }

        [StringLength(30)]
        public string Sculpture_Inspection_Frequency { get; set; }

        public byte[] Sculpture_Picture { get; set; }
    }
}
