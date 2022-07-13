namespace stajproje2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Subeler")]
    public partial class Subeler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subeler()
        {
            Ziyaretler = new HashSet<Ziyaretler>();
        }

        [Key]
        public int sube_id { get; set; }

        [StringLength(20)]
        public string sube_ad { get; set; }

        [StringLength(20)]
        public string sube_il { get; set; }

        [StringLength(11)]
        public string sube_tel { get; set; }

        [StringLength(200)]
        public string sube_adres { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? s_islem_tarihi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ziyaretler> Ziyaretler { get; set; }
    }
}
