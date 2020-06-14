using AutoMapper;
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
    public class DatPhongController : Controller
    {
        // GET: DatPhong
        private QLKSContext db = new QLKSContext();
        private NguoiDungServices _nguoiDungServices = new NguoiDungServices();
        private LichSuServices _lichSuServices = new LichSuServices();
        private QuyenServices _quyenServices = new QuyenServices();
        private PhongServices _phongServices = new PhongServices();
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

        [HttpPost]
        public JsonResult PopulateDatPhong()
        {
            var danhSachDatPhong = db.CHITIETDATPHONGs.Select(c => new
            {
                madatphong = c.DATPHONG_ID,
                maphong = c.PHONG.ma,
                idphong = c.PHONG_ID,
                tenloaiphong = c.PHONG.LOAIPHONG.tenloaiphong,
                tenkhachhang = c.tenkhachhang,
                sdtkhachhang = c.sodienthoai,
                emailkhachhang = c.email,
                cmtkhachhang = c.socmt,
                dukienden = c.ngaydukienden,
                dukiendi = c.ngaydukiendi,


            }).OrderByDescending(c => c.madatphong).ToList();
            var result = new { data = danhSachDatPhong };
            return Json(result,JsonRequestBehavior.AllowGet);
        }


        // GET: DatPhong/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DatPhong/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DatPhong/Edit/5
        public ActionResult Edit(int? iddatphong ,int? idphong)
        {
            if (!_nguoiDungServices.isLoggedIn())
            {
                TempData["Message"] = "Bạn chưa đăng nhập, vui lòng đăng nhập";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("Login", "NguoiDung");
            }
            if (!_quyenServices.Authorize((int)EnumQuyen.DATPHONG_SUA))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            if (iddatphong == null || idphong == null)
            {
                return RedirectToAction("List");
            }
            var chiTietDatPhong = db.CHITIETDATPHONGs.Where(p=>p.DATPHONG_ID==iddatphong && p.PHONG_ID == idphong).FirstOrDefault();
            if (chiTietDatPhong == null)
            {
                TempData["Message"] = "Không tìm thấy phòng này";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("List");
            }
            //prepare model
            var chiTietDatPhongModel = new DatPhongModel();
            chiTietDatPhongModel.PHONG_ID = chiTietDatPhong.PHONG_ID;
            chiTietDatPhongModel.DATPHONG_ID = chiTietDatPhong.DATPHONG_ID;
            chiTietDatPhongModel.tenkhachhang = chiTietDatPhong.tenkhachhang;
            chiTietDatPhongModel.socmt = chiTietDatPhong.socmt;
            chiTietDatPhongModel.sodienthoai = chiTietDatPhong.sodienthoai;
            chiTietDatPhongModel.email = chiTietDatPhong.email;
            chiTietDatPhongModel.ngaydukienden = chiTietDatPhong.ngaydukienden;
            chiTietDatPhongModel.ngaydukiendi = chiTietDatPhong.ngaydukiendi;
            chiTietDatPhongModel.DanhSachPhong = _phongServices.PrepareSelectListPhong(chiTietDatPhong.PHONG_ID);


            return View(chiTietDatPhongModel);
        }

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
               
                var item = db.CHITIETDATPHONGs.Where(c => c.DATPHONG_ID == model.DATPHONG_ID && c.PHONG_ID==model.PHONG_ID).FirstOrDefault();
                if (item == null)
                {
                    TempData["Message"] = "Có lỗi xảy ra";
                    TempData["NotiType"] = "danger"; //success là class trong bootstrap
                    return RedirectToAction("List");
                }

                item.tenkhachhang = model.tenkhachhang;
                item.socmt = model.socmt;
                item.sodienthoai = model.sodienthoai;
                item.email = model.email;
                item.ngaydukienden = model.ngaydukienden;
                item.ngaydukiendi = model.ngaydukiendi;
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

        // GET: DatPhong/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DatPhong/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
