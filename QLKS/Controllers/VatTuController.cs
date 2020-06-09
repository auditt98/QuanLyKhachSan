using QLKS.Domain;
using QLKS.Models;
using QLKS.Services;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using static QLKS.Extensions.Enum;

namespace QLKS.Controllers
{
    public class VatTuController : Controller
    {
        // GET: VatTu
        private QLKSContext db = new QLKSContext();
        private PhongServices _phongServices = new PhongServices();

        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PopulateVatTu()
        {
            var allVatTu = db.VATTUs.ToList();
            var danhSachVatTu = allVatTu.Select(c => new
            {
                ten = c.ten,
                ngaymua = c.ngaymua,
                ngaysudung = c.ngaysudung,
                gia = c.sotien,
                phong = c.PHONG.ma,
                soluong = c.soluong,
                uid = c.ID
            }).OrderBy(c => c.uid).ToList();

            var result = new { data = danhSachVatTu };
            return Json(result);
        }

        public ActionResult Create()
        {
            var vatTuModel = new VatTuModel();
            //prepare select list phong
            vatTuModel.DanhSachPhong = _phongServices.PrepareSelectListPhong(-1);
            //phongModel.DanhSachLoaiPhong = _loaiPhongServices.PrepareSelectListLoaiPhong(-1);
            return View(vatTuModel);
        }

        [HttpPost]
        public ActionResult Create(VatTuModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Có lỗi xảy ra! Vui lòng kiểm tra lại thông tin.";
                TempData["NotiType"] = "success"; //success là class trong bootstrap
                return View("Create", model);
            }
            var vattu = AutoMapper.Mapper.Map<VATTU>(model);
            db.VATTUs.Add(vattu);
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
            var vattu = db.VATTUs.Find(id);
            if (vattu == null)
            {
                TempData["Message"] = "Không tìm thấy vật tư này";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("List");
            }
            //prepare model
            var vatTuModel = AutoMapper.Mapper.Map<VatTuModel>(vattu);
            //get danhsachphong
            vatTuModel.DanhSachPhong = _phongServices.PrepareSelectListPhong(vattu.PHONG_ID);
            return View(vatTuModel);
        }

        [HttpPost]
        public ActionResult Edit(VatTuModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Có lỗi xảy ra! Vui lòng kiểm tra lại thông tin.";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return View("Edit", model);
            }
            var item = db.VATTUs.Where(c => c.ID == model.ID).FirstOrDefault();
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
            var vattu = db.VATTUs.Find(id);
            if (vattu != null)
            {
                db.VATTUs.Remove(vattu);
                db.SaveChangesAsync();
                //Thông báo
                TempData["Message"] = "Xóa vật tư thành công";
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