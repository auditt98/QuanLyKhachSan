namespace QuanLyKhachSan
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VATTU")]
    public partial class VATTU
    {
        [Key]
        [StringLength(10)]
        public string idvattu { get; set; }

        [StringLength(100)]
        public string tenvattu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaymua { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaysudung { get; set; }

        public int? soluong { get; set; }

        public string mota { get; set; }

        public int? sotien { get; set; }

        [StringLength(10)]
        public string idphong { get; set; }

        public virtual PHONG PHONG { get; set; }
    }
}
