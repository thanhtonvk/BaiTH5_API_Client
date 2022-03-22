namespace BaiTH5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Monhoc")]
    public partial class Monhoc
    {
        [Key]
        public int Mamh { get; set; }

        [StringLength(100)]
        public string Tenmh { get; set; }

        [StringLength(100)]
        public string chyennganh { get; set; }

        [StringLength(100)]
        public string Sohoctrinh { get; set; }
    }
}
