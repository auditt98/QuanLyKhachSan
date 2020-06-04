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
        public NGUOIDUNG()
        {
            CHITIETTHUEPHONGs = new HashSet<CHITIETTHUEPHONG>();
            LUUTRUs = new HashSet<LUUTRU>();
            QUYENs = new HashSet<QUYEN>();
            QUYENs1 = new HashSet<QUYEN>();
            SUDUNGDICHVUs = new HashSet<SUDUNGDICHVU>();
            THANHTOANs = new HashSet<THANHTOAN>();
            THUEPHONGs = new HashSet<THUEPHONG>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string tendangnhap { get; set; }

        public string hash { get; set; }

        [StringLength(100)]
        public string tennguoidung { get; set; }

        [StringLength(20)]
        public string sodienthoai { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaysinh { get; set; }

        public string diachi { get; set; }

        public bool? gioitinh { get; set; }

        public string avatar { get; set; }

        [StringLength(5)]
        public string malaymatkhau { get; set; }

        public int? NHOMNGUOIDUNG_ID { get; set; }

        public virtual ICollection<CHITIETTHUEPHONG> CHITIETTHUEPHONGs { get; set; }

        public virtual ICollection<LUUTRU> LUUTRUs { get; set; }

        public virtual NHOMNGUOIDUNG NHOMNGUOIDUNG { get; set; }

        public virtual ICollection<QUYEN> QUYENs { get; set; }

        public virtual ICollection<QUYEN> QUYENs1 { get; set; }

        public virtual ICollection<SUDUNGDICHVU> SUDUNGDICHVUs { get; set; }

        public virtual ICollection<THANHTOAN> THANHTOANs { get; set; }

        public virtual ICollection<THUEPHONG> THUEPHONGs { get; set; }
    }
}
