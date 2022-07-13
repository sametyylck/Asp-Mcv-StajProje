namespace stajproje2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Olay")]
    public partial class Olay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Olay()
        {
            Ziyaretler = new HashSet<Ziyaretler>();
        }

        [Key]
        public int olay_id { get; set; }

        [StringLength(50)]
        public string olay_durum { get; set; }

        [StringLength(50)]
        public string olay_islem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ziyaretler> Ziyaretler { get; set; }
    }
}
