namespace QuanLyKhachSan
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
                .Property(e => e.idphong)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<CHITIETDATPHONG>()
                .Property(e => e.iddat)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<CHITIETTHUEPHONG>()
                .Property(e => e.idphong)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<CHITIETTHUEPHONG>()
                .Property(e => e.idthue)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<CHITIETTHUEPHONG>()
                .Property(e => e.maktra)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<CHITIETTHUEPHONG>()
                .Property(e => e.idnguoidung)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<CHITIETTHUEPHONG>()
                .HasOptional(e => e.THUEPHONG)
                .WithRequired(e => e.CHITIETTHUEPHONG);

            modelBuilder.Entity<DATPHONG>()
                .Property(e => e.iddat)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<DATPHONG>()
                .Property(e => e.idkhachhang)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<DATPHONG>()
                .HasMany(e => e.CHITIETDATPHONGs)
                .WithRequired(e => e.DATPHONG)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<DICHVU>()
                .Property(e => e.iddichvu)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<DICHVU>()
                .HasOptional(e => e.SUDUNGDICHVU)
                .WithRequired(e => e.DICHVU);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.idkhachhang)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<LOAIPHONG>()
                .Property(e => e.idloaiphong)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<LOAITINHTRANG>()
                .Property(e => e.idloaitinhtrang)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<LUUTRU>()
                .Property(e => e.idluutru)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<LUUTRU>()
                .Property(e => e.idnguoidung)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.idnguoidung)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.matkhau)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.idnhomnguoidung)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<NHOMNGUOIDUNG>()
                .Property(e => e.idnhomnguoidung)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<PHONG>()
                .Property(e => e.idphong)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<PHONG>()
                .Property(e => e.idloaitinhtrang)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<PHONG>()
                .Property(e => e.idloaiphong)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<PHONG>()
                .HasOptional(e => e.CHITIETDATPHONG)
                .WithRequired(e => e.PHONG);

            modelBuilder.Entity<PHONG>()
                .HasMany(e => e.CHITIETTHUEPHONGs)
                .WithRequired(e => e.PHONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QUYEN>()
                .Property(e => e.idquyen)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<SUDUNGDICHVU>()
                .Property(e => e.idthue)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<SUDUNGDICHVU>()
                .Property(e => e.iddichvu)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<SUDUNGDICHVU>()
                .Property(e => e.idnguoidung)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<THANHTOAN>()
                .Property(e => e.idhoadon)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<THANHTOAN>()
                .Property(e => e.maktra)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<THANHTOAN>()
                .Property(e => e.idnguoidung)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<THANHTOAN>()
                .Property(e => e.idthue)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<THUEPHONG>()
                .Property(e => e.idthue)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<THUEPHONG>()
                .Property(e => e.idnguoidung)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<THUEPHONG>()
                .Property(e => e.idkhachhang)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<THUEPHONG>()
                .HasMany(e => e.SUDUNGDICHVUs)
                .WithRequired(e => e.THUEPHONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VATTU>()
                .Property(e => e.idvattu)
                .IsFixedLength()
                .IsUnicode(true);

            modelBuilder.Entity<VATTU>()
                .Property(e => e.idphong)
                .IsFixedLength()
                .IsUnicode(true);
        }
    }
}
