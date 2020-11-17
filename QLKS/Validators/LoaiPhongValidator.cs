using FluentValidation;
using QLKS.Models;

namespace QLKS.Validators
{
    public class LoaiPhongValidator : AbstractValidator<LoaiPhongModel>
    {

            public LoaiPhongValidator()
            {
                RuleFor(c => c.Ma).NotEmpty().WithMessage("Mã loại phòng không được để trống");
                RuleFor(c => c.Ten).NotEmpty().WithMessage("Tên loại phòng không được để trống");
                RuleFor(c => c.ThongTin).Must(c => c == null || c.Length <= 2000).WithMessage("Không vượt quá 2000 ký tự");
                RuleFor(c => c.SoNguoiLon).NotEmpty().WithMessage("Số người lớn không được để trống");
                RuleFor(c => c.SoTreEm).NotEmpty().WithMessage("Số trẻ em không được để trống");
                RuleFor(c => c.SoGiuongDoi).NotEmpty().WithMessage("Số giường đôi không được để trống");
                RuleFor(c => c.SoGiuongDon).NotEmpty().WithMessage("Số giường đơn không được để trống");

        }

    }
}