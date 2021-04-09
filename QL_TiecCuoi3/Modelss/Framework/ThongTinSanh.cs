namespace Modelss.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinSanh")]
    public partial class ThongTinSanh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThongTinSanh()
        {
            ChiTietAnhSanhTiecs = new HashSet<ChiTietAnhSanhTiec>();
            ChiTietThongTinSanhs = new HashSet<ChiTietThongTinSanh>();
        }

        [Key]
        public int MaSanh { get; set; }

        [StringLength(100)]
        public string LoaiSanh { get; set; }

        [Required]
        [StringLength(100)]
        public string TenSanh { get; set; }

        public int SoLuongBan { get; set; }

        [Required]
        [StringLength(100)]
        public string DonGia { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        [StringLength(100)]
        public string TrangThai { get; set; }

        [StringLength(500)]
        public string MoTa { get; set; }

        [StringLength(100)]
        public string Hinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietAnhSanhTiec> ChiTietAnhSanhTiecs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietThongTinSanh> ChiTietThongTinSanhs { get; set; }
    }
}
