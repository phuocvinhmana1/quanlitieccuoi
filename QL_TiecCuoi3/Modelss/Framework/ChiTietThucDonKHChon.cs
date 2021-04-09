namespace Modelss.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietThucDonKHChon")]
    public partial class ChiTietThucDonKHChon
    {
        [Key]
        public int MaChiTietThucDonKhChon { get; set; }

        public int? MaThucDon { get; set; }

        public int? MaMonAn { get; set; }

        public virtual Mon_An Mon_An { get; set; }

        public virtual ThucDonKHChon ThucDonKHChon { get; set; }
    }
}
