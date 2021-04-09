namespace Modelss.Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLTCdbContext : DbContext
    {
        public QLTCdbContext()
            : base("name=QLTCdbContext")
        {
        }

        public virtual DbSet<ChiTietAnhSanhTiec> ChiTietAnhSanhTiecs { get; set; }
        public virtual DbSet<ChiTietDatTiec> ChiTietDatTiecs { get; set; }
        public virtual DbSet<ChiTietGoiDichVu> ChiTietGoiDichVus { get; set; }
        public virtual DbSet<ChiTietGoiDichVuKHChon> ChiTietGoiDichVuKHChons { get; set; }
        public virtual DbSet<ChiTietThongTinSanh> ChiTietThongTinSanhs { get; set; }
        public virtual DbSet<ChiTietThucDon> ChiTietThucDons { get; set; }
        public virtual DbSet<ChiTietThucDonKHChon> ChiTietThucDonKHChons { get; set; }
        public virtual DbSet<DatTiec> DatTiecs { get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<GoiDichVu> GoiDichVus { get; set; }
        public virtual DbSet<GoiDichVuKHChon> GoiDichVuKHChons { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LapBaoCao> LapBaoCaos { get; set; }
        public virtual DbSet<LoaiDichVu> LoaiDichVus { get; set; }
        public virtual DbSet<LoaiMonAn> LoaiMonAns { get; set; }
        public virtual DbSet<Mon_An> Mon_An { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ThongTinSanh> ThongTinSanhs { get; set; }
        public virtual DbSet<ThucDon> ThucDons { get; set; }
        public virtual DbSet<ThucDonKHChon> ThucDonKHChons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietAnhSanhTiec>()
                .Property(e => e.AnhChiTiet)
                .IsFixedLength();

            modelBuilder.Entity<DatTiec>()
                .HasMany(e => e.ChiTietDatTiecs)
                .WithOptional(e => e.DatTiec)
                .HasForeignKey(e => e.MaDatTiec);

            modelBuilder.Entity<DatTiec>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.DatTiec)
                .HasForeignKey(e => e.MaDatTiec)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiDichVu>()
                .HasMany(e => e.DichVus)
                .WithOptional(e => e.LoaiDichVu1)
                .HasForeignKey(e => e.LoaiDichVu);

            modelBuilder.Entity<LoaiMonAn>()
                .HasMany(e => e.Mon_An)
                .WithOptional(e => e.LoaiMonAn1)
                .HasForeignKey(e => e.LoaiMonAn);

            modelBuilder.Entity<ThongTinSanh>()
                .HasMany(e => e.ChiTietAnhSanhTiecs)
                .WithOptional(e => e.ThongTinSanh)
                .HasForeignKey(e => e.MaSanhTiec);

            modelBuilder.Entity<ThucDonKHChon>()
                .Property(e => e.TenThucDon)
                .IsFixedLength();
        }
    }
}
