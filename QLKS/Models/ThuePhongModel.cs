using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Models
{
    public class ThuePhongModel
    {
        public int ID { get; set; }

        public string ma { get; set; }

        public int? NGUOIDUNG_ID { get; set; }

        public int? KHACHHANG_ID { get; set; }

        public string tenkhachhang { get; set; }

        public string socmt { get; set; }

        public string sdt { get; set; }

        public List<ChiTietThuePhongModel> ChiTietThuePhong { get; set; }
    }
}