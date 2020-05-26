﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using QLKS.Models;

namespace QLKS.Validators
{
    public class KhachHangValidator: AbstractValidator<KhachHangModel>
    {
        public KhachHangValidator()
        {
            RuleFor(c => c.tenkhachhang).NotEmpty().WithMessage("Tên khách hàng không được để trống");
            RuleFor(c => c.sodienthoai).NotEmpty().WithMessage("Số điện thoại không được để trống");
            RuleFor(c => c.socmt).NotEmpty().WithMessage("Số CMT không được để trống");
            RuleFor(c => c.ma).NotEmpty().WithMessage("Mã khách hàng không được để trống");
        }
    }
}