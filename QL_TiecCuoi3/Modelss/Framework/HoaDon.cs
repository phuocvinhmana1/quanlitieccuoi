namespace Modelss.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [Key]
        public int MaHoaDon { get; set; }

        public int MaDatTiec { get; set; }

        public int? MaNhanVien { get; set; }

        [StringLength(100)]
        public string TongTien { get; set; }

        [StringLength(100)]
        public string TrangThai { get; set; }

        [StringLength(100)]
        public string TienCoc { get; set; }

        [StringLength(100)]
        public string MaGiamGia { get; set; }

        [StringLength(100)]
        public string NhanCocLan1 { get; set; }

        [StringLength(100)]
        public string NhanCocLan2 { get; set; }

        [StringLength(100)]
        public string ChiPhiPhatSinh { get; set; }

        public virtual DatTiec DatTiec { get; set; }
    }
}
