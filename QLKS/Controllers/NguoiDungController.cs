using AutoMapper;
using QLKS.Domain;
using QLKS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKS.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        private QLKSContext db = new QLKSContext();
        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PopulateNguoiDung()
        {
            var danhSachNguoiDung = db.NGUOIDUNGs.Select(c => new
            {
                tendangnhap = c.tendangnhap,
                ten = c.tennguoidung,
                sdt = c.sodienthoai,
                uid = c.ID
            }).OrderBy(c => c.uid).ToList();
            var result = new { data = danhSachNguoiDung };
            return Json(result);
        }

        public ActionResult Create()
        {
            var nguoiDungModel = new NguoiDungModel();
            return View(nguoiDungModel);
        }

        [HttpPost]
        public ActionResult Create(NguoiDungModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Có lỗi xảy ra! Vui lòng kiểm tra lại thông tin.";
                TempData["NotiType"] = "success"; //success là class trong bootstrap
                return View("Create", model);
            }
            var nguoiDung = AutoMapper.Mapper.Map<NGUOIDUNG>(model);
            db.NGUOIDUNGs.Add(nguoiDung);
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
            var nguoiDung = db.NGUOIDUNGs.Find(id);
            if (nguoiDung == null)
            {
                return RedirectToAction("List");
            }
            //prepare model
            var nguoiDungModel = AutoMapper.Mapper.Map<NguoiDungModel>(nguoiDung);
            return View(nguoiDungModel);
        }

        [HttpPost]
        public ActionResult Edit(NguoiDungModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Có lỗi xảy ra! Vui lòng kiểm tra lại thông tin.";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return View("Edit", model);
            }
            var item = db.NGUOIDUNGs.Where(c => c.ID == model.ID).FirstOrDefault();
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
            var nguoidung = db.NGUOIDUNGs.Find(id);
            db.NGUOIDUNGs.Remove(nguoidung);
            db.SaveChangesAsync();
            //Thông báo
            TempData["Message"] = "Xóa thành công";
            TempData["NotiType"] = "success"; //success là class trong bootstrap
            return Json("ok");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logout()
        {
            return Json("");
        }

    }
}