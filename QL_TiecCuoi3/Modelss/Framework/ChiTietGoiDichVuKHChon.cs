namespace Modelss.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietGoiDichVuKHChon")]
    public partial class ChiTietGoiDichVuKHChon
    {
        [Key]
        public int MaChiTiet { get; set; }

        public int? MaGoiDichVuKHChon { get; set; }

        public int? MaDichVu { get; set; }

        public virtual DichVu DichVu { get; set; }

        public virtual GoiDichVuKHChon GoiDichVuKHChon { get; set; }
    }
}
