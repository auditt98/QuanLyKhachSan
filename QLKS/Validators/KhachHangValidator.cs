using FluentValidation;
using QLKS.Models;

namespace QLKS.Validators
{
    public class KhachHangValidator: AbstractValidator<KhachHangModel>
    {
        public KhachHangValidator()
        {
            RuleFor(c => c.Ten).NotEmpty().WithMessage("Tên khách hàng không được để trống");
            RuleFor(c => c.SoDienThoai).NotEmpty().WithMessage("Số điện thoại không được để trống");
            RuleFor(c => c.SoCMT).NotEmpty().WithMessage("Số CMT không được để trống");
            RuleFor(c => c.Ma).NotEmpty().WithMessage("Mã khách hàng không được để trống");
            RuleFor(c => c.Email).EmailAddress().WithMessage("Định dạng email sai");
        }
    }
}