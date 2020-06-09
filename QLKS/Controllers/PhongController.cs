using AutoMapper;
using QLKS.Domain;
using QLKS.Models;
using QLKS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using static QLKS.Extensions.Enum;

namespace QLKS.Controllers
{
    public class PhongController : Controller
    {
        // GET: Phong
        private QLKSContext db = new QLKSContext();
        private LoaiPhongServices _loaiPhongServices = new LoaiPhongServices();
        private PhongServices _phongServices = new PhongServices();
        private LoaiTinhTrangServices _loaiTinhTrangServices = new LoaiTinhTrangServices();

        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PopulatePhong()
        {
            var allPhong = db.PHONGs.ToList();
            var danhSachPhong = allPhong.Select(c => new
            {
                ma = c.ma,
                tenloaiphong = c.LOAIPHONG.tenloaiphong,
                gia = c.giathue,
                sotang = c.sotang,
                uid = c.ID
            }).OrderBy(c => c.uid).ToList();

            var result = new { data = danhSachPhong };
            return Json(result);
        }

        [HttpPost]
        public ActionResult GetPhongTrongFromLoaiPhong(int loaiphong)
        {
            var items = _phongServices.GetPhongTrongFromLoaiPhong(loaiphong);
            var result = new List<PhongModel>();
            foreach(var item in items)
            {
                var m = Mapper.Map(item, new PhongModel());
                result.Add(m);
            }
            return Json(result);
        }

        public ActionResult Create()
        {
            var phongModel = new PhongModel();
            var maxId = db.PHONGs.Select(c => c.ID).DefaultIfEmpty(0).Max();
            var newId = (maxId + 1).ToString().PadLeft(4, '0');
            phongModel.ma = "P" + " " + newId;
            phongModel.DanhSachLoaiPhong = _loaiPhongServices.PrepareSelectListLoaiPhong(0);
            phongModel.DanhSachTinhTrang = _loaiTinhTrangServices.PrepareLoaiTinhTrangPhong(0);
            return View(phongModel);
        }

        [HttpPost]
        public ActionResult Create(PhongModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Có lỗi xảy ra! Vui lòng kiểm tra lại thông tin.";
                TempData["NotiType"] = "success"; //success là class trong bootstrap
                return View("Create", model);
            }
            var phong = AutoMapper.Mapper.Map<PHONG>(model);
            db.PHONGs.Add(phong);
            db.SaveChangesAsync();
            TempData["Message"] = "Thêm mới thành công";
            TempData["NotiType"] = "success";
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("List");
            }
            var phong = db.PHONGs.Find(id);
            if (phong == null)
            {
                TempData["Message"] = "Không tìm thấy phòng này";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("List");
            }
            //prepare model
            var phongModel = AutoMapper.Mapper.Map<PhongModel>(phong);
            phongModel.DanhSachLoaiPhong = _loaiPhongServices.PrepareSelectListLoaiPhong(phong.ID);
            phongModel.DanhSachTinhTrang = _loaiTinhTrangServices.PrepareLoaiTinhTrangPhong(phong.LOAITINHTRANG_ID);

            return View(phongModel);
        }

        [HttpPost]
        public ActionResult Edit(PhongModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Có lỗi xảy ra! Vui lòng kiểm tra lại thông tin.";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return View("Edit", model);
            }
            var item = db.PHONGs.Where(c => c.ID == model.ID).FirstOrDefault();
            if (item == null)
            {
                TempData["Message"] = "Có lỗi xảy ra";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("List");
            }
            //map from model to database object
            item = Mapper.Map(model, item);
            db.SaveChangesAsync();
            TempData["Message"] = "Cập nhật thành công";
            TempData["NotiType"] = "success"; //success là class trong bootstrap
            return RedirectToAction("List");
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            var phong = db.PHONGs.Find(id);
            if (phong != null)
            {
                db.PHONGs.Remove(phong);
                db.SaveChangesAsync();
                //Thông báo
                TempData["Message"] = "Xóa phòng thành công";
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
        public ActionResult ThongKePhong()
        {
            var phongtrong = db.PHONGs.Where(x => x.LOAITINHTRANG_ID == (int)EnumLoaiTinhTrang.TRONG).Count();
            var phongdattruoc = db.PHONGs.Where(x => x.LOAITINHTRANG_ID== (int)EnumLoaiTinhTrang.DATTRUOC).Count();
            var phongban = db.PHONGs.Where(x => x.LOAITINHTRANG_ID == (int)EnumLoaiTinhTrang.BAN).Count();
            var phongdangsudung = db.PHONGs.Where(x => x.LOAITINHTRANG_ID == (int)EnumLoaiTinhTrang.DATHUE).Count();

            var result = new { phongtrong = phongtrong, phongban = phongban, phongdattruoc = phongdattruoc, phongdangsudung = phongdangsudung };
            var r = Json(result);
            return r;
        }

        [HttpPost]
        public ActionResult GetGiaPhong(int? phong)
        {
            var gia = db.PHONGs.Where(c => c.ID == phong).FirstOrDefault();
            if(gia == null)
            {
                return Json(0);
            }
            return Json(gia.giathue) ;
        }


    }
}