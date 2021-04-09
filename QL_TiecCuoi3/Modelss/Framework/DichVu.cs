namespace Modelss.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DichVu")]
    public partial class DichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DichVu()
        {
            ChiTietGoiDichVus = new HashSet<ChiTietGoiDichVu>();
            ChiTietGoiDichVuKHChons = new HashSet<ChiTietGoiDichVuKHChon>();
        }

        [Key]
        public int MaDichVu { get; set; }

        public int? LoaiDichVu { get; set; }

        [StringLength(100)]
        public string TenDichVu { get; set; }

        [StringLength(100)]
        public string GiaTien { get; set; }

        [StringLength(100)]
        public string GhiChu { get; set; }

        [StringLength(100)]
        public string TrangThai { get; set; }

        [StringLength(100)]
        public string MoTa { get; set; }

        [StringLength(100)]
        public string Anh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGoiDichVu> ChiTietGoiDichVus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietGoiDichVuKHChon> ChiTietGoiDichVuKHChons { get; set; }

        public virtual LoaiDichVu LoaiDichVu1 { get; set; }
    }
}
