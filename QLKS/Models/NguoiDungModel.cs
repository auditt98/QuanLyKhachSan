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

        public string tendangnhap { get; set; }

        public string hash { get; set; }

        public string tennguoidung { get; set; }

        public string sodienthoai { get; set; }

        public DateTime? ngaysinh { get; set; }

        public string diachi { get; set; }

        public bool? gioitinh { get; set; }

        public string avatar { get; set; }

        public string malaymatkhau { get; set; }

        public string matkhau { get; set; }

        public List<SelectListItem> DanhSachNhomNguoiDung { get; set; }

        public int selectedNhomNguoiDung { get; set; }

        public IEnumerable<NhomNguoiDungModel> nhomNguoiDung { get; set; }
    }
}
