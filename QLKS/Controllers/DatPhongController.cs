using AutoMapper;
using QLKS.Domain;
using QLKS.Models;
using QLKS.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static QLKS.Extensions.Enum;

namespace QLKS.Controllers
{
    public class DatPhongController : Controller
    {
        // GET: DatPhong
        private QLKSContext db = new QLKSContext();
        private NguoiDungServices _nguoiDungServices = new NguoiDungServices();
        private LichSuServices _lichSuServices = new LichSuServices();
        private QuyenServices _quyenServices = new QuyenServices();
        private PhongServices _phongServices = new PhongServices();
        private KhachHangServices _khachHangServices = new KhachHangServices();
        private LoaiPhongServices _loaiPhongServices = new LoaiPhongServices();
        public ActionResult List()
        {
            if (!_nguoiDungServices.isLoggedIn())
            {
                TempData["Message"] = "Bạn chưa đăng nhập, vui lòng đăng nhập";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("Login", "NguoiDung");
            }
            if (!_quyenServices.Authorize((int)EnumQuyen.DATPHONG_XEM))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            return View();
        }

        public ActionResult Create()
        {
            if (!_nguoiDungServices.isLoggedIn())
            {
                TempData["Message"] = "Bạn chưa đăng nhập, vui lòng đăng nhập";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("Login", "NguoiDung");
            }
            if (!_quyenServices.Authorize((int)EnumQuyen.DATPHONG_THEM))
            {
                TempData["Message"] = "Bạn không có quyền truy cập chức năng này";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("ViewDenied", "QLKS");
            }
            var datPhongModel = new DatPhongModel();
            var maxId = db.DATPHONGs.Select(c => c.ID).DefaultIfEmpty(0).Max();
            var newId = (maxId + 1).ToString().PadLeft(7, '0');
            datPhongModel.MaDatPhong = "DP" + "-" + newId;
            datPhongModel.DanhSachLoaiPhong = _loaiPhongServices.PrepareSelectListLoaiPhong(0);
            return View(datPhongModel);
        }

        [HttpPost]
        public ActionResult Create(DatPhongModel model)
        {
            if (!_quyenServices.Authorize((int)EnumQuyen.DATPHONG_THEM))
            {
                TempData["Message"] = "Bạn không có quyền truy cập chức năng này";
                TempData["NotiType"] = "error"; //success là class trong bootstrap
                return RedirectToAction("ViewDenied", "QLKS");
            }
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Có lỗi xảy ra! Vui lòng kiểm tra lại thông tin.";
                TempData["NotiType"] = "danger";
                if(model.LOAIPHONG_ID == null)
                { 
                    model.DanhSachLoaiPhong = _loaiPhongServices.PrepareSelectListLoaiPhong(0);
                }
                else
                {    
                    model.DanhSachLoaiPhong = _loaiPhongServices.PrepareSelectListLoaiPhong(model.LOAIPHONG_ID);
                }
                return View("Create", model);
            }

            var item = AutoMapper.Mapper.Map<DATPHONG>(model);
            var results = db.Database.SqlQuery<sp_Result_ThongKePhong>("exec ThongKePhong @tungay, @denngay", new SqlParameter("@tungay", model.ngaydukienden), new SqlParameter("@denngay", model.ngaydukiendi)).ToList();
            foreach (var i in results)
            {
                if (i.ID == model.LOAIPHONG_ID && i.SoPhongTrong < model.SoPhong)
                {
                    if (model.LOAIPHONG_ID == null)
                    {
                        model.DanhSachLoaiPhong = _loaiPhongServices.PrepareSelectListLoaiPhong(0);
                    }
                    else
                    {
                        model.DanhSachLoaiPhong = _loaiPhongServices.PrepareSelectListLoaiPhong(model.LOAIPHONG_ID);
                    }
                    TempData["Message"] = "Không đủ đặt " + model.SoPhong + " phòng. Chỉ còn lại " + i.SoPhongTrong + " phòng.";
                    TempData["NotiType"] = "danger";
                    return View("Create", model);
                }
            }
            var khachhang = new KhachHangModel();
            khachhang.Ma = _khachHangServices.GenMaKhachHang();
            khachhang.Ten = model.tenkhachhang;
            khachhang.SoCMT = model.socmt;
            khachhang.SoDienThoai = model.sodienthoai;
            khachhang.Email = model.email;
            var khachHangItem = AutoMapper.Mapper.Map<KHACHHANG>(khachhang);
            db.KHACHHANGs.Add(khachHangItem);
            db.SaveChanges();
            item.KHACHHANG = khachHangItem;
            var nguoidungItem = db.NGUOIDUNGs.Find((int)Session["ID"]);
            item.NGUOIDUNG = nguoidungItem;
            item.LOAITINHTRANG_ID = (int)EnumLoaiTinhTrang.CHUACHECKIN;
            item.ThoiGianDat = DateTime.Now;
            db.DATPHONGs.Add(item);
            //

            db.SaveChanges();
            _lichSuServices.LuuLichSu((int)Session["ID"], (int)EnumLoaiHanhDong.THEM, item.GetType().ToString());
            TempData["Message"] = "Thêm mới thành công";
            TempData["NotiType"] = "success";
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult KiemTraTrangThai(string tungay, string denngay)
        {
            var results = db.Database.SqlQuery<sp_Result_ThongKePhong>("exec ThongKePhong @tungay, @denngay", new SqlParameter("@tungay", tungay), new SqlParameter("@denngay", denngay)).ToList();
            var ret = results.Select(c => new
            {
                ten = c.Ten,
                giathue = c.GiaThue,
                tongsophong = c.TongSoLuongPhong,
                sophongdattruoc = c.SoPhongDatTruoc,
                sophongdathue = c.SoPhongDaThue,
                sophongtrong = c.SoPhongTrong
            }).ToList();
            var r = new { data = ret };
            return Json(r);
        }

        [HttpPost]
        public ActionResult PopulateDatPhong()
        {
            var danhSachDatPhong = db.DATPHONGs.Select(c => new
            {
                madatphong = c.MaDatPhong,
                tenloaiphong = c.LOAIPHONG.Ten,
                tenkhachhang = c.KHACHHANG.Ten,
                emailkhachhang = c.KHACHHANG.Email,
                dukienden = c.NgayDuKienDen,
                dukiendi = c.NgayDuKienDi,
                trangthai = c.LOAITINHTRANG.Ten,
                sodienthoai = c.KHACHHANG.SoDienThoai,
                id = c.ID
            }).OrderBy(c => c.trangthai).ThenBy(c => c.id).ToList();
            var result = new { data = danhSachDatPhong };

            return Json(result);
        }

        // GET: DatPhong/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!_nguoiDungServices.isLoggedIn())
            {
                TempData["Message"] = "Bạn chưa đăng nhập, vui lòng đăng nhập";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("Login", "NguoiDung");
            }
            if (!_quyenServices.Authorize((int)EnumQuyen.DATPHONG_SUA))
            {
                TempData["Message"] = "Bạn không có quyền thực hiện chức năng này.";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("ViewDenied", "QLKS");
            }
            if (id == null)
            {
                TempData["Message"] = "Không tìm thấy phiếu đặt phòng này";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("List");
            }
            var item = db.DATPHONGs.Find(id);
            if(item == null)
            {
                TempData["Message"] = "Không tìm thấy phiếu đặt phòng này";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("List");
            }
            var model = Mapper.Map<DatPhongModel>(item);
            var khachhang = db.KHACHHANGs.Find(item.KHACHHANG.ID);
            model.tenkhachhang = khachhang.Ten;
            model.socmt = khachhang.SoCMT;
            model.sodienthoai = khachhang.SoDienThoai;
            model.email = khachhang.Email;
            model.DanhSachLoaiPhong = _loaiPhongServices.PrepareSelectListLoaiPhong(model.LOAIPHONG_ID);
            return View(model);
        }
        ///
        // POST: DatPhong/Edit/5
        [HttpPost]
        public ActionResult Edit(DatPhongModel model)
        {
            if (!_quyenServices.Authorize((int)EnumQuyen.DATPHONG_SUA))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            if (ModelState.IsValid)
            {
                var item = db.DATPHONGs.Find(model.DATPHONG_ID);
                var khachhang = db.KHACHHANGs.Find(item.KHACHHANG.ID);
                //item = Mapper.Map<DATPHONG>(model);
                if(item == null)
                {
                    TempData["Message"] = "Không thấy đơn đặt phòng này";
                    TempData["NotiType"] = "danger"; //success là class trong bootstrap
                    return RedirectToAction("List");
                }
                if(khachhang == null)
                {
                    TempData["Message"] = "Không tìm thấy khách hàng này";
                    TempData["NotiType"] = "danger"; //success là class trong bootstrap
                    return RedirectToAction("List");
                }
                khachhang.Ten = model.tenkhachhang;
                khachhang.SoDienThoai = model.sodienthoai;
                khachhang.SoCMT = model.socmt;
                khachhang.Email = model.email;
                
                if(model.LOAIPHONG_ID != item.LOAIPHONG.ID || model.ngaydukienden != item.NgayDuKienDen || model.ngaydukiendi != item.NgayDuKienDi || model.SoPhong != item.SoPhong)
                {
                    var results = db.Database.SqlQuery<sp_Result_ThongKePhong>("exec ThongKePhong @tungay, @denngay", new SqlParameter("@tungay", model.ngaydukienden), new SqlParameter("@denngay", model.ngaydukiendi)).ToList();
                    foreach (var r in results)
                    {
                        if (r.ID == model.LOAIPHONG_ID && r.SoPhongTrong < model.SoPhong)
                        {
                            if (model.LOAIPHONG_ID == null)
                            {
                                model.DanhSachLoaiPhong = _loaiPhongServices.PrepareSelectListLoaiPhong(0);
                            }
                            else
                            {
                                model.DanhSachLoaiPhong = _loaiPhongServices.PrepareSelectListLoaiPhong(model.LOAIPHONG_ID);
                            }
                            TempData["Message"] = "Không đủ đặt " + model.SoPhong + " phòng. Chỉ còn lại " + r.SoPhongTrong + " phòng.";
                            TempData["NotiType"] = "danger";

                            return View("Edit", model);
                        }
                        if(r.ID == model.LOAIPHONG_ID && r.SoPhongTrong >= model.SoPhong)
                        {
                            item.LOAIPHONG_ID = model.LOAIPHONG_ID;
                            item.SoPhong = model.SoPhong;
                            item.NgayDuKienDen = model.ngaydukienden.Value;
                            item.NgayDuKienDi = model.ngaydukiendi.Value;
                            item.SoPhong = model.SoPhong;
                        }
                    }
                }
                db.SaveChanges();
                _lichSuServices.LuuLichSu((int)Session["ID"], (int)EnumLoaiHanhDong.SUA, item.ToString());
                TempData["Message"] = "Cập nhật thành công";
                TempData["NotiType"] = "success"; //success là class trong bootstrap
                return RedirectToAction("List");
            }
            else
            {
                TempData["Message"] = "Có lỗi xảy ra! Vui lòng kiểm tra lại thông tin.";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return View("Edit", model);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (!_quyenServices.Authorize((int)EnumQuyen.DATPHONG_XOA))
            {
                TempData["Message"] = "Bạn không có quyền thực hiện chức năng này.";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("ViewDenied", "QLKS");
            }

            var item = db.DATPHONGs.Find(id);
            if (item == null)
            {
                TempData["Message"] = "Không tìm thấy phiếu đặt phòng này";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("List");
            }
            
            try
            {
                db.DATPHONGs.Remove(item);
                db.SaveChanges();
                TempData["Message"] = "Xóa loại phòng thành công";
                TempData["NotiType"] = "success";
                _lichSuServices.LuuLichSu((int)Session["ID"], (int)EnumLoaiHanhDong.XOA, item.GetType().ToString());
                return Json("ok");
            }
            catch
            {
                throw new Exception();
            }

        }
    }
}
