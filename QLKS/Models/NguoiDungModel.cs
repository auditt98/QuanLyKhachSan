using Antlr.Runtime.Tree;
using FluentValidation.Attributes;
using QLKS.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKS.Models
{
    [Validator(typeof(NguoiDungValidator))]
    public partial class NguoiDungModel
    {
        public NguoiDungModel()
        {
            nhomNguoiDung = new List<NhomNguoiDungModel>();
        }
        public int? ID { get; set; }

        public string TenDangNhap { get; set; }

        public string Hash { get; set; }

        public string TenNguoiDung { get; set; }

        public string SoDienThoai { get; set; }

        public DateTime? NgaySinh { get; set; }

        public string DiaChi { get; set; }

        public bool? GioiTinh { get; set; }

        public string MatKhau { get; set; }

        public string SoCMT { get; set; }

        public List<SelectListItem> DanhSachNhomNguoiDung { get; set; }

        public int selectedNhomNguoiDung { get; set; }

        public IEnumerable<NhomNguoiDungModel> nhomNguoiDung { get; set; }
    }
}
