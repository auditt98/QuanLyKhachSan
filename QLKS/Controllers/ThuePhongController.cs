using AutoMapper;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using QLKS.Domain;
using QLKS.Models;
using QLKS.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
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
                        tenkhachhang = thue.KHACHHANG.Ten,
                        sdt = thue.KHACHHANG.SoDienThoai,
                        sophongthue = thue.CHITIETTHUEPHONGs.Count,
                        uid = thue.ID,
                        ma = thue.Ma
                    };
                    a.Add(data);
            }
            var result = new { data = a };
            return Json(result);
        }

        public ActionResult Create(int fromCheckin = 0)
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
            if (fromCheckin == 0)
            {
                model.fromEdit = "0";
                model.DanhSachLoaiPhong = _loaiPhongServices.PrepareSelectListLoaiPhong(0);
                model.fromCheckIn = "0";
                model.KHACHHANG_ID = 0;
                return View(model);
            }
            else
            {
                model.fromEdit = "0";
                model.fromCheckIn = fromCheckin.ToString() ;
                var datphongId = fromCheckin;
                var datPhongItem = db.DATPHONGs.Find(datphongId);
                var khachhangItem = datPhongItem.KHACHHANG;
                model.KHACHHANG_ID = khachhangItem.ID;
                model.LOAIPHONG_ID = datPhongItem.LOAIPHONG.ID;
                model.NgayDen = datPhongItem.NgayDuKienDen;
                model.NgayDi = datPhongItem.NgayDuKienDi;
                model.sdt = khachhangItem.SoDienThoai;
                model.socmt = khachhangItem.SoCMT;
                model.KHACHHANG_ID = khachhangItem.ID;
                model.tenkhachhang = khachhangItem.Ten;
                model.DanhSachLoaiPhong = _loaiPhongServices.PrepareSelectListLoaiPhong(datPhongItem.LOAIPHONG.ID);
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Create(ThuePhongModel model)
        {
            var fromCheckIn = Int32.Parse(model.fromCheckIn);
            if (!ModelState.IsValid)
            {
                if (fromCheckIn == 0)
                {
                    model.DanhSachLoaiPhong = _loaiPhongServices.PrepareSelectListLoaiPhong(0);
                    model.fromCheckIn = "0";
                    model.fromEdit = "0";
                    model.KHACHHANG_ID = 0;
                }
                else
                {
                    model.fromEdit = "0";
                    model.DanhSachLoaiPhong = _loaiPhongServices.PrepareSelectListLoaiPhong(fromCheckIn);
                    
                }
                TempData["Message"] = "Có lỗi xảy ra! Vui lòng kiểm tra lại thông tin.";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return View("Create", model);
            }
            if(fromCheckIn == 0)
            {
                model.fromEdit = "0";
                var khachhangItem = new KHACHHANG();
                var nguoidung = db.NGUOIDUNGs.Find((int)Session["ID"]);
                khachhangItem.Ma = _khachHangServices.GenMaKhachHang();
                khachhangItem.Ten = model.tenkhachhang;
                khachhangItem.SoCMT = model.socmt;
                khachhangItem.SoDienThoai = model.sdt;
                db.KHACHHANGs.Add(khachhangItem);
                db.SaveChanges();
                var newThuePhongItem = new THUEPHONG();
                newThuePhongItem.KHACHHANG = khachhangItem;
                newThuePhongItem.Ma = model.ma;
                newThuePhongItem.NgayDen = model.NgayDen;
                newThuePhongItem.NgayDi = model.NgayDi;
                newThuePhongItem.NGUOIDUNG = nguoidung;
                newThuePhongItem.ThoiGianThue = DateTime.Now;
                newThuePhongItem.LOAITINHTRANG_ID = (int)EnumLoaiTinhTrang.CHUATHANHTOAN;
                db.THUEPHONGs.Add(newThuePhongItem);
                db.SaveChanges();
                foreach(var p in model.SelectedPhongs)
                {
                    var newChiTietThuePhong = new CHITIETTHUEPHONG();
                    var phong = db.PHONGs.Find(p);
                    newChiTietThuePhong.PHONG = phong;
                    newThuePhongItem.CHITIETTHUEPHONGs.Add(newChiTietThuePhong);
                }
                db.SaveChanges();
                
            }
            else
            {
                //check additional errors
                model.fromEdit = "0";
                var datphongItem = db.DATPHONGs.Find(fromCheckIn);
                var khachHang = db.KHACHHANGs.Find(datphongItem.KHACHHANG.ID);
                var nguoidung = db.NGUOIDUNGs.Find((int)Session["ID"]);
                khachHang.Ten = model.tenkhachhang;
                khachHang.SoCMT = model.socmt;
                khachHang.SoDienThoai = model.sdt;
                db.SaveChanges();
                var newThuePhongItem = new THUEPHONG();
                newThuePhongItem.KHACHHANG = datphongItem.KHACHHANG;
                newThuePhongItem.Ma = model.ma;
                newThuePhongItem.NgayDen = model.NgayDen;
                newThuePhongItem.NgayDi = model.NgayDi;
                newThuePhongItem.NGUOIDUNG = nguoidung;
                newThuePhongItem.ThoiGianThue = DateTime.Now;
                newThuePhongItem.LOAITINHTRANG_ID = (int)EnumLoaiTinhTrang.CHUATHANHTOAN;
                db.THUEPHONGs.Add(newThuePhongItem);
                db.SaveChanges();
                int temp = datphongItem.SoPhong.Value; //migrate temp rooms from reservation
                var selectedPhongsCopy = model.SelectedPhongs;
                foreach (var p in selectedPhongsCopy.ToList())
                {
                    if(temp > 0)
                    {
                        var phong = db.PHONGs.Find(p);
                        if(phong.LOAIPHONG.ID == datphongItem.LOAIPHONG.ID)
                        {
                            var newChiTietThuePhong = new CHITIETTHUEPHONG();
                            newChiTietThuePhong.PHONG = phong;
                            newThuePhongItem.CHITIETTHUEPHONGs.Add(newChiTietThuePhong);
                            selectedPhongsCopy.Remove(p);
                            temp--;
                        }
                    }
                }
                datphongItem.LOAITINHTRANG_ID = (int)EnumLoaiTinhTrang.DACHECKIN;
                foreach(var p in newThuePhongItem.CHITIETTHUEPHONGs)
                {
                    p.PHONG.LOAITINHTRANG_ID = (int)EnumLoaiTinhTrang.DATHUE;
                }

                db.SaveChanges();
                
                if (selectedPhongsCopy.Count() > 0)
                {
                    foreach(var p in selectedPhongsCopy)
                    {
                        var phong = db.PHONGs.Find(p);
                        var result = db.Database.SqlQuery<sp_Result_ThongKePhong>("exec ThongKePhong @tungay, @denngay", new SqlParameter("@tungay", newThuePhongItem.NgayDen), new SqlParameter("@denngay", newThuePhongItem.NgayDi)).Where(c => c.ID == phong.LOAIPHONG.ID).FirstOrDefault();
                        if(result != null)
                        {
                            if(result.SoPhongTrong > 0)
                            {
                                var newChiTietThuePhong = new CHITIETTHUEPHONG();
                                var phongThue = db.PHONGs.Find(p);
                                newChiTietThuePhong.PHONG = phongThue;
                                newThuePhongItem.CHITIETTHUEPHONGs.Add(newChiTietThuePhong);
                                db.SaveChanges();
                            }
                            else
                            {
                                model.DanhSachLoaiPhong = _loaiPhongServices.PrepareSelectListLoaiPhong(fromCheckIn);
                                TempData["Message"] = "Không đủ phòng đặt thêm";
                                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                                return View("Create", model);

                            }
                        }

                    }
                    

                }
                //Lưu lịch sử hệ thống
                TempData["Message"] = "Thêm mới thành công";
                TempData["NotiType"] = "success";
                _lichSuServices.LuuLichSu((int)Session["ID"], (int)EnumLoaiHanhDong.THEM, newThuePhongItem.GetType().ToString());

                //add new chitietthuephong
            }

            return RedirectToAction("List", "ThuePhong");
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
            ////prepare model
            ///
            var loaiphong = item.CHITIETTHUEPHONGs.First().PHONG.LOAIPHONG.ID;
            var model = Mapper.Map<ThuePhongModel>(item);
            model.fromCheckIn = "0";
            model.sdt = item.KHACHHANG.SoDienThoai;
            model.socmt = item.KHACHHANG.SoCMT;
            model.KHACHHANG_ID = item.KHACHHANG.ID;
            model.tenkhachhang = item.KHACHHANG.Ten;
            model.DanhSachLoaiPhong = _loaiPhongServices.PrepareSelectListLoaiPhong(loaiphong);
            model.LOAIPHONG_ID = loaiphong;
            model.fromEdit = id.ToString();
            model.GiaThue = 0;
            foreach(var cttp in item.CHITIETTHUEPHONGs)
            {
                model.GiaThue += cttp.PHONG.LOAIPHONG.GiaThue;
            }
            var listSDDV = item.CHITIETTHUEPHONGs.Select(c => c.SUDUNGDICHVUs).ToList();
            var ctdv = new List<SUDUNGDICHVU>();
            foreach (var sddv in listSDDV)
            {
                foreach (var s in sddv)
                {
                    ctdv.Add(s);
                }
            }
            var listSDDVModel = new List<SuDungDichVuModel>();
            foreach(var c in ctdv)
            {
                var m = new SuDungDichVuModel();
                m.PHONG_ID = c.CHITIETTHUEPHONG.PHONG.ID;
                m.DonGia = c.DonGia;
                m.SoLuong = c.SoLuong;
                m.THUEPHONG_ID = c.CHITIETTHUEPHONG.THUEPHONG.ID;
                m.ThoiGianSuDung = c.ThoiGianSuDung;
                listSDDVModel.Add(m);
            }
            model.ChiTietDichVu = listSDDVModel;
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
            ////update khachhang
            var item = db.THUEPHONGs.Find(model.ID);
            var khachHang = db.KHACHHANGs.Find(model.KHACHHANG_ID);
            khachHang.SoCMT = model.socmt;
            khachHang.SoDienThoai= model.sdt;
            khachHang.Ten = model.tenkhachhang;

            db.SaveChanges();
            _lichSuServices.LuuLichSu((int)Session["ID"], (int)EnumLoaiHanhDong.SUA, item.GetType().ToString());
            TempData["Message"] = "Cập nhật thành công";
            TempData["NotiType"] = "success";
            return RedirectToAction("List", "ThuePhong");
        }

        [HttpPost]
        public ActionResult GetThongTinHoaDon(string fromEdit)
        {
            var tp = Int32.Parse(fromEdit);
            var item = db.THUEPHONGs.Find(tp);
            var khachhang = item.KHACHHANG;
            var listChiTiet = item.CHITIETTHUEPHONGs.Select(c => new { sophong = c.PHONG.SoPhong, dongia = c.PHONG.LOAIPHONG.GiaThue, loaiphong = c.PHONG.LOAIPHONG.Ten }).ToList(); ;
            var ngaythue = item.ThoiGianThue;
            var ngaybaocao = DateTime.Now;
            var giatien = 0;
            foreach(var i in item.CHITIETTHUEPHONGs)
            {
                giatien += i.PHONG.LOAIPHONG.GiaThue;
            }
            var result = new { tenkhachhang = khachhang.Ten, emailkhachhang = khachhang.Email, sodienthoaikhachhang = khachhang.SoDienThoai, mahoadon = item.Ma, giatien = giatien, chitiet = listChiTiet };
            return Json(result);
        }

        [HttpPost]
        public ActionResult GetDanhSachPhong(string loaiphong_id, string fromCheckIn, string fromEdit = "0")
        {
            var loaiphong = Int32.Parse(loaiphong_id);
            var datphongId = Int32.Parse(fromCheckIn);
            var editId = Int32.Parse(fromEdit);
            var datphongItem = db.DATPHONGs.Find(datphongId);
            if(datphongId == 0)
            {
                if(editId == 0)
                {
                    var danhsachphong = db.PHONGs.Where(x => x.LOAIPHONG.ID == loaiphong && x.LOAITINHTRANG.ID != 2).OrderBy(c => c.ID).ToList().Select(c => new { sophong = c.SoPhong, sotang = c.SoTang, id = c.ID, check = false }).ToList();
                    var result = new { data = danhsachphong };
                    return Json(result);
                }
                else
                {
                    var thuePhongItem = db.THUEPHONGs.Find(editId);
                    var danhsachphongChecked = thuePhongItem.CHITIETTHUEPHONGs.Select(c => c.PHONG).ToList().Select(c => new { sophong = c.SoPhong, sotang = c.SoTang, id = c.ID, check = true });
                    var result = new { data = danhsachphongChecked };
                    return Json(result);
                }
                
            }
            else
            {
                var soPhongDat = datphongItem.SoPhong;
                var danhsachphongChecked = db.PHONGs.Where(x => x.LOAIPHONG.ID == datphongItem.LOAIPHONG.ID && x.LOAITINHTRANG.ID != 2).OrderBy(c => c.ID).ToList().Take(soPhongDat.Value).Select(c => new { sophong = c.SoPhong, sotang = c.SoTang, id = c.ID, check = true });

                if(loaiphong != datphongItem.LOAIPHONG.ID)
                {
                    var danhsachphong = db.PHONGs.Where(x => x.LOAIPHONG.ID == loaiphong && x.LOAITINHTRANG.ID != 2).OrderBy(c => c.ID).ToList().Select(c => new { sophong = c.SoPhong, sotang = c.SoTang, id = c.ID, check = false }).ToList();
                    var danhsachphongResult = danhsachphongChecked.Concat(danhsachphong);
                    var result = new { data = danhsachphongResult };
                    return Json(result);

                }
                else
                {
                    var danhsachphong = db.PHONGs.Where(x => x.LOAIPHONG.ID == loaiphong && x.LOAITINHTRANG.ID != 2).OrderBy(c => c.ID).ToList().Skip(soPhongDat.Value).Select(c => new { sophong = c.SoPhong, sotang = c.SoTang, id = c.ID, check = false }).ToList();
                    var danhsachphongResult = danhsachphongChecked.Concat(danhsachphong);
                    var result = new { data = danhsachphongResult };
                    return Json(result);

                }
            }
        }

        public ActionResult _AddNewSuDungDichVu(int? dichvu = 0, int? thuephong = 0, int? phong = 0)
        {
            var model = new SuDungDichVuModel();
            if(dichvu != 0 && phong !=0)
            {
                var itemThue = db.THUEPHONGs.Find(thuephong);
                var itemChiTietThue = db.CHITIETTHUEPHONGs.Where(c => c.THUEPHONG.ID == thuephong && c.PHONG.ID == phong).FirstOrDefault();
                var itemChiTietDichVu = itemChiTietThue.SUDUNGDICHVUs.Where(c => c.DICHVU.ID == dichvu).FirstOrDefault();
                model.SoLuong = itemChiTietDichVu.SoLuong;
                model.DICHVU_ID = itemChiTietDichVu.DICHVU_ID;
                model.PHONG_ID = itemChiTietDichVu.CHITIETTHUEPHONG.PHONG.ID;
                model.ThoiGianSuDung = itemChiTietDichVu.ThoiGianSuDung;
                model.DonGia = itemChiTietDichVu.DonGia;
                model.DanhSachPhong = _phongServices.PrepareSelectListPhongForThuePhong(thuephong, phong);
                model.DanhSachDichVu = _dichVuServices.PrepareSelectListDichVu(dichvu);
                model.ThanhTien = itemChiTietDichVu.DonGia * itemChiTietDichVu.SoLuong;
            }
            else
            {
                var itemThue = db.THUEPHONGs.Find(thuephong);
                model.DanhSachDichVu = _dichVuServices.PrepareSelectListDichVu(0);
                model.DanhSachPhong = _phongServices.PrepareSelectListPhongForThuePhong(itemThue.ID, 0);

            }

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditDichVu(SuDungDichVuModel dichvu)
        {
            return Content("");
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