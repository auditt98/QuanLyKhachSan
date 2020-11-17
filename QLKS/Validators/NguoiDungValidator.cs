using FluentValidation;
using Microsoft.Ajax.Utilities;
using QLKS.Domain;
using QLKS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Validators
{
    public class NguoiDungValidator: AbstractValidator<NguoiDungModel>
    {
        public NguoiDungValidator()
        {
            RuleFor(c => c.MatKhau).NotEmpty().WithMessage("Mật khẩu không được trống");
            RuleFor(c => c.MatKhau).MinimumLength(5).WithMessage("Mật khẩu không ngắn dưới 5 ký tự");
            //RuleFor(c => c.tendangnhap).Must(tendangnhap =>
            //{
            //    var db = new QLKSContext();
            //    var nguoidung = db.NGUOIDUNGs.Where(c => c.tendangnhap == tendangnhap).FirstOrDefault();
            //    if (nguoidung == null)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}).WithMessage("Người dùng này đã tồn tại");
            RuleFor(c => c.TenDangNhap).NotEmpty().WithMessage("Tên đăng nhập không được để trống");
            RuleFor(c => c.TenNguoiDung).NotEmpty().WithMessage("Tên người dùng không được để trống");
        }
    }
}