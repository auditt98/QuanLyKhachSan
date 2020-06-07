using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKS.Models
{
    public class ChiTietThuePhongModel
    {
        public int? THUEPHONG_ID { get; set; }

        public DateTime? ngayvao { get; set; }

        public DateTime? ngayra { get; set; }

        public string maktra { get; set; }

        public int? NGUOIDUNG_ID { get; set; }

        public IEnumerable<SelectListItem> DanhSachPhong { get; set; }

        public IEnumerable<SelectListItem> DanhSachLoaiPhong { get; set; }

        public int loaiphong_id { get; set; }

        public int phong_id { get; set; }

        public string guid { get; set; }

        public decimal gia { get; set; }

        public bool isFromDb { get; set; }
    }
}