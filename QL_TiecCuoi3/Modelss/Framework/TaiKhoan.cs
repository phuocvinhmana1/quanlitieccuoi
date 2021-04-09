namespace Modelss.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        public int MaTaiKhoan { get; set; }

        [StringLength(100)]
        public string TenDangNhap { get; set; }

        [StringLength(100)]
        public string MatKhau { get; set; }

        [StringLength(100)]
        public string HoTen { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [StringLength(100)]
        public string SoDienThoai { get; set; }

        [StringLength(100)]
        public string TinhTrang { get; set; }
    }
}
