namespace Modelss.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThucDonKHChon")]
    public partial class ThucDonKHChon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThucDonKHChon()
        {
            ChiTietThucDonKHChons = new HashSet<ChiTietThucDonKHChon>();
        }

        [Key]
        public int MaThucDon { get; set; }

        public int? MaKhachHang { get; set; }

        [StringLength(100)]
        public string TenThucDon { get; set; }

        [StringLength(100)]
        public string TongTien { get; set; }

        public int? SoLuongMon { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietThucDonKHChon> ChiTietThucDonKHChons { get; set; }
    }
}
