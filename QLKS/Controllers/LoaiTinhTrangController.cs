using AutoMapper;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using QLKS.Domain;
using QLKS.Models;
using QLKS.Validators;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKS.Controllers
{
    public class LoaiTinhTrangController : Controller
    {
        private QLKSContext db = new QLKSContext();

        // GET: LoaiTinhTrang/List
        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PopulateLoaiTinhTrang()
        {
            var danhsachloaitinhtrang = db.LOAITINHTRANGs.Select(c => new
            {
                ma = c.ma,
                ten = c.ten,
                uid = c.ID
            }).OrderBy(c => c.uid).ToList();
            var result = new { data = danhsachloaitinhtrang };
            return Json(result);
        }

        public ActionResult Create()
        {
            var loaiTinhTrangModel = new LoaiTinhTrangModel();
            var maxId = db.LOAITINHTRANGs.Select(c => c.ID).DefaultIfEmpty(-1).Max();
            var newId = (maxId + 1).ToString().PadLeft(7, '0');
            loaiTinhTrangModel.ma = "TT" + "-" + newId;
            return View(loaiTinhTrangModel);
        }

        [HttpPost]
        public ActionResult Create(LoaiTinhTrangModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Có lỗi xảy ra! Vui lòng kiểm tra lại thông tin.";
                TempData["NotiType"] = "success"; //success là class trong bootstrap
                return View("Create", model);
            }
            var loaitinhtrang = AutoMapper.Mapper.Map<LOAITINHTRANG>(model);
            db.LOAITINHTRANGs.Add(loaitinhtrang);
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
            var loaitinhtrang = db.LOAITINHTRANGs.Find(id);
            if (loaitinhtrang == null)
            {
                TempData["Message"] = "Không tìm thấy khách hàng này";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("List");
            }
            //prepare model
            var loaiTinhTrangModel = AutoMapper.Mapper.Map<LoaiTinhTrangModel>(loaitinhtrang);
            return View(loaiTinhTrangModel);
        }

        [HttpPost]
        public ActionResult Edit(LoaiTinhTrangModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Có lỗi xảy ra! Vui lòng kiểm tra lại thông tin.";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return View("Edit", model);
            }
            var item = db.LOAITINHTRANGs.Where(c => c.ID == model.ID).FirstOrDefault();
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
            var loaitinhtrang = db.LOAITINHTRANGs.Find(id);
            if (loaitinhtrang != null)
            {
                db.LOAITINHTRANGs.Remove(loaitinhtrang);
                db.SaveChangesAsync();
                //Thông báo
                TempData["Message"] = "Xóa khách hàng thành công";
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

    }
}