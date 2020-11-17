namespace QLKS.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DATPHONG")]
    public partial class DATPHONG
    {
        public int ID { get; set; }

        public int? KHACHHANG_ID { get; set; }

        public int? LOAIPHONG_ID { get; set; }

        public int? SoPhong { get; set; }

        //[StringLength(10)]
        public string MaDatPhong { get; set; }

        public DateTime NgayDuKienDi { get; set; }

        public DateTime NgayDuKienDen { get; set; }

        public int? LOAITINHTRANG_ID { get; set; }

        public int? NGUOIDUNG_ID { get; set; }

        public DateTime? ThoiGianDat { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual LOAIPHONG LOAIPHONG { get; set; }

        public virtual LOAITINHTRANG LOAITINHTRANG { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }
    }
}
