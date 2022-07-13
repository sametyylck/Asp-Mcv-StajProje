namespace stajproje2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ziyaretler")]
    public partial class Ziyaretler
    {
        [Key]
        public int z_id { get; set; }

        public int? sube_fk_id { get; set; }

        
        public DateTime? z_tarih { get; set; }

        [StringLength(50)]
        public string z_durum { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? z_islem_tarihi { get; set; }

        public int? z_user_id { get; set; }

        [StringLength(150)]
        public string z_not { get; set; }

        [StringLength(150)]
        public string z_resimm { get; set; }

        public int? z_olay_id { get; set; }

       
        public DateTime? z_olusturma { get; set; }

        [StringLength(50)]
        public string z_ismi { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? z_tarihgüncel { get; set; }

        public virtual Kullanıcı Kullanıcı { get; set; }

        public virtual Olay Olay { get; set; }

        public virtual Subeler Subeler { get; set; }
    }
}
