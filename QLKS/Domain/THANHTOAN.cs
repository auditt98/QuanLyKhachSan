namespace QLKS.Domain
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

        public DateTime? NgayThanhToan { get; set; }

        //[StringLength(10)]
        public string Ma { get; set; }

        public int? ThanhTien { get; set; }

        //[StringLength(20)]
        public string PhuongThucTra { get; set; }

        public int? NGUOIDUNG_ID { get; set; }

        public int THUEPHONG_ID { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }

        public virtual THUEPHONG THUEPHONG { get; set; }
    }
}
