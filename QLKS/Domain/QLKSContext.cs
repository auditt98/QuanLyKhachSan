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

        public virtual DbSet<CHITIETDATPHONG> CHITIETDATPHONGs { get; set; }
        public virtual DbSet<CHITIETTHUEPHONG> CHITIETTHUEPHONGs { get; set; }
        public virtual DbSet<DATPHONG> DATPHONGs { get; set; }
        public virtual DbSet<DICHVU> DICHVUs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<LOAIPHONG> LOAIPHONGs { get; set; }
        public virtual DbSet<LOAITINHTRANG> LOAITINHTRANGs { get; set; }
        public virtual DbSet<LUUTRU> LUUTRUs { get; set; }
        public virtual DbSet<NGUOIDUNG> NGUOIDUNGs { get; set; }
        public virtual DbSet<NHOMNGUOIDUNG> NHOMNGUOIDUNGs { get; set; }
        public virtual DbSet<PHONG> PHONGs { get; set; }
        public virtual DbSet<QUYEN> QUYENs { get; set; }
        public virtual DbSet<SUDUNGDICHVU> SUDUNGDICHVUs { get; set; }
        public virtual DbSet<THANHTOAN> THANHTOANs { get; set; }
        public virtual DbSet<THUEPHONG> THUEPHONGs { get; set; }
        public virtual DbSet<VATTU> VATTUs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHITIETDATPHONG>()
                .Property(e => e.socmt)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETDATPHONG>()
                .Property(e => e.sodienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETDATPHONG>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETTHUEPHONG>()
                .Property(e => e.maktra)
                .IsUnicode(false);

            modelBuilder.Entity<DATPHONG>()
                .Property(e => e.ma)
                .IsUnicode(false);

            modelBuilder.Entity<DATPHONG>()
                .HasMany(e => e.CHITIETDATPHONGs)
                .WithRequired(e => e.DATPHONG)
                .HasForeignKey(e => e.DATPHONG_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DICHVU>()
                .Property(e => e.ma)
                .IsUnicode(false);

            modelBuilder.Entity<DICHVU>()
                .HasMany(e => e.SUDUNGDICHVUs)
                .WithRequired(e => e.DICHVU)
                .HasForeignKey(e => e.DICHVU_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.ma)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.socmt)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.sodienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.DATPHONGs)
                .WithOptional(e => e.KHACHHANG)
                .HasForeignKey(e => e.KHACHHANG_ID);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.THUEPHONGs)
                .WithOptional(e => e.KHACHHANG)
                .HasForeignKey(e => e.KHACHHANG_ID);

            modelBuilder.Entity<LOAIPHONG>()
                .Property(e => e.ma)
                .IsUnicode(false);

            modelBuilder.Entity<LOAIPHONG>()
                .Property(e => e.anh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LOAIPHONG>()
                .HasMany(e => e.PHONGs)
                .WithOptional(e => e.LOAIPHONG)
                .HasForeignKey(e => e.LOAIPHONG_ID);

            modelBuilder.Entity<LOAITINHTRANG>()
                .Property(e => e.ma)
                .IsUnicode(false);

            modelBuilder.Entity<LOAITINHTRANG>()
                .HasMany(e => e.PHONGs)
                .WithOptional(e => e.LOAITINHTRANG)
                .HasForeignKey(e => e.LOAITINHTRANG_ID);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.tendangnhap)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.hash)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.sodienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.malaymatkhau)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .HasMany(e => e.CHITIETTHUEPHONGs)
                .WithOptional(e => e.NGUOIDUNG)
                .HasForeignKey(e => e.NGUOIDUNG_ID);

            modelBuilder.Entity<NGUOIDUNG>()
                .HasMany(e => e.LUUTRUs)
                .WithOptional(e => e.NGUOIDUNG)
                .HasForeignKey(e => e.NGUOIDUNG_ID);

            modelBuilder.Entity<NGUOIDUNG>()
                .HasMany(e => e.QUYENs)
                .WithOptional(e => e.NGUOIDUNG)
                .HasForeignKey(e => e.nguoitao);

            modelBuilder.Entity<NGUOIDUNG>()
                .HasMany(e => e.QUYENs1)
                .WithOptional(e => e.NGUOIDUNG1)
                .HasForeignKey(e => e.nguoisua);

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
                .Property(e => e.ma)
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
                .Property(e => e.ma)
                .IsUnicode(false);

            modelBuilder.Entity<PHONG>()
                .HasMany(e => e.CHITIETDATPHONGs)
                .WithRequired(e => e.PHONG)
                .HasForeignKey(e => e.PHONG_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHONG>()
                .HasMany(e => e.CHITIETTHUEPHONGs)
                .WithRequired(e => e.PHONG)
                .HasForeignKey(e => e.PHONG_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHONG>()
                .HasMany(e => e.VATTUs)
                .WithOptional(e => e.PHONG)
                .HasForeignKey(e => e.PHONG_ID);

            modelBuilder.Entity<QUYEN>()
                .Property(e => e.ma)
                .IsUnicode(false);

            modelBuilder.Entity<QUYEN>()
                .Property(e => e.ipchinhsua)
                .IsUnicode(false);

            modelBuilder.Entity<THANHTOAN>()
                .Property(e => e.maktra)
                .IsUnicode(false);

            modelBuilder.Entity<THUEPHONG>()
                .Property(e => e.ma)
                .IsUnicode(false);

            modelBuilder.Entity<THUEPHONG>()
                .HasMany(e => e.CHITIETTHUEPHONGs)
                .WithRequired(e => e.THUEPHONG)
                .HasForeignKey(e => e.THUEPHONG_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THUEPHONG>()
                .HasMany(e => e.SUDUNGDICHVUs)
                .WithRequired(e => e.THUEPHONG)
                .HasForeignKey(e => e.THUEPHONG_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THUEPHONG>()
                .HasMany(e => e.THANHTOANs)
                .WithRequired(e => e.THUEPHONG)
                .HasForeignKey(e => e.THUEPHONG_ID)
                .WillCascadeOnDelete(false);
        }
    }
}
