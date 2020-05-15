namespace QuanLyKhachSan
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETDATPHONG")]
    public partial class CHITIETDATPHONG
    {
        [Key]
        [StringLength(10)]
        public string idphong { get; set; }

        [Required]
        [StringLength(10)]
        public string iddat { get; set; }

        [StringLength(100)]
        public string tenkhachhang { get; set; }

        public int? socmt { get; set; }

        public int? sodienthoai { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaydukienden { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaydukiendi { get; set; }

        public virtual DATPHONG DATPHONG { get; set; }

        public virtual PHONG PHONG { get; set; }
    }
}
