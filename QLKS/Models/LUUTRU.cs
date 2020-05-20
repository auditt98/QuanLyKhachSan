namespace QLKS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LUUTRU")]
    public partial class LUUTRU
    {
        public int ID { get; set; }

        public DateTime? ngaychinhsua { get; set; }

        public int? NGUOIDUNG_ID { get; set; }

        [StringLength(50)]
        public string loaihanhdong { get; set; }

        public string ghichu { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }
    }
}
