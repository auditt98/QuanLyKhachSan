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

        public string ma { get; set; }

        public string tenkhachhang { get; set; }

        public bool? gioitinh { get; set; }

        public string socmt { get; set; }

        public string sodienthoai { get; set; }

        public string email { get; set; }

    }

    public class KhachHangSearchModel
    {
        public string Key { get; set; }
    }

}