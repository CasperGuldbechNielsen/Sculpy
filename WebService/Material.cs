namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Material")]
    public partial class Material
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Material()
        {
            Sculpture_Material = new HashSet<Sculpture_Material>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Material_Name { get; set; }

        public int Material_Type_ID { get; set; }

        public virtual Material_Type Material_Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sculpture_Material> Sculpture_Material { get; set; }
    }
}
