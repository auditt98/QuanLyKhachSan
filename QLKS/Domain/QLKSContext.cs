namespace QLKS.Domain
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLKSContext : DbContext
    {
        public QLKSContext()
            : base("name=QLKSContext")
        {
        }

        public virtual DbSet<CHITIETTHUEPHONG> CHITIETTHUEPHONGs { get; set; }
        public virtual DbSet<CHUONGTRINHGIAMGIA> CHUONGTRINHGIAMGIAs { get; set; }
        public virtual DbSet<DATPHONG> DATPHONGs { get; set; }
        public virtual DbSet<DICHVU> DICHVUs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<LOAIPHONG> LOAIPHONGs { get; set; }
        public virtual DbSet<LOAITINHTRANG> LOAITINHTRANGs { get; set; }
        public virtual DbSet<LOG> LOGs { get; set; }
        public virtual DbSet<NGUOIDUNG> NGUOIDUNGs { get; set; }
        public virtual DbSet<NHOMNGUOIDUNG> NHOMNGUOIDUNGs { get; set; }
        public virtual DbSet<PHONG> PHONGs { get; set; }
        public virtual DbSet<QUYEN> QUYENs { get; set; }
        public virtual DbSet<SUDUNGDICHVU> SUDUNGDICHVUs { get; set; }
        public virtual DbSet<THANHTOAN> THANHTOANs { get; set; }
        public virtual DbSet<THUEPHONG> THUEPHONGs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHITIETTHUEPHONG>()
                .HasMany(e => e.SUDUNGDICHVUs)
                .WithRequired(e => e.CHITIETTHUEPHONG)
                .HasForeignKey(e => e.CHITIETTHUEPHONG_ID);

            modelBuilder.Entity<CHUONGTRINHGIAMGIA>()
                .Property(e => e.Ma)
                .IsUnicode(false);

            modelBuilder.Entity<CHUONGTRINHGIAMGIA>()
                .HasMany(e => e.LOAIPHONGs)
                .WithMany(e => e.CHUONGTRINHGIAMGIAs)
                .Map(m => m.ToTable("APDUNGGIAMGIA"));

            modelBuilder.Entity<DATPHONG>()
                .Property(e => e.MaDatPhong)
                .IsUnicode(false);

            modelBuilder.Entity<DICHVU>()
                .Property(e => e.Ma)
                .IsUnicode(false);

            modelBuilder.Entity<DICHVU>()
                .HasMany(e => e.SUDUNGDICHVUs)
                .WithRequired(e => e.DICHVU)
                .HasForeignKey(e => e.DICHVU_ID);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.Ma)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.SoCMT)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.DATPHONGs)
                .WithOptional(e => e.KHACHHANG)
                .HasForeignKey(e => e.KHACHHANG_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.THUEPHONGs)
                .WithRequired(e => e.KHACHHANG)
                .HasForeignKey(e => e.KHACHHANG_ID);

            modelBuilder.Entity<LOAIPHONG>()
                .Property(e => e.Ma)
                .IsUnicode(false);

            modelBuilder.Entity<LOAIPHONG>()
                .Property(e => e.AnhDaiDien)
                .IsUnicode(false);

            modelBuilder.Entity<LOAIPHONG>()
                .HasMany(e => e.DATPHONGs)
                .WithOptional(e => e.LOAIPHONG)
                .HasForeignKey(e => e.LOAIPHONG_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<LOAIPHONG>()
                .HasMany(e => e.PHONGs)
                .WithRequired(e => e.LOAIPHONG)
                .HasForeignKey(e => e.LOAIPHONG_ID);

            modelBuilder.Entity<LOAITINHTRANG>()
                .Property(e => e.Ma)
                .IsUnicode(false);

            modelBuilder.Entity<LOAITINHTRANG>()
                .HasMany(e => e.DATPHONGs)
                .WithOptional(e => e.LOAITINHTRANG)
                .HasForeignKey(e => e.LOAITINHTRANG_ID);

            modelBuilder.Entity<LOAITINHTRANG>()
                .HasMany(e => e.PHONGs)
                .WithOptional(e => e.LOAITINHTRANG)
                .HasForeignKey(e => e.LOAITINHTRANG_ID);

            modelBuilder.Entity<LOAITINHTRANG>()
                .HasMany(e => e.THUEPHONGs)
                .WithOptional(e => e.LOAITINHTRANG)
                .HasForeignKey(e => e.LOAITINHTRANG_ID);

            modelBuilder.Entity<LOG>()
                .Property(e => e.IPChinhSua)
                .IsUnicode(false);

            modelBuilder.Entity<LOG>()
                .Property(e => e.DoiTuongChinhSua)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.Hash)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.SoCMT)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .HasMany(e => e.DATPHONGs)
                .WithOptional(e => e.NGUOIDUNG)
                .HasForeignKey(e => e.NGUOIDUNG_ID);

            modelBuilder.Entity<NGUOIDUNG>()
                .HasMany(e => e.LOGs)
                .WithOptional(e => e.NGUOIDUNG)
                .HasForeignKey(e => e.NGUOIDUNG_ID);

            modelBuilder.Entity<NGUOIDUNG>()
                .HasMany(e => e.SUDUNGDICHVUs)
                .WithOptional(e => e.NGUOIDUNG)
                .HasForeignKey(e => e.NGUOIDUNG_ID);

            modelBuilder.Entity<NGUOIDUNG>()
                .HasMany(e => e.THANHTOANs)
                .WithOptional(e => e.NGUOIDUNG)
                .HasForeignKey(e => e.NGUOIDUNG_ID);

            modelBuilder.Entity<NGUOIDUNG>()
                .HasMany(e => e.THUEPHONGs)
                .WithOptional(e => e.NGUOIDUNG)
                .HasForeignKey(e => e.NGUOIDUNG_ID);

            modelBuilder.Entity<NHOMNGUOIDUNG>()
                .Property(e => e.Ma)
                .IsUnicode(false);

            modelBuilder.Entity<NHOMNGUOIDUNG>()
                .HasMany(e => e.NGUOIDUNGs)
                .WithOptional(e => e.NHOMNGUOIDUNG)
                .HasForeignKey(e => e.NHOMNGUOIDUNG_ID);

            modelBuilder.Entity<NHOMNGUOIDUNG>()
                .HasMany(e => e.QUYENs)
                .WithMany(e => e.NHOMNGUOIDUNGs)
                .Map(m => m.ToTable("CHITIETPHANQUYEN"));

            modelBuilder.Entity<PHONG>()
                .Property(e => e.SoPhong)
                .IsUnicode(false);

            modelBuilder.Entity<PHONG>()
                .HasMany(e => e.CHITIETTHUEPHONGs)
                .WithRequired(e => e.PHONG)
                .HasForeignKey(e => e.PHONG_ID);

            modelBuilder.Entity<QUYEN>()
                .Property(e => e.Ma)
                .IsUnicode(false);

            modelBuilder.Entity<THANHTOAN>()
                .Property(e => e.Ma)
                .IsUnicode(false);

            modelBuilder.Entity<THANHTOAN>()
                .Property(e => e.PhuongThucTra)
                .IsUnicode(false);

            modelBuilder.Entity<THUEPHONG>()
                .Property(e => e.Ma)
                .IsUnicode(false);

            modelBuilder.Entity<THUEPHONG>()
                .HasMany(e => e.CHITIETTHUEPHONGs)
                .WithRequired(e => e.THUEPHONG)
                .HasForeignKey(e => e.THUEPHONG_ID);

            modelBuilder.Entity<THUEPHONG>()
                .HasMany(e => e.THANHTOANs)
                .WithRequired(e => e.THUEPHONG)
                .HasForeignKey(e => e.THUEPHONG_ID);
        }
    }
}
