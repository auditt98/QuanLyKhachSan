﻿using AutoMapper;
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

namespace QLKS.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        private QLKSContext db = new QLKSContext();
        private NguoiDungServices _nguoiDungServices = new NguoiDungServices();

        public ActionResult List()
        {
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
            var nguoiDungModel = new NguoiDungModel();
            return View(nguoiDungModel);
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
            var item = new NGUOIDUNG();
            item.tendangnhap = model.tendangnhap;
            item.tennguoidung = model.tennguoidung;
            item.sodienthoai = model.sodienthoai;
            item.gioitinh = model.gioitinh;
            item.diachi = model.diachi;
            item.ngaysinh = model.ngaysinh;
            item.hash = BCrypt.Net.BCrypt.HashPassword(model.matkhau);
            db.NGUOIDUNGs.Add(item);
            db.SaveChangesAsync();
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
            var item = db.NGUOIDUNGs.Where(c => c.ID == model.ID).FirstOrDefault();
            if (item == null)
            {
                TempData["Message"] = "Có lỗi xảy ra";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("List");
            }
            //map from model to database object
            item = Mapper.Map(model, item);
            item.hash = BCrypt.Net.BCrypt.HashPassword(model.matkhau);
            db.SaveChangesAsync();
            TempData["Message"] = "Cập nhật thành công";
            TempData["NotiType"] = "success"; //success là class trong bootstrap
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var nguoidung = db.NGUOIDUNGs.Find(id);
            db.NGUOIDUNGs.Remove(nguoidung);
            db.SaveChangesAsync();
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
                    Session["tendangnhap"] = item.tendangnhap;
                    Session["tennguoidung"] = item.tennguoidung;
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
                Session.Abandon();
                TempData["Message"] = "Đăng xuất thành công";
                TempData["NotiType"] = "success"; //success là class trong bootstrap
                return RedirectToAction("Login");
            }
        }

    }
}