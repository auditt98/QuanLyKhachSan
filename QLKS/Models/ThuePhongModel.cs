using FluentValidation.Attributes;
using QLKS.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKS.Models
{
    [Validator(typeof(ThuePhongValidator))]
    public class ThuePhongModel
    {
        public ThuePhongModel()
        {
            ChiTietThuePhong = new List<ChiTietThuePhongModel>();
            ChiTietDichVu = new List<SuDungDichVuModel>();
        }

        public int ID { get; set; }

        public string ma { get; set; }

        public int? NGUOIDUNG_ID { get; set; }

        public int? KHACHHANG_ID { get; set; }

        public int? LOAIPHONG_ID { get; set; }

        public string tenkhachhang { get; set; }

        public string socmt { get; set; }

        public string sdt { get; set; }

        public DateTime? NgayDen { get; set; }

        public DateTime? NgayDi { get; set; }

        public int? LOAITINHTRANG_ID { get; set; }

        public DateTime? ThoiGianThue { get; set; }

        public List<ChiTietThuePhongModel> ChiTietThuePhong { get; set; }

        public List<SuDungDichVuModel> ChiTietDichVu { get; set; }

        public IEnumerable<SelectListItem> DanhSachLoaiPhong { get; set; }

        public string fromCheckIn { get; set; }

        public string fromEdit{ get; set; }

        public int? GiaThue { get; set; }

        public List<int> SelectedPhongs { get; set; }

    }
}