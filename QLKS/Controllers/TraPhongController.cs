using AutoMapper;
using QLKS.Domain;
using QLKS.Models;
using QLKS.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static QLKS.Extensions.Enum;

namespace QLKS.Controllers
{
    public class TraPhongController : Controller
    {
        private QLKSContext db = new QLKSContext();
        private QuyenServices _quyenServices = new QuyenServices();
        private NguoiDungServices _nguoiDungServices = new NguoiDungServices();

        // GET: TraPhong
        public ActionResult List()
        {
            if (!_nguoiDungServices.isLoggedIn())
            {
                TempData["Message"] = "Bạn chưa đăng nhập, vui lòng đăng nhập";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("Login", "NguoiDung");
            }
            if (!_quyenServices.Authorize((int)EnumQuyen.TRAPHONG_XEM))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            return View();
        }

        [HttpPost]
        public ActionResult thongTinDatPhong(int? id)
        {
            var thongTinDatPhong =
                from thuePhong in db.THUEPHONGs
                join khachHang in db.KHACHHANGs
                on thuePhong.KHACHHANG_ID equals khachHang.ID
                join chiTietThuePhong in db.CHITIETTHUEPHONGs
                on thuePhong.ID equals chiTietThuePhong.THUEPHONG_ID
                where ((id == -1) ? (true) : (thuePhong.ID == id)) &&
                    !( from thanhToan in db.THANHTOANs
                    select thanhToan.THUEPHONG_ID)
                    .Contains(thuePhong.ID)
                select new
                {
                    id = thuePhong.ID,
                    maThue = thuePhong.Ma,
                    tenKhach = khachHang.Ten,
                    sdt = khachHang.SoDienThoai,
                    cmt = khachHang.SoCMT,
                    maPhong = chiTietThuePhong.PHONG_ID,
                    ngayVao = chiTietThuePhong.THUEPHONG.NgayDen,
                    ngayRa = chiTietThuePhong.THUEPHONG.NgayDi
                };
            return Json(new { data = thongTinDatPhong });
        }

        public ActionResult traPhong(int? maThue)
        {
            if (!_nguoiDungServices.isLoggedIn())
            {
                TempData["Message"] = "Bạn chưa đăng nhập, vui lòng đăng nhập";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("Login", "NguoiDung");
            }
            if (!_quyenServices.Authorize((int)EnumQuyen.TRAPHONG_THEM))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            ViewBag.maThue = maThue;
            return View();
        }

        [HttpPost]
        public ActionResult thongTinDichVu(int? id)
        {
            var thongTinDichVu =
                from suDungDichVu in db.SUDUNGDICHVUs
                join thuePhong in db.THUEPHONGs
                on suDungDichVu.CHITIETTHUEPHONG.THUEPHONG_ID equals thuePhong.ID
                join dichVu in db.DICHVUs
                on suDungDichVu.DICHVU_ID equals dichVu.ID
                where suDungDichVu.CHITIETTHUEPHONG.THUEPHONG_ID == id
                select new
                {
                    idDichVu = dichVu.ID,
                    tenDichVu = dichVu.Ten,
                    donGia = dichVu.DonGia,
                    maDichVu = dichVu.Ma,
                    ngaySD = suDungDichVu.ThoiGianSuDung,
                    soLuong = suDungDichVu.SoLuong
                };
            return Json(new { data = thongTinDichVu });
        }

        [HttpPost]
        public ActionResult thongTinThuePhong(int? id)
        {
            var thongTinDatPhong =
                from chiTietThuePhong in db.CHITIETTHUEPHONGs
                join thuePhong in db.THUEPHONGs
                on chiTietThuePhong.THUEPHONG_ID equals thuePhong.ID
                join phong in db.PHONGs
                on chiTietThuePhong.PHONG_ID equals phong.ID
                where thuePhong.ID == id
                select new
                {
                    id = phong.ID,
                    maPhong = phong.SoPhong,
                    ngayVao = chiTietThuePhong.THUEPHONG.NgayDen,
                    ngayRa = chiTietThuePhong.THUEPHONG.NgayDi,
                    giaThue = phong.LOAIPHONG.GiaThue,
                    soTang = phong.SoTang,
                };
            var test = thongTinDatPhong.ToList();
            return Json(new { data = thongTinDatPhong });
        }

        [HttpPost]
        public void thanhToan(int tienPhong, string maKiemTra, int maThuePhong, int[] danhSachPhongThue)
        {
            DateTime now = DateTime.Now;
            THANHTOAN thanhToan = new THANHTOAN
            {
                NgayThanhToan = now,
                ThanhTien = tienPhong,
                THUEPHONG_ID = maThuePhong
            };
            foreach(var idPhong in danhSachPhongThue)
            {
                var phong = db.PHONGs.Find(idPhong);
                phong.LOAITINHTRANG_ID = 1;
            }
            db.THANHTOANs.Add(thanhToan);
            db.SaveChanges();
        }
    }
}