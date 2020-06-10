using AutoMapper;
using QLKS.Domain;
using QLKS.Models;
using QLKS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKS.Controllers
{
    public class NhomNguoiDungController : Controller
    {
        // GET: NhomNguoiDung
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
        public ActionResult PopulateNhomNguoiDung()
        {
            var danhSachNhomNguoiDung = db.NHOMNGUOIDUNGs.Select(c => new
            {
                ma = c.ma,
                ten = c.ten,
                uid = c.ID
            }).OrderBy(c => c.uid).ToList();
            var result = new { data = danhSachNhomNguoiDung };
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
            var nhomNguoiDungModel = new NhomNguoiDungModel();
            var maxId = db.NHOMNGUOIDUNGs.Select(c => c.ID).DefaultIfEmpty(0).Max();
            var newId = (maxId + 1).ToString().PadLeft(7, '0');
            nhomNguoiDungModel.ma = "NHOM" + "-" + newId;
            return View(nhomNguoiDungModel);
        }

        [HttpPost]
        public ActionResult Create(NhomNguoiDungModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Có lỗi xảy ra! Vui lòng kiểm tra lại thông tin.";
                TempData["NotiType"] = "success"; //success là class trong bootstrap
                return View("Create", model);
            }
            var nhomNguoiDung = AutoMapper.Mapper.Map<NHOMNGUOIDUNG>(model);
            db.NHOMNGUOIDUNGs.Add(nhomNguoiDung);
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
            var nhomNguoiDung = db.NHOMNGUOIDUNGs.Find(id);
            if (nhomNguoiDung == null)
            {
                TempData["Message"] = "Không tìm thấy nhóm người dùng này";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("List");
            }
            //prepare model
            var nhomNguoiDungModel = AutoMapper.Mapper.Map<NhomNguoiDungModel>(nhomNguoiDung);
            return View(nhomNguoiDungModel);
        }

        [HttpPost]
        public ActionResult Edit(NhomNguoiDungModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Có lỗi xảy ra! Vui lòng kiểm tra lại thông tin.";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return View("Edit", model);
            }
            var item = db.NHOMNGUOIDUNGs.Where(c => c.ID == model.ID).FirstOrDefault();
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
            var nhomnguoidung = db.NHOMNGUOIDUNGs.Find(id);
            db.NHOMNGUOIDUNGs.Remove(nhomnguoidung);
            db.SaveChangesAsync();
            //Thông báo
            TempData["Message"] = "Xóa thành công";
            TempData["NotiType"] = "success"; //success là class trong bootstrap
            return Json("ok");
        }

    }
}