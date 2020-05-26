using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Models
{
    public class ChiTietThuePhongModel
    {
        public int? THUEPHONG_ID { get; set; }

        public DateTime? ngayvao { get; set; }

        public DateTime? ngayra { get; set; }

        public string maktra { get; set; }

        public int? NGUOIDUNG_ID { get; set; }
    }
}