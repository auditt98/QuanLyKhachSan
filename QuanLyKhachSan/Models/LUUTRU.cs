namespace QuanLyKhachSan
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LUUTRU")]
    public partial class LUUTRU
    {
        [Key]
        [StringLength(10)]
        public string idluutru { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaychinhsua { get; set; }

        [StringLength(50)]
        public string nguoichinhsua { get; set; }

        public int? loaihanhdong { get; set; }

        public string ghichu { get; set; }

        [StringLength(10)]
        public string idnguoidung { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }
    }
}
