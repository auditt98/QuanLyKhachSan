﻿using FluentValidation;
using QLKS.Models;
namespace QLKS.Validators
{
    public class LoaiTinhTrangValidator : AbstractValidator<LoaiTinhTrangModel>
    {
        public LoaiTinhTrangValidator()
        {
            RuleFor(c => c.Ma).NotEmpty().WithMessage("Mã không được để trống");
            RuleFor(c => c.Ten).NotEmpty().WithMessage("Tên không được để trống");
        }
    }
}