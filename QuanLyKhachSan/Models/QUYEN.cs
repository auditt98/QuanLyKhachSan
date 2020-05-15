namespace QuanLyKhachSan
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUYEN")]
    public partial class QUYEN
    {
        [Key]
        [StringLength(10)]
        public string idquyen { get; set; }

        [StringLength(50)]
        public string tenquyen { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaytao { get; set; }

        [StringLength(50)]
        public string nguoitao { get; set; }

        public int? ipchinhsua { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaychinhsua { get; set; }

        [StringLength(50)]
        public string nguoisua { get; set; }

        public virtual NHOMNGUOIDUNG NHOMNGUOIDUNG { get; set; }
    }
}
