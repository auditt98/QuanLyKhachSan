using AutoMapper;
using Newtonsoft.Json;
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
    public class DichVuController : Controller
    {
        private QLKSContext db = new QLKSContext();
        private NguoiDungServices _nguoiDungServices = new NguoiDungServices();
        private LichSuServices _lichSuServices = new LichSuServices();
        private QuyenServices _quyenServices = new QuyenServices();
        // GET: DichVu/List
        public ActionResult List()
        {
            if (!_nguoiDungServices.isLoggedIn())
            {
                TempData["Message"] = "Bạn chưa đăng nhập, vui lòng đăng nhập";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("Login", "NguoiDung");
            }
            if (!_quyenServices.Authorize((int)EnumQuyen.DICHVU_XEM))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            return View();
        }

        [HttpPost]
        public ActionResult PopulateDichVu()
        {
            var danhSachDichVu= db.DICHVUs.Select(c => new
            {
                ma = c.ma,
                tendichvu = c.tendichvu,
                dongia = c.dongia,
                uid = c.ID
            }).OrderBy(c => c.uid).ToList();
            var result = new { data = danhSachDichVu };
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
            if (!_quyenServices.Authorize((int)EnumQuyen.DICHVU_THEM))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            var dichVuModel = new DichVuModel();
            var maxId = db.DICHVUs.Select(c => c.ID).DefaultIfEmpty(0).Max();
            var newId = (maxId + 1).ToString().PadLeft(7, '0');
            dichVuModel.ma = "DV" + "-" + newId;
            return View(dichVuModel);
        }

        [HttpPost]
        public ActionResult Create(DichVuModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Có lỗi xảy ra! Vui lòng kiểm tra lại thông tin.";
                TempData["NotiType"] = "success"; //success là class trong bootstrap
                return View("Create", model);
            }
            var item = AutoMapper.Mapper.Map<DICHVU>(model);
            db.DICHVUs.Add(item);
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
            if (!_quyenServices.Authorize((int)EnumQuyen.DICHVU_SUA))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            if (id == null)
            {
                return RedirectToAction("List");
            }
            var dichvu = db.DICHVUs.Find(id);
            if (dichvu == null)
            {
                TempData["Message"] = "Không tìm thấy dịch vụ này";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("List");
            }
            //prepare model
            var dichVuModel = AutoMapper.Mapper.Map<DichVuModel>(dichvu);
            return View(dichVuModel);
        }

        [HttpPost]
        public ActionResult Edit(DichVuModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Có lỗi xảy ra! Vui lòng kiểm tra lại thông tin.";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return View("Edit", model);
            }
            var item = db.DICHVUs.Where(c => c.ID == model.ID).FirstOrDefault();
            if (item == null)
            {
                TempData["Message"] = "Có lỗi xảy ra";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("List");
            }
            //map from model to database object
            item = Mapper.Map(model, item);
            db.SaveChanges();
            _lichSuServices.LuuLichSu((int)Session["ID"], (int)EnumLoaiHanhDong.SUA, item.GetType().ToString());
            TempData["Message"] = "Cập nhật thành công";
            TempData["NotiType"] = "success"; //success là class trong bootstrap
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (!_nguoiDungServices.isLoggedIn())
            {
                TempData["Message"] = "Bạn chưa đăng nhập, vui lòng đăng nhập";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("Login", "NguoiDung");
            }
            if (!_quyenServices.Authorize((int)EnumQuyen.DICHVU_XOA))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            var item = db.DICHVUs.Find(id);
            db.DICHVUs.Remove(item);
            db.SaveChanges();
            _lichSuServices.LuuLichSu((int)Session["ID"], (int)EnumLoaiHanhDong.XOA, item.GetType().ToString());
            //Thông báo
            TempData["Message"] = "Xóa thành công";
            TempData["NotiType"] = "success"; //success là class trong bootstrap
            return Json("ok");
        }

        [HttpPost]
        public ActionResult GetGiaDichVu(int? dichvu)
        {
            var item = db.DICHVUs.Find(dichvu);
            return Json(item.dongia);
        }

        [HttpPost]
        public ActionResult CheckQuyen()
        {
            if (!_quyenServices.Authorize((int)EnumQuyen.DICHVU_XEM))
            {
                return Json("no");
            }
            return Json("yes");
        }
    }
}