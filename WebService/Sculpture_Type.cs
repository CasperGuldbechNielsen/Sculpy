namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sculpture_Type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sculpture_Type()
        {
            Sculpture_Type_Linking = new HashSet<Sculpture_Type_Linking>();
        }

        public int ID { get; set; }

        [Column("Sculpture_Type")]
        [StringLength(30)]
        public string Sculpture_Type1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sculpture_Type_Linking> Sculpture_Type_Linking { get; set; }
    }
}
