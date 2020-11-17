using FluentValidation.Attributes;
using QLKS.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Models
{
    [Validator(typeof(LoaiPhongValidator))]
    public class LoaiPhongModel
    {
        public int? ID { get; set; }

        public string Ten { get; set; }

        public string Ma { get; set; }

        public string AnhDaiDien { get; set; }

        public string ThongTin { get; set; }

        public int? GiaThue { get; set; }

        public int? SoNguoiLon { get; set; }

        public int? SoTreEm { get; set; }

        public int? SoGiuongDon { get; set; }

        public int? SoGiuongDoi { get; set; }

    }
}