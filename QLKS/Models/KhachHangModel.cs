using FluentValidation.Attributes;
using QLKS.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Models
{
    [Validator(typeof(KhachHangValidator))]
    public partial class KhachHangModel
    {
        public int? ID { get; set; }

        public string Ma { get; set; }

        public string Ten { get; set; }

        public bool GioiTinh { get; set; }

        public string SoCMT { get; set; }

        public string SoDienThoai { get; set; }

        public string Email { get; set; }

    }

    public class KhachHangSearchModel
    {
        public string Key { get; set; }
    }

}