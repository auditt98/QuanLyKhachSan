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
            RuleFor(c => c.NgayDen).NotEmpty().WithMessage("Ngày đến không được trống");
            RuleFor(c => c.NgayDi).NotEmpty().WithMessage("Ngày đi không được trống");
            RuleFor(c => c.NgayDen).LessThan(c => c.NgayDi).WithMessage("Ngày đến phải trước ngày đi");
            RuleFor(c => c.NgayDi).GreaterThan(c => c.NgayDen).WithMessage("Ngày đi phải sau ngày đến");

        }
    }
}