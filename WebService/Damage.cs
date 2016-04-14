namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Damage")]
    public partial class Damage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Damage()
        {
            Sculpture_Damage = new HashSet<Sculpture_Damage>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Damage_Type { get; set; }

        [Required]
        [StringLength(30)]
        public string Damage_Treatment { get; set; }

        public int Inspection_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sculpture_Damage> Sculpture_Damage { get; set; }
    }
}
