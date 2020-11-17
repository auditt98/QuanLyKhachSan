using FluentValidation;
using QLKS.Models;

namespace QLKS.Validators
{
    public class DatPhongValidator : AbstractValidator<DatPhongModel>
    {
        public DatPhongValidator()
        {
            RuleFor(c => c.LOAIPHONG_ID).NotEmpty().WithMessage("Loại phòng không được trống");
            RuleFor(c => c.SoPhong).NotEmpty().WithMessage("Số lượng phòng không được để trống");
            RuleFor(c => c.tenkhachhang).NotEmpty().WithMessage("Tên khách hàng không được để trống");
            RuleFor(c => c.socmt).NotEmpty().WithMessage("Số CMT không được để trống");
            RuleFor(c => c.sodienthoai).NotEmpty().WithMessage("Số điện thoại không được để trống");
            RuleFor(c => c.sodienthoai).Matches("(03[2|3|4|5|6|7|8|9]|05[6|8|9]|07[0|6|7|8|9]|08[1|2|3|4|5|6|8|9]|09[0|1|2|3|4|6|7|8|9])+([0-9]{7})\\b").WithMessage("Số điện thoại phải phù hợp với số điện thoại di động Việt Nam");
            RuleFor(c => c.socmt).Length(9, 12).WithMessage("Số CMND/Căn cước phải từ 9-12 chữ số");
            RuleFor(c => c.email).EmailAddress().WithMessage("Sai định dạng địa chỉ email");
            RuleFor(c => c.ngaydukienden).NotEmpty().WithMessage("Ngày dự kiến đến không được trống");
            RuleFor(c => c.ngaydukiendi).NotEmpty().WithMessage("Ngày dự kiến đi không được trống");
            RuleFor(c => c.ngaydukienden).LessThan(c => c.ngaydukiendi).WithMessage("Ngày dự kiến đến phải trước ngày dự kiến đi");
            RuleFor(c => c.ngaydukiendi).GreaterThan(c => c.ngaydukienden).WithMessage("Ngày dự kiến đi phải sau ngày dự kiến đến");
        }
    }
}