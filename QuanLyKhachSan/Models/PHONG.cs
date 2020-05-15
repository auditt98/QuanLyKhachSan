namespace QuanLyKhachSan
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHONG")]
    public partial class PHONG
    {
        public PHONG()
        {
            CHITIETTHUEPHONGs = new HashSet<CHITIETTHUEPHONG>();
            VATTUs = new HashSet<VATTU>();
        }
        [Key]
        [StringLength(10)]
        public string idphong { get; set; }

        [StringLength(50)]
        public string tenphong { get; set; }

        public int? giathue { get; set; }

        public int? sotang { get; set; }

        [StringLength(10)]
        public string idloaitinhtrang { get; set; }

        public string ghichu { get; set; }

        [StringLength(10)]
        public string idloaiphong { get; set; }

        public virtual CHITIETDATPHONG CHITIETDATPHONG { get; set; }

        public virtual ICollection<CHITIETTHUEPHONG> CHITIETTHUEPHONGs { get; set; }
        public virtual LOAIPHONG LOAIPHONG { get; set; }
        public virtual LOAITINHTRANG LOAITINHTRANG { get; set; }
        public virtual ICollection<VATTU> VATTUs { get; set; }
    }
}
