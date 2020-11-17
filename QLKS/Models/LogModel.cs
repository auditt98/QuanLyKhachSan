using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Models
{
    public class LogModel
    {
        public int ID { get; set; }

        public DateTime ThoiGianChinhSua { get; set; }

        public int? NGUOIDUNG_ID { get; set; }

        public string LoaiHanhDong { get; set; }

        public string IPChinhSua { get; set; }

        public string DoiTuongChinhSua { get; set; }

        public string GhiChu { get; set; }
    }
}