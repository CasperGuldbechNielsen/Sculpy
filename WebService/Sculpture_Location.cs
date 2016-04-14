namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sculpture_Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Sculpture_ID { get; set; }

        public int? Sculpture_Zip_Code { get; set; }

        [StringLength(30)]
        public string Sculpture_City { get; set; }

        public decimal? Sculpture_Lat { get; set; }

        public decimal? Sculpture_Long { get; set; }
    }
}
