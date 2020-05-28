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

        public ActionResult Create()
        {
            var dichVuModel = new DichVuModel();
            var maxId = db.KHACHHANGs.Select(c => c.ID).DefaultIfEmpty(-1).Max();
            var newId = (maxId + 1).ToString().PadLeft(7, '0');
            dichVuModel.ma = "DV" + "-" + newId;
            ViewBag["Route"] = "DichVu";
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
    }
}