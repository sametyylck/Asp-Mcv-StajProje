namespace stajproje2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Musteri")]
    public partial class Musteri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Musteri()
        {
            Satıs = new HashSet<Satıs>();
        }

        [Key]
        public int m_id { get; set; }

        [StringLength(20)]
        public string m_ad { get; set; }

        [StringLength(11)]
        public string m_tel { get; set; }

        [StringLength(20)]
        public string m_mail { get; set; }

        [StringLength(50)]
        public string m_sirket { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? m_islem_tarihi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Satıs> Satıs { get; set; }
    }
}
