namespace stajproje2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Satıs
    {
        [Key]
        public int sat_id { get; set; }

        [StringLength(50)]
        public string sat_urun { get; set; }

        public int? sat_adet { get; set; }

        public int? sat_fiyat { get; set; }

        public int? m_fk_id { get; set; }

        public int? user_id { get; set; }

        public int? toplam_fiyat { get; set; }

        public int? doviz_id { get; set; }

        public double doviz_fiyat { get; set; }

        public virtual Kullanıcı Kullanıcı { get; set; }

        public virtual Musteri Musteri { get; set; }
    }
}
