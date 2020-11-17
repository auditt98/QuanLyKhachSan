using FluentValidation;
using QLKS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Validators
{
    public class PhongValidator: AbstractValidator<PhongModel>
    {
        public PhongValidator()
        {
            RuleFor(c => c.LOAIPHONG_ID).NotNull().WithMessage("Loại phòng không được để trống");
        }
    }
}