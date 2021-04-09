namespace Modelss.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThucDon")]
    public partial class ThucDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThucDon()
        {
            ChiTietThucDons = new HashSet<ChiTietThucDon>();
        }

        [Key]
        public int MaThucDon { get; set; }

        [StringLength(100)]
        public string TenThucDon { get; set; }

        public int? SoLuongMon { get; set; }

        [StringLength(100)]
        public string TongDonGia { get; set; }

        [StringLength(100)]
        public string TrangThai { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        [StringLength(100)]
        public string HinhAnh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietThucDon> ChiTietThucDons { get; set; }
    }
}
