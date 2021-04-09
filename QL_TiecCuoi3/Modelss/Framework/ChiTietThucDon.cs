namespace Modelss.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietThucDon")]
    public partial class ChiTietThucDon
    {
        [Key]
        public int MaChiTietThucDon { get; set; }

        public int? MaMonAn { get; set; }

        public int? MaThucDon { get; set; }

        public virtual Mon_An Mon_An { get; set; }

        public virtual ThucDon ThucDon { get; set; }
    }
}
