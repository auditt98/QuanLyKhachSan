﻿using FluentValidation;
using QLKS.Models;

namespace QLKS.Validators
{
    public class LoaiPhongValidator : AbstractValidator<LoaiPhongModel>
    {

            public LoaiPhongValidator()
            {
                RuleFor(c => c.ma).NotEmpty().WithMessage("Mã loại phòng không được để trống");
                RuleFor(c => c.tenloaiphong).NotEmpty().WithMessage("Tên loại phòng không được để trống");
                RuleFor(c => c.thongtin).Must(c => c == null || c.Length <= 500).WithMessage("Không vượt quá 500 ký tự");
            }

    }
}