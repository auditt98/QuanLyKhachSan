namespace QuanLyKhachSan
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SUDUNGDICHVU")]
    public partial class SUDUNGDICHVU
    {
        [Required]
        [StringLength(10)]
        public string idthue { get; set; }

        [Key]
        [StringLength(10)]
        public string iddichvu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaysudung { get; set; }

        public int? soluong { get; set; }

        public int? thanhtien { get; set; }

        [StringLength(10)]
        public string idnguoidung { get; set; }

        public virtual DICHVU DICHVU { get; set; }

        public virtual THUEPHONG THUEPHONG { get; set; }
    }
}
