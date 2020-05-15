namespace QuanLyKhachSan
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETTHUEPHONG")]
    public partial class CHITIETTHUEPHONG
    {
        [Required]
        [StringLength(10)]
        public string idphong { get; set; }

        [Key]
        [StringLength(10)]
        public string idthue { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayvao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayra { get; set; }

        [StringLength(10)]
        public string maktra { get; set; }

        [StringLength(10)]
        public string idnguoidung { get; set; }

        public virtual PHONG PHONG { get; set; }

        public virtual THUEPHONG THUEPHONG { get; set; }
    }
}
