namespace Modelss.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDatTiec")]
    public partial class ChiTietDatTiec
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaChiTietDacTiet { get; set; }

        public int? MaDatTiec { get; set; }

        public int? MaSanh { get; set; }

        public int? MaKhachHang { get; set; }

        public int? MaThucDon { get; set; }

        public int? MaThucDonKHChon { get; set; }

        public int? MaTiec { get; set; }

        public int? MaNhanVien { get; set; }

        public int? MaGoiDichVu { get; set; }

        public virtual DatTiec DatTiec { get; set; }
    }
}
