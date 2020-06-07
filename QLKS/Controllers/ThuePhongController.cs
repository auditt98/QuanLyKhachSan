using Microsoft.Ajax.Utilities;
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
    public class ThuePhongController : Controller
    {
        // GET: ThuePhong
        QLKSContext db = new QLKSContext();
        LoaiPhongServices _loaiPhongServices = new LoaiPhongServices();
        PhongServices _phongServices = new PhongServices();
        public ActionResult List()
        {
            return View();
        }

        public ActionResult Create()
        {
            var model = new ThuePhongModel();
            var maxId = db.THUEPHONGs.Select(c => c.ID).DefaultIfEmpty(-1).Max();
            var newId = (maxId + 1).ToString().PadLeft(7, '0');
            model.ma = "TP" + "-" + newId;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ThuePhongModel model)
        {
            return Json(model);
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult _AddNewChiTietThue(int? loaiphong, int? phong)
        {
            var model = new ChiTietThuePhongModel();
            model.DanhSachLoaiPhong = _loaiPhongServices.PrepareSelectListLoaiPhong(0);
            model.DanhSachPhong = _phongServices.PrepareSelectListPhong(0);
            return PartialView(model);
        }
    }
}