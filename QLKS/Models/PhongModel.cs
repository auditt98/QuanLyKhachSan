using FluentValidation.Attributes;
using QLKS.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKS.Models
{
    [Validator(typeof(PhongValidator))]
    public class PhongModel
    {
        public int? ID { get; set; }

        public string ma { get; set; }

        public int? giathue { get; set; }

        public int? sotang { get; set; }

        public string ghichu { get; set; }

        public string tenloaiphong { get; set; }

        public int? LOAIPHONG_ID { get; set; }

        public int? LOAITINHTRANG_ID { get; set; }

        public IEnumerable<SelectListItem> DanhSachLoaiPhong { get; set; }
    }
}