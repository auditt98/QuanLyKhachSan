using FluentValidation.Attributes;
using QLKS.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Models
{
    [Validator(typeof(LoaiTinhTrangValidator))]
    public class LoaiTinhTrangModel
    {
        public int ID { get; set; }

        public string ma { get; set; }

        public string ten { get; set; }
    }
}