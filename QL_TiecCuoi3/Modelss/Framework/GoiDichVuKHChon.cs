namespace Modelss.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GoiDichVuKHChon")]
    public partial class GoiDichVuKHChon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GoiDichVuKHChon()
        {
            ChiTietGoiDichVuKHChons = new HashSet<ChiTietGoiDichVuKHChon>();
        }

        [Key]
        public int MaGoiDichVuKHChon { get; set; }

        public int? MaKhachHang { get; set; }

        [StringLength(100)]
        public string TenGoi { get; set; }

        [StringLength(50)]
        public string SoLuong { get; set; }

        [StringLength(50)]
        public string TongTien { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        [StringLength(50)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGoiDichVuKHChon> ChiTietGoiDichVuKHChons { get; set; }
    }
}
