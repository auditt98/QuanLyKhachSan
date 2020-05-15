namespace QuanLyKhachSan
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
            LUUTRUs = new HashSet<LUUTRU>();
        }

        [Key]
        [StringLength(10)]
        public string idnguoidung { get; set; }

        [StringLength(50)]
        public string tendangnhap { get; set; }

        [StringLength(10)]
        public string matkhau { get; set; }

        [StringLength(100)]
        public string tennguoidung { get; set; }

        public int? sodienthoai { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaysinh { get; set; }

        public string diachi { get; set; }

        public bool? gioitinh { get; set; }

        public string avatar { get; set; }

        public int? malaymatkhau { get; set; }

        [StringLength(10)]
        public string idnhomnguoidung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LUUTRU> LUUTRUs { get; set; }

        public virtual NHOMNGUOIDUNG NHOMNGUOIDUNG { get; set; }
    }
}
