namespace Modelss.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietGoiDichVu")]
    public partial class ChiTietGoiDichVu
    {
        [Key]
        public int MaChiTietGoiDV { get; set; }

        public int? MaGoiDichVu { get; set; }

        public int? MaDichVu { get; set; }

        public virtual DichVu DichVu { get; set; }

        public virtual GoiDichVu GoiDichVu { get; set; }
    }
}
