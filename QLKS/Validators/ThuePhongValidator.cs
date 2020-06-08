using FluentValidation;
using QLKS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QLKS.Validators
{
    public class ThuePhongValidator: AbstractValidator<ThuePhongModel>
    {
        public ThuePhongValidator()
        {
            RuleFor(c => c.tenkhachhang).NotEmpty().WithMessage("Tên khách hàng không được để trống");
            RuleFor(c => c.socmt).NotEmpty().WithMessage("Số CMT không được để trống");
            RuleFor(c => c.sdt).NotEmpty().WithMessage("Số điện thoại không được để trống");

        }
    }
}