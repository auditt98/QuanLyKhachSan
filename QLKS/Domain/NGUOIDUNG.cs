namespace QLKS.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NGUOIDUNG")]
    public partial class NGUOIDUNG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NGUOIDUNG()
        {
            DATPHONGs = new HashSet<DATPHONG>();
            LOGs = new HashSet<LOG>();
            SUDUNGDICHVUs = new HashSet<SUDUNGDICHVU>();
            THANHTOANs = new HashSet<THANHTOAN>();
            THUEPHONGs = new HashSet<THUEPHONG>();
        }

        public int ID { get; set; }

        //[Required]
        //[StringLength(50)]
        public string TenDangNhap { get; set; }

        public string Hash { get; set; }

        //[Required]
        //[StringLength(40)]
        public string TenNguoiDung { get; set; }

        //[StringLength(15)]
        public string SoDienThoai { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        //[StringLength(200)]
        public string DiaChi { get; set; }

        public bool? GioiTinh { get; set; }

        public int? NHOMNGUOIDUNG_ID { get; set; }

        //[Required]
        //[StringLength(15)]
        public string SoCMT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DATPHONG> DATPHONGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOG> LOGs { get; set; }

        public virtual NHOMNGUOIDUNG NHOMNGUOIDUNG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUDUNGDICHVU> SUDUNGDICHVUs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THANHTOAN> THANHTOANs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THUEPHONG> THUEPHONGs { get; set; }
    }
}
