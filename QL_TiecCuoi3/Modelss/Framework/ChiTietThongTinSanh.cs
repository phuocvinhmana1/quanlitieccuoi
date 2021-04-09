namespace Modelss.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietThongTinSanh")]
    public partial class ChiTietThongTinSanh
    {
        [Key]
        public int MaChiTietSanh { get; set; }

        public int? MaSanh { get; set; }

        [StringLength(100)]
        public string Ten { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(100)]
        public string TrangThai { get; set; }

        public virtual ThongTinSanh ThongTinSanh { get; set; }
    }
}
