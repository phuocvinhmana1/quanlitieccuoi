namespace Modelss.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GoiDichVu")]
    public partial class GoiDichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GoiDichVu()
        {
            ChiTietGoiDichVus = new HashSet<ChiTietGoiDichVu>();
        }

        [Key]
        public int MaGoiDichVu { get; set; }

        [StringLength(50)]
        public string TenGoiDichVu { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(50)]
        public string TongTien { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        [StringLength(50)]
        public string GhiChu { get; set; }

        [StringLength(50)]
        public string HinhAnh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGoiDichVu> ChiTietGoiDichVus { get; set; }
    }
}
