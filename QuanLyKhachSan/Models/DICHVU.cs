namespace QuanLyKhachSan
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DICHVU")]
    public partial class DICHVU
    {
        [Key]
        [StringLength(10)]
        public string iddichvu { get; set; }

        [StringLength(50)]
        public string tendichvu { get; set; }

        public int? dongia { get; set; }

        public virtual SUDUNGDICHVU SUDUNGDICHVU { get; set; }
    }
}
