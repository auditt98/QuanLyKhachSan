namespace QLKS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SUDUNGDICHVU")]
    public partial class SUDUNGDICHVU
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int THUEPHONG_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DICHVU_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaysudung { get; set; }

        public int? soluong { get; set; }

        public int? thanhtien { get; set; }

        public int? NGUOIDUNG_ID { get; set; }

        public virtual DICHVU DICHVU { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }

        public virtual THUEPHONG THUEPHONG { get; set; }
    }
}
