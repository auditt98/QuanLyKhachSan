using QLKS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKS.Models
{
    public class SuDungDichVuModel
    {
        public int THUEPHONG_ID { get; set; }

        public int DICHVU_ID { get; set; }

        public DateTime? ThoiGianSuDung { get; set; }

        public int? SoLuong { get; set; }

        public int? DonGia { get; set; }

        public int? ThanhTien { get; set; }

        public int? PHONG_ID { get; set; }

        public int? NGUOIDUNG_ID { get; set; }

        public IEnumerable<SelectListItem> DanhSachDichVu { get; set; }

        public IEnumerable<SelectListItem> DanhSachPhong { get; set; }

    }
}