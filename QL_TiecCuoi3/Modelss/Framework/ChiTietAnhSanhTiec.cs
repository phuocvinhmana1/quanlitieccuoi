namespace Modelss.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietAnhSanhTiec")]
    public partial class ChiTietAnhSanhTiec
    {
        [Key]
        public int MaChiTiet { get; set; }

        public int? MaSanhTiec { get; set; }

        [StringLength(100)]
        public string AnhChiTiet { get; set; }

        public virtual ThongTinSanh ThongTinSanh { get; set; }
    }
}
