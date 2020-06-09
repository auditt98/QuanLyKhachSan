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
    public class DichVuController : Controller
    {
        private QLKSContext db = new QLKSContext();
        // GET: DichVu/List
        public ActionResult List()
        {
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
            var dichvu = AutoMapper.Mapper.Map<DICHVU>(model);
            db.DICHVUs.Add(dichvu);
            db.SaveChangesAsync();
            TempData["Message"] = "Thêm mới thành công";
            TempData["NotiType"] = "success";
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if(id == null)
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
            db.SaveChangesAsync();
            TempData["Message"] = "Cập nhật thành công";
            TempData["NotiType"] = "success"; //success là class trong bootstrap
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var dichvu = db.DICHVUs.Find(id);
            db.DICHVUs.Remove(dichvu);
            db.SaveChangesAsync();
            //Thông báo
            TempData["Message"] = "Xóa thành công";
            TempData["NotiType"] = "success"; //success là class trong bootstrap
            return Json("ok");
        }
    }
}