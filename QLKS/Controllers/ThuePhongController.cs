using AutoMapper;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using QLKS.Domain;
using QLKS.Models;
using QLKS.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using static QLKS.Extensions.Enum;

namespace QLKS.Controllers
{
    public class ThuePhongController : Controller
    {
        // GET: ThuePhong
        QLKSContext db = new QLKSContext();
        private LoaiPhongServices _loaiPhongServices = new LoaiPhongServices();
        private PhongServices _phongServices = new PhongServices();
        private KhachHangServices _khachHangServices = new KhachHangServices();
        private NguoiDungServices _nguoiDungServices = new NguoiDungServices();
        private LichSuServices _lichSuServices = new LichSuServices();
        private DichVuServices _dichVuServices = new DichVuServices();
        private QuyenServices _quyenServices = new QuyenServices();
        public ActionResult List()
        {
            if (!_nguoiDungServices.isLoggedIn())
            {
                TempData["Message"] = "Bạn chưa đăng nhập, vui lòng đăng nhập";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("Login", "NguoiDung");
            }
            if (!_quyenServices.Authorize((int)EnumQuyen.THUEPHONG_XEM))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
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
            if (!_nguoiDungServices.isLoggedIn())
            {
                TempData["Message"] = "Bạn chưa đăng nhập, vui lòng đăng nhập";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("Login", "NguoiDung");
            }
            if (!_quyenServices.Authorize((int)EnumQuyen.THUEPHONG_THEM))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
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
            var item = new THUEPHONG();
            item.KHACHHANG = newKhachHang;
            item.KHACHHANG_ID = newKhachHang.ID;
            item.ma = model.ma;
            db.THUEPHONGs.Add(item);
            item.KHACHHANG = newKhachHang;
            foreach(var chitiet in model.ChiTietThuePhong)
            {
                var newChiTiet = new CHITIETTHUEPHONG();
                newChiTiet.ngayra = chitiet.ngayra;
                newChiTiet.ngayvao = chitiet.ngayvao;
                newChiTiet.PHONG_ID = chitiet.phong_id;
                newChiTiet.THUEPHONG_ID = item.ID;
                item.CHITIETTHUEPHONGs.Add(newChiTiet);
                var phong = db.PHONGs.Find(chitiet.phong_id);
                phong.LOAITINHTRANG_ID = (int)EnumLoaiTinhTrang.DATHUE;
            }

            foreach(var sudungdichvu in model.ChiTietDichVu)
            {
                var newSuDungDichVu = new SUDUNGDICHVU();
                newSuDungDichVu.THUEPHONG_ID = item.ID;
                newSuDungDichVu.DICHVU_ID = sudungdichvu.DICHVU_ID;
                newSuDungDichVu.ngaysudung = sudungdichvu.ngaysudung;
                newSuDungDichVu.NGUOIDUNG_ID = (int)Session["ID"];
                newSuDungDichVu.soluong = sudungdichvu.soluong;
                newSuDungDichVu.thanhtien = sudungdichvu.thanhtien;
                item.SUDUNGDICHVUs.Add(newSuDungDichVu);
            }
            db.SaveChanges();
            //Lưu lịch sử hệ thống
            _lichSuServices.LuuLichSu((int)Session["ID"], (int)EnumLoaiHanhDong.THEM, item.GetType().ToString());
            TempData["Message"] = "Thêm mới thành công";
            TempData["NotiType"] = "success";
            return Json("ok");
        }

        public ActionResult Edit(int? id)
        {
            if (!_nguoiDungServices.isLoggedIn())
            {
                TempData["Message"] = "Bạn chưa đăng nhập, vui lòng đăng nhập";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("Login", "NguoiDung");
            }
            if (!_quyenServices.Authorize((int)EnumQuyen.THUEPHONG_SUA))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            if (id == null)
            {
                return RedirectToAction("List");
            }
            var item = db.THUEPHONGs.Find(id);
            if (item == null)
            {
                TempData["Message"] = "Không tìm thấy đơn thuê phòng này";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("List");
            }
            //prepare model
            var model = Mapper.Map<ThuePhongModel>(item);
            var listChiTietModel = new List<ChiTietThuePhongModel>();
            var listDichVuModel = new List<SuDungDichVuModel>();
            foreach(var chitiet in item.CHITIETTHUEPHONGs)
            {
                var m = Mapper.Map<ChiTietThuePhongModel>(chitiet);
                listChiTietModel.Add(m);
            }

            foreach(var chitiet in item.SUDUNGDICHVUs)
            {
                var m = new SuDungDichVuModel();
                m.DICHVU_ID = chitiet.DICHVU_ID;
                m.ngaysudung = chitiet.ngaysudung;
                m.soluong = chitiet.soluong;
                m.thanhtien = chitiet.thanhtien;
                m.THUEPHONG_ID = chitiet.THUEPHONG_ID;
                listDichVuModel.Add(m);
            }
            model.ChiTietThuePhong = listChiTietModel;
            model.ChiTietDichVu= listDichVuModel;
            model.tenkhachhang = item.KHACHHANG.tenkhachhang;
            model.sdt = item.KHACHHANG.sodienthoai;
            model.socmt = item.KHACHHANG.socmt;
            model.KHACHHANG_ID = item.KHACHHANG.ID;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ThuePhongModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Có lỗi xảy ra! Vui lòng kiểm tra lại thông tin.";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return View("Create", model);
            }
            //update khachhang
            var khachHang = db.KHACHHANGs.Find(model.KHACHHANG_ID);
            khachHang.socmt = model.socmt;
            khachHang.sodienthoai = model.sdt;
            khachHang.tenkhachhang = model.tenkhachhang;
            //update chitiet
            var item = db.THUEPHONGs.Find(model.ID);
            //update trang thai phong
            foreach(var i in item.CHITIETTHUEPHONGs)
            {
                var phong = db.PHONGs.Find(i.PHONG.ID);
                phong.LOAITINHTRANG_ID = (int)EnumLoaiTinhTrang.BAN;
            }
            item.CHITIETTHUEPHONGs.Clear();
            foreach(var chitiet in model.ChiTietThuePhong)
            {
                var m = Mapper.Map<CHITIETTHUEPHONG>(chitiet);
                item.CHITIETTHUEPHONGs.Add(m);
                var p = db.PHONGs.Find(chitiet.phong_id);
                p.LOAITINHTRANG_ID = (int)EnumLoaiTinhTrang.DATHUE;
            }

            item.SUDUNGDICHVUs.Clear();
            foreach(var dichvu in model.ChiTietDichVu)
            {
                var i = new SUDUNGDICHVU();
                i.DICHVU_ID = dichvu.DICHVU_ID;
                i.THUEPHONG_ID = item.ID;
                i.ngaysudung = dichvu.ngaysudung;
                i.NGUOIDUNG_ID = (int)Session["ID"];
                i.soluong = dichvu.soluong;
                i.thanhtien = dichvu.thanhtien;
                item.SUDUNGDICHVUs.Add(i);
            }
            db.SaveChanges();
            _lichSuServices.LuuLichSu((int)Session["ID"], (int)EnumLoaiHanhDong.SUA, item.GetType().ToString());
            TempData["Message"] = "Cập nhật thành công";
            TempData["NotiType"] = "success";
            return Json("ok");
        }

        public ActionResult _AddNewChiTietThue(int? phong = 0, int? thuephong = 0)
        {
            var model = new ChiTietThuePhongModel();
            if(phong != 0 && thuephong != 0)
            {
                var itemThue = db.THUEPHONGs.Find(thuephong);
                var itemChiTietThuePhong = itemThue.CHITIETTHUEPHONGs.Where(c => c.PHONG_ID == phong).FirstOrDefault();
                var itemPhong = db.PHONGs.Find(phong);

                model.DanhSachLoaiPhong = _loaiPhongServices.PrepareSelectListLoaiPhong(itemPhong.LOAIPHONG_ID);
                model.gia = itemPhong.giathue.Value;
                model.DanhSachPhong = _phongServices.PrepareSelectListPhong(phong);
                model.ngayra = itemChiTietThuePhong.ngayra;
                model.ngayvao = itemChiTietThuePhong.ngayvao;
            }
            else
            {
                model.DanhSachLoaiPhong = _loaiPhongServices.PrepareSelectListLoaiPhong(0);
                model.DanhSachPhong = _phongServices.PrepareSelectListPhong(phong);
            }

            return PartialView(model);
        }

        public ActionResult _AddNewSuDungDichVu(int? dichvu = 0, int? thuephong = 0)
        {
            var model = new SuDungDichVuModel();
            if (dichvu != 0 && thuephong != 0)
            {
                var itemThue = db.THUEPHONGs.Find(thuephong);

                var itemChiTietDichVu = itemThue.SUDUNGDICHVUs.Where(c => c.DICHVU_ID == dichvu).FirstOrDefault();
                //check null here but im lazy 
                var itemSuDungDichVu = db.SUDUNGDICHVUs.Where(c=> c.THUEPHONG_ID == thuephong && c.DICHVU_ID == dichvu).FirstOrDefault();

                model.DanhSachDichVu = _dichVuServices.PrepareSelectListDichVu(itemChiTietDichVu.DICHVU_ID);
                model.ngaysudung = itemSuDungDichVu.ngaysudung;
                model.thanhtien = itemSuDungDichVu.thanhtien;
                model.soluong = itemSuDungDichVu.soluong;
            }
            else
            {
                model.DanhSachDichVu = _dichVuServices.PrepareSelectListDichVu(0);
            }

            return PartialView(model);
        }


        [HttpPost]
        public ActionResult Delete(int? id = 0)
        {
            if (!_quyenServices.Authorize((int)EnumQuyen.THUEPHONG_XOA))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            var item = db.THUEPHONGs.Find(id);
            foreach(var i in item.CHITIETTHUEPHONGs)
            {
                var phong = db.PHONGs.Find(i.PHONG.ID);
                phong.LOAITINHTRANG_ID = (int)EnumLoaiTinhTrang.BAN;
            }
            if (item != null)
            {
                db.THUEPHONGs.Remove(item);
                db.SaveChanges();
                //Lưu nhật ký
                _lichSuServices.LuuLichSu((int)Session["ID"],(int)EnumLoaiHanhDong.XOA, item.GetType().ToString());
                //Thông báo
                TempData["Message"] = "Xóa thông tin thành công";
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
            if (!_quyenServices.Authorize((int)EnumQuyen.THUEPHONG_XEM))
            {
                return Json("no");
            }
            return Json("yes");
        }
    }
}