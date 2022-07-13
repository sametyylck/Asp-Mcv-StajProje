namespace stajproje2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Kullanıcı
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanıcı()
        {
            Satıs = new HashSet<Satıs>();
            Ziyaretler = new HashSet<Ziyaretler>();
        }

        [Key]
        public int k_id { get; set; }

        [StringLength(20)]
        public string k_username { get; set; }

        [StringLength(30)]
        public string k_mail { get; set; }

        [StringLength(20)]
        public string k_password { get; set; }

        [StringLength(50)]
        public string k_isim { get; set; }

        [StringLength(50)]
        public string k_tel { get; set; }

        public DateTime? k_baslangıc { get; set; }

        [StringLength(50)]
        public string k_Rol { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? k_islem_tarihi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Satıs> Satıs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ziyaretler> Ziyaretler { get; set; }
    }
}
