namespace Modelss.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DatTiec")]
    public partial class DatTiec
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DatTiec()
        {
            ChiTietDatTiecs = new HashSet<ChiTietDatTiec>();
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        public int MaDacTiec { get; set; }

        public int? MaSanh { get; set; }

        [StringLength(100)]
        public string NgayToChuc { get; set; }

        public int? MaKhachHang { get; set; }

        [StringLength(100)]
        public string Buoi { get; set; }

        public int? MaThucDon { get; set; }

        public int? MaThucDonKHChon { get; set; }

        public int? MaGoiDichVu { get; set; }

        public int? MaGoiDichVuKHChon { get; set; }

        [StringLength(100)]
        public string TongTien { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDatTiec> ChiTietDatTiecs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
