namespace Modelss.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            LapBaoCaos = new HashSet<LapBaoCao>();
        }

        [Key]
        public int MaNhanVien { get; set; }

        public int? MaTaiKhoan { get; set; }

        [Required]
        [StringLength(100)]
        public string TenNhanVien { get; set; }

        [Required]
        [StringLength(100)]
        public string SoDienThoai { get; set; }

        [Required]
        [StringLength(100)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(100)]
        public string ChucVu { get; set; }

        [StringLength(100)]
        public string TinhTrang { get; set; }

        [StringLength(100)]
        public string TenDangNhap { get; set; }

        [StringLength(100)]
        public string MatKhau { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LapBaoCao> LapBaoCaos { get; set; }
    }
}
