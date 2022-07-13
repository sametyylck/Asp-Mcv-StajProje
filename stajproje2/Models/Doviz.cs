namespace stajproje2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Doviz")]
    public partial class Doviz
    {
        [Key]
        public int doviz_id { get; set; }

        [StringLength(100)]
        public string dovizname { get; set; }
    }
}
