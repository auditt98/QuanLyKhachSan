namespace QLKS.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOG")]
    public partial class LOG
    {
        public int ID { get; set; }

        public DateTime ThoiGianChinhSua { get; set; }

        public int? NGUOIDUNG_ID { get; set; }

        //[Required]
        //[StringLength(50)]
        public string LoaiHanhDong { get; set; }

        //[StringLength(20)]
        public string IPChinhSua { get; set; }

        //[StringLength(20)]
        public string DoiTuongChinhSua { get; set; }

        public string GhiChu { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }
    }
}
