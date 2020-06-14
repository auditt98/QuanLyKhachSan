using AutoMapper;
using QLKS.Domain;
using QLKS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCrypt.Net;
using Microsoft.Ajax.Utilities;
using QLKS.Services;
using static QLKS.Extensions.Enum;
using Newtonsoft.Json;

namespace QLKS.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        private QLKSContext db = new QLKSContext();
        private NguoiDungServices _nguoiDungServices = new NguoiDungServices();
        private LichSuServices _lichSuServices = new LichSuServices();
        private NhomNguoiDungServices _nhomNguoiDungServices = new NhomNguoiDungServices();
        private QuyenServices _quyenServices = new QuyenServices();
        public ActionResult List()
        {
            if (!_quyenServices.Authorize((int)EnumQuyen.NHOMNGUOIDUNG_XEM))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            if (!_nguoiDungServices.isLoggedIn())
            {
                TempData["Message"] = "Bạn chưa đăng nhập, vui lòng đăng nhập";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("Login", "NguoiDung");
            }
            return View();
        }

        [HttpPost]
        public ActionResult PopulateNguoiDung()
        {
            var danhSachNguoiDung = db.NGUOIDUNGs.Select(c => new
            {
                tendangnhap = c.tendangnhap,
                ten = c.tennguoidung,
                sdt = c.sodienthoai,
                uid = c.ID
            }).OrderBy(c => c.uid).ToList();
            var result = new { data = danhSachNguoiDung };
            return Json(result);
        }

        public ActionResult Create()
        {

            if (!_nguoiDungServices.isLoggedIn())
            {
                TempData["Message"] = "Bạn chưa đăng nhập, vui lòng đăng nhập";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("Login", "NguoiDung");
            }
            if (!_quyenServices.Authorize((int)EnumQuyen.NGUOIDUNG_THEM))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            var model = new NguoiDungModel();
            var allNhomNguoiDung = _nhomNguoiDungServices.PrepareSelectListNhomNguoiDung(0);
            model.DanhSachNhomNguoiDung = allNhomNguoiDung;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(NguoiDungModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Có lỗi xảy ra! Vui lòng kiểm tra lại thông tin.";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return View("Create", model);
            }
            if (!_quyenServices.Authorize((int)EnumQuyen.NGUOIDUNG_THEM))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            var item = new NGUOIDUNG();
            item.tendangnhap = model.tendangnhap;
            item.tennguoidung = model.tennguoidung;
            item.sodienthoai = model.sodienthoai;
            item.gioitinh = model.gioitinh;
            item.diachi = model.diachi;
            item.ngaysinh = model.ngaysinh;
            item.hash = BCrypt.Net.BCrypt.HashPassword(model.matkhau);
            item.NHOMNGUOIDUNG_ID = model.selectedNhomNguoiDung;
            db.NGUOIDUNGs.Add(item);
            db.SaveChanges();
            _lichSuServices.LuuLichSu((int)Session["ID"], (int)EnumLoaiHanhDong.THEM, item.GetType().ToString());
            TempData["Message"] = "Thêm mới thành công";
            TempData["NotiType"] = "success";
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (!_nguoiDungServices.isLoggedIn())
            {
                TempData["Message"] = "Bạn chưa đăng nhập, vui lòng đăng nhập";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("Login", "NguoiDung");
            }
            if (!_quyenServices.Authorize((int)EnumQuyen.NGUOIDUNG_SUA))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            if (id == null)
            {
                return RedirectToAction("List");
            }
            var item = db.NGUOIDUNGs.Find(id);
            if (item == null)
            {
                TempData["Message"] = "Không tìm thấy người dùng này";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("List");
            }
            //prepare model
            var model = new NguoiDungModel();
            model.tendangnhap = item.tendangnhap;
            model.tennguoidung = item.tennguoidung;
            model.sodienthoai = item.sodienthoai;
            model.gioitinh = item.gioitinh;
            model.diachi = item.diachi;
            model.ngaysinh = item.ngaysinh;
            var allNhomNguoiDung = _nhomNguoiDungServices.PrepareSelectListNhomNguoiDung(item.NHOMNGUOIDUNG_ID.Value);
            model.DanhSachNhomNguoiDung = allNhomNguoiDung;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(NguoiDungModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Có lỗi xảy ra! Vui lòng kiểm tra lại thông tin.";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return View("Edit", model);
            }
            if (!_quyenServices.Authorize((int)EnumQuyen.NGUOIDUNG_SUA))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            var item = db.NGUOIDUNGs.Where(c => c.ID == model.ID).FirstOrDefault();
            if (item == null)
            {
                TempData["Message"] = "Có lỗi xảy ra";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("List");
            }
            //map from model to database object
            item.tendangnhap = model.tendangnhap;
            item.tennguoidung = model.tennguoidung;
            item.sodienthoai = model.sodienthoai;
            item.ngaysinh = model.ngaysinh;
            item.gioitinh = model.gioitinh;
            item.diachi = model.diachi;
            item.NHOMNGUOIDUNG_ID = model.selectedNhomNguoiDung;
            item.hash = BCrypt.Net.BCrypt.HashPassword(model.matkhau);
            db.SaveChanges();
            _lichSuServices.LuuLichSu((int)Session["ID"], (int)EnumLoaiHanhDong.SUA, item.GetType().ToString());
            TempData["Message"] = "Cập nhật thành công";
            TempData["NotiType"] = "success"; //success là class trong bootstrap
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (!_quyenServices.Authorize((int)EnumQuyen.NGUOIDUNG_XOA))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            var nguoidung = db.NGUOIDUNGs.Find(id);
            db.NGUOIDUNGs.Remove(nguoidung);
            db.SaveChanges();
            //Thông báo
            TempData["Message"] = "Xóa thành công";
            TempData["NotiType"] = "success"; //success là class trong bootstrap
            return Json("ok");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(NguoiDungModel model)
        {
            var item = db.NGUOIDUNGs.Where(c => c.tendangnhap == model.tendangnhap).FirstOrDefault();
            if (item == null)
            {
                TempData["Message"] = "Sai mật khẩu hoặc tên đăng nhập, vui lòng thử lại";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return View(model);
            }
            else
            {
                var dungMatKhau = BCrypt.Net.BCrypt.Verify(model.matkhau, item.hash);
                if (dungMatKhau)
                {
                    Session["ID"] = item.ID;
                    Session["tendangnhap"] = item.tendangnhap;
                    Session["tennguoidung"] = item.tennguoidung;
                    _lichSuServices.LuuLichSu((int)Session["ID"], (int)EnumLoaiHanhDong.DANGNHAP, item.GetType().ToString());
                    Session["NguoiDung"] = item;
                    TempData["Message"] = "Đăng nhập thành công";
                    TempData["NotiType"] = "success"; //success là class trong bootstrap
                    return RedirectToAction("Index", "QLKS");
                }
                else
                {
                    TempData["Message"] = "Sai mật khẩu hoặc tên đăng nhập, vui lòng thử lại";
                    TempData["NotiType"] = "danger"; //success là class trong bootstrap
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            if (!_nguoiDungServices.isLoggedIn())
            {
                TempData["Message"] = "Bạn chưa đăng nhập, vui lòng đăng nhập";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("Login", "NguoiDung");
            }
            else
            {
                var nguoidungid = (int)Session["ID"];
                Session["ID"] = null;
                Session["tendangnhap"] = null;
                Session["tennguoidung"] = null;
                Session.Abandon();
                _lichSuServices.LuuLichSu(nguoidungid, (int)EnumLoaiHanhDong.DANGXUAT);
                TempData["Message"] = "Đăng xuất thành công";
                TempData["NotiType"] = "success"; //success là class trong bootstrap
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public ActionResult CheckQuyen()
        {
            if (!_quyenServices.Authorize((int)EnumQuyen.NGUOIDUNG_XEM))
            {
                return Json("no");
            }
            return Json("yes");
        }

    }
}