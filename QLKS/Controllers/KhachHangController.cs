﻿using AutoMapper;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using QLKS.Domain;
using QLKS.Models;
using QLKS.Services;
using QLKS.Validators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static QLKS.Extensions.Enum;

namespace QLKS.Controllers
{
    public class KhachHangController : Controller
    {
        private QLKSContext db = new QLKSContext();
        private KhachHangServices _khachHangServices = new KhachHangServices();
        private NguoiDungServices _nguoiDungServices = new NguoiDungServices();// dòng này để check login
        private LichSuServices _lichSuServices = new LichSuServices();
        private QuyenServices _quyenServices = new QuyenServices(); //check quyền
        public ActionResult List()
        {
            //check login
            if (!_nguoiDungServices.isLoggedIn())
            {
                TempData["Message"] = "Bạn chưa đăng nhập, vui lòng đăng nhập";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("Login", "NguoiDung");
            }
            //check quyền
            if (!_quyenServices.Authorize((int)EnumQuyen.KHACHHANG_XEM)) //quyền đặt trong EnumQuyen
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            return View();
        }
        
        [HttpPost]
        public ActionResult PopulateKhachHang()
        {
            var danhSachKhachHang = db.KHACHHANGs.Select(c => new
            {
                ma = c.Ma,
                ten = c.Ten,
                cmt = c.SoCMT,
                sdt = c.SoDienThoai,
                email = c.Email,
                uid = c.ID
            }).OrderBy(c => c.uid).ToList();
            var result = new { data = danhSachKhachHang };
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
            if (!_quyenServices.Authorize((int)EnumQuyen.KHACHHANG_THEM))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            var model = new KhachHangModel();
            model.Ma = _khachHangServices.GenMaKhachHang();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(KhachHangModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Có lỗi xảy ra! Vui lòng kiểm tra lại thông tin.";
                TempData["NotiType"] = "success"; //success là class trong bootstrap
                return View("Create", model);
            }
            if (!_quyenServices.Authorize((int)EnumQuyen.KHACHHANG_THEM))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            var item = Mapper.Map<KHACHHANG>(model);
            int a = 0;
            db.Database.ExecuteSqlCommand("exec SP_CreateOrUpdate_KHACHHANG @Type, @ID, @Ma, @Ten, @GioiTinh, @SoCMT, @SoDienThoai, @Email, @UpdateID", new SqlParameter("@Type", int.Parse("0")), new SqlParameter("@ID", a), new SqlParameter("@Ten", item.Ten), new SqlParameter("@GioiTinh", item.GioiTinh.Value ? 0 : 1), new SqlParameter("@Ma", item.Ma), new SqlParameter("@UpdateID", int.Parse("0")), new SqlParameter("@SoCMT", item.SoCMT), new SqlParameter("@SoDienThoai", item.SoDienThoai), new SqlParameter("@Email", item.Email));

            db.SaveChanges();

            //db.KHACHHANGs.Add(item);
            //db.SaveChanges();
            //Lưu lịch sử hệ thống
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
            if (!_quyenServices.Authorize((int)EnumQuyen.KHACHHANG_SUA))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            if (id == null)
            {
                return RedirectToAction("List");
            }
            var khachhang = db.KHACHHANGs.Find(id);
            if(khachhang == null)
            {
                TempData["Message"] = "Không tìm thấy khách hàng này";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("List");
            }
            //prepare model
            var khachhangModel = AutoMapper.Mapper.Map<KhachHangModel>(khachhang);
            return View(khachhangModel);
        }

        [HttpPost]
        public ActionResult Edit(KhachHangModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Có lỗi xảy ra! Vui lòng kiểm tra lại thông tin.";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return View("Edit", model);
            }
            if (!_quyenServices.Authorize((int)EnumQuyen.KHACHHANG_SUA))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            var item = db.KHACHHANGs.Where(c => c.ID == model.ID).FirstOrDefault();
            if(item == null)
            {
                TempData["Message"] = "Có lỗi xảy ra";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("List");
            }
            //map from model to database object

            //item = Mapper.Map(model, item);
            int a = 0;
            a = db.Database.ExecuteSqlCommand("exec SP_CreateOrUpdate_KHACHHANG @Type, @ID, @Ma, @Ten, @GioiTinh, @SoCMT, @SoDienThoai, @Email, @UpdateID", new SqlParameter("@Type", int.Parse("1")), new SqlParameter("@ID", a), new SqlParameter("@Ten", model.Ten), new SqlParameter("@GioiTinh", model.GioiTinh ? 0 : 1), new SqlParameter("@Ma", model.Ma), new SqlParameter("@UpdateID", model.ID), new SqlParameter("@SoCMT", model.SoCMT), new SqlParameter("@SoDienThoai", model.SoDienThoai), new SqlParameter("@Email", model.Email));
            db.SaveChanges();
            //Lưu lịch sử hệ thống
            _lichSuServices.LuuLichSu((int)Session["ID"], (int)EnumLoaiHanhDong.SUA, item.GetType().ToString());
            TempData["Message"] = "Cập nhật thành công";
            TempData["NotiType"] = "success"; //success là class trong bootstrap
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (!_quyenServices.Authorize((int)EnumQuyen.KHACHHANG_XOA))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            var item = db.KHACHHANGs.Find(id);
            if (item != null)
            {
                //db.KHACHHANGs.Remove(item);
                int a = 0;
                a = db.Database.ExecuteSqlCommand("exec SP_Delete_KHACHHANG @ID",  new SqlParameter("@ID", item.ID));
                db.SaveChanges();
                //Lưu lịch sử hệ thống
                _lichSuServices.LuuLichSu((int)Session["ID"], (int)EnumLoaiHanhDong.XOA, item.GetType().ToString());
                //Thông báo
                TempData["Message"] = "Xóa khách hàng thành công";
                TempData["NotiType"] = "success";
                return Json("ok");
            }
            else
            {
                TempData["Message"] = "Có lỗi xảy ra";
                TempData["NotiType"] = "danger";
                return Json("error");
            }
        }

        [HttpPost]
        public ActionResult CheckQuyen()
        {
            if (!_quyenServices.Authorize((int)EnumQuyen.KHACHHANG_XEM))
            {
                return Json("no");
            }
            return Json("yes");
        }

    }
}