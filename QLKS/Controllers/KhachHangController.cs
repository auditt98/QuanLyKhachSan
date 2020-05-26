using AutoMapper;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using QLKS.Domain;
using QLKS.Models;
using QLKS.Services;
using QLKS.Validators;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKS.Controllers
{
    public class KhachHangController : Controller
    {
        private QLKSContext db = new QLKSContext();

        // GET: LoaiPhong/List
        public ActionResult List()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult PopulateKhachHang()
        {
            var danhSachKhachHang = db.KHACHHANGs.Select(c => new
            {
                Ma = c.ma.ToString(),
                Ten = c.tenkhachhang.ToString(),
                CMT = c.socmt.ToString(),
                SDT = c.sodienthoai.ToString(),
                Email = c.email.ToString()
            }).ToList();

            var result = new { data = danhSachKhachHang };
            var json = JsonConvert.SerializeObject(result);
            return Json(json);
        }

        public ActionResult Create()
        {

            var khachHangModel = new KhachHangModel();
            var maxId = db.KHACHHANGs.Max(c => c.ID);
            var newId = (maxId + 1).ToString().PadLeft(7, '0');
            khachHangModel.ma = "KH" + "-" + newId;
            return View(khachHangModel);
        }

        [HttpPost]
        public ActionResult Create(KhachHangModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", model);
            }
            var khachhang = AutoMapper.Mapper.Map<KHACHHANG>(model);
            db.KHACHHANGs.Add(khachhang);
            db.SaveChangesAsync();
            TempData["ThongBao"] = "Thêm mới thành công";
            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(KhachHangModel model)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            return View();
        }
    
    }
}