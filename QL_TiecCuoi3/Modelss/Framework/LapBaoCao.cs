namespace Modelss.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LapBaoCao")]
    public partial class LapBaoCao
    {
        [Key]
        public int MaBaoCao { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayLap { get; set; }

        public int? MaNhanVien { get; set; }

        public int? Thang { get; set; }

        public int? SoLuongTiec { get; set; }

        public int? DoanhThu { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
