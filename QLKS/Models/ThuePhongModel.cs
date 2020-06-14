using FluentValidation.Attributes;
using QLKS.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public string tenkhachhang { get; set; }

        public string socmt { get; set; }

        public string sdt { get; set; }

        public List<ChiTietThuePhongModel> ChiTietThuePhong { get; set; }

        public List<SuDungDichVuModel> ChiTietDichVu { get; set; }
    }
}