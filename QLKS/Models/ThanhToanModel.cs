using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Models
{
    public class ThanhToanModel
    {
        public int? ID { get; set; }

        public DateTime? NgayTra { get; set; }

        public string Ma { get; set; }

        public int? ThanhTien { get; set; }

        public string PhuongThucTra { get; set; }

        public int? NGUOIDUNG_ID { get; set; }

        public int THUEPHONG_ID { get; set; }
    }
}