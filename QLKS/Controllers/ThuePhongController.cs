using AutoMapper;
using Microsoft.Ajax.Utilities;
using QLKS.Domain;
using QLKS.Models;
using QLKS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static QLKS.Extensions.Enum;

namespace QLKS.Controllers
{
    public class ThuePhongController : Controller
    {
        // GET: ThuePhong
        QLKSContext db = new QLKSContext();
        LoaiPhongServices _loaiPhongServices = new LoaiPhongServices();
        PhongServices _phongServices = new PhongServices();
        KhachHangServices _khachHangServices = new KhachHangServices();

        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PopulateThuePhong()
        {
            var allThuePhong = db.THUEPHONGs.ToList();
            var a = new List<object>();
            foreach(var thue in allThuePhong)
            {
                var data = new
                {
                    tenkhachhang = thue.KHACHHANG.tenkhachhang,
                    sdt = thue.KHACHHANG.sodienthoai,
                    sophongthue = thue.CHITIETTHUEPHONGs.Count,
                    uid = thue.ID,
                    ma = thue.ma
                };
                a.Add(data);
            }
            var result = new { data = a };
            return Json(result);
        }

        public ActionResult Create()
        {
            var model = new ThuePhongModel();
            var maxId = db.THUEPHONGs.Select(c => c.ID).DefaultIfEmpty(0).Max();
            var newId = (maxId + 1).ToString().PadLeft(7, '0');
            model.ma = "TP" + "-" + newId;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ThuePhongModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Có lỗi xảy ra! Vui lòng kiểm tra lại thông tin.";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return View("Create", model);
            }
            //insert new khachhang
            var newKhachHang = new KHACHHANG();
            newKhachHang.ma = _khachHangServices.GenMaKhachHang();
            newKhachHang.socmt = model.socmt;
            newKhachHang.sodienthoai = model.sdt;
            newKhachHang.tenkhachhang = model.tenkhachhang;
            
            //insert new thuephong
            var newThuePhong = new THUEPHONG();
            newThuePhong.KHACHHANG = newKhachHang;
            newThuePhong.KHACHHANG_ID = newKhachHang.ID;
            newThuePhong.ma = model.ma;
            db.THUEPHONGs.Add(newThuePhong);
            newThuePhong.KHACHHANG = newKhachHang;
            foreach(var chitiet in model.ChiTietThuePhong)
            {
                var newChiTiet = new CHITIETTHUEPHONG();
                newChiTiet.ngayra = chitiet.ngayra;
                newChiTiet.ngayvao = chitiet.ngayvao;
                newChiTiet.PHONG_ID = chitiet.phong_id;
                newChiTiet.THUEPHONG_ID = newThuePhong.ID;
                newThuePhong.CHITIETTHUEPHONGs.Add(newChiTiet);
                var phong = db.PHONGs.Find(chitiet.phong_id);
                phong.LOAITINHTRANG_ID = (int)EnumLoaiTinhTrang.DATHUE;
            }
            db.SaveChanges();
            TempData["Message"] = "Thêm mới thành công";
            TempData["NotiType"] = "success";
            return Json("ok");
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult _AddNewChiTietThue(int? loaiphong = 0, int? phong = 0)
        {
            var model = new ChiTietThuePhongModel();
            model.DanhSachLoaiPhong = _loaiPhongServices.PrepareSelectListLoaiPhong(loaiphong);
            model.DanhSachPhong = _phongServices.PrepareSelectListPhong(phong);
            return PartialView(model);
        }
    }
}