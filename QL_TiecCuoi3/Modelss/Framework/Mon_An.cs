namespace Modelss.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mon_An
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mon_An()
        {
            ChiTietThucDons = new HashSet<ChiTietThucDon>();
            ChiTietThucDonKHChons = new HashSet<ChiTietThucDonKHChon>();
        }

        [Key]
        public int MaMonAn { get; set; }

        [StringLength(100)]
        public string TenMonAn { get; set; }

        public int? LoaiMonAn { get; set; }

        [StringLength(100)]
        public string GiaTien { get; set; }

        [StringLength(100)]
        public string TrangThai { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        [StringLength(500)]
        public string MoTa { get; set; }

        [StringLength(100)]
        public string HinhAnh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietThucDon> ChiTietThucDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietThucDonKHChon> ChiTietThucDonKHChons { get; set; }

        public virtual LoaiMonAn LoaiMonAn1 { get; set; }
    }
}
