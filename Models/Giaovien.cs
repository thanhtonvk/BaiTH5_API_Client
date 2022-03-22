namespace BaiTH5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Giaovien")]
    public partial class Giaovien
    {
        [Key]
        public int Magv { get; set; }

        [StringLength(100)]
        public string Tengv { get; set; }

        [StringLength(100)]
        public string chyennganh { get; set; }

        [StringLength(100)]
        public string diachi { get; set; }

        public int? sdt { get; set; }
    }
}
