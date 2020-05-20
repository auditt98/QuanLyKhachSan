namespace QLKS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THANHTOAN")]
    public partial class THANHTOAN
    {
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaytra { get; set; }

        public int? tienphong { get; set; }

        [StringLength(20)]
        public string maktra { get; set; }

        public int? NGUOIDUNG_ID { get; set; }

        public int THUEPHONG_ID { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }

        public virtual THUEPHONG THUEPHONG { get; set; }
    }
}
