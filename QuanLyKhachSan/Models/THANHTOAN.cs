namespace QuanLyKhachSan
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THANHTOAN")]
    public partial class THANHTOAN
    {
        [Key]
        [StringLength(10)]
        public string idhoadon { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaytra { get; set; }

        public int? tienphong { get; set; }

        [StringLength(10)]
        public string maktra { get; set; }

        [StringLength(10)]
        public string idnguoidung { get; set; }

        [StringLength(10)]
        public string idthue { get; set; }

        public virtual THUEPHONG THUEPHONG { get; set; }
    }
}
