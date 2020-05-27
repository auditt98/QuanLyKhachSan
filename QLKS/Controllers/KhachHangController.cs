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
                ma = c.ma,
                ten = c.tenkhachhang,
                cmt = c.socmt,
                sdt = c.sodienthoai,
                email = c.email,
                uid = c.ID
            }).ToList();
            var result = new { data = danhSachKhachHang };
            return Json(result);
        }

        public ActionResult Create()
        {

            var khachHangModel = new KhachHangModel();
            var maxId = db.KHACHHANGs.Select(c => c.ID).DefaultIfEmpty(-1).Max();
            var newId = (maxId + 1).ToString().PadLeft(7, '0');
            khachHangModel.ma = "KH" + "-" + newId;
            return View(khachHangModel);
        }

        [HttpPost]
        public ActionResult Create(KhachHangModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Có lỗi xảy ra! Vui lòng kiểm tra lại thông tin.";
                TempData["NotiType"] = "success"; //success là class trong bootstrap
                return View("Create", model);
            }
            var khachhang = AutoMapper.Mapper.Map<KHACHHANG>(model);
            db.KHACHHANGs.Add(khachhang);
            db.SaveChangesAsync();
            TempData["Message"] = "Thêm mới thành công";
            TempData["NotiType"] = "success";
            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var khachhang = db.KHACHHANGs.Find(id);
            if(khachhang == null)
            {
                return RedirectToAction("List");
            }
            //prepare model
            var khachhangModel = AutoMapper.Mapper.Map<KhachHangModel>(khachhang);
            return View(khachhangModel);
        }

        [HttpPost]
        public ActionResult Edit(KhachHangModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Có lỗi xảy ra! Vui lòng kiểm tra lại thông tin.";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return View("Edit", model);
            }
            var item = db.KHACHHANGs.Where(c => c.ID == model.ID).FirstOrDefault();
            if(item == null)
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
            var khachhang = db.KHACHHANGs.Find(id);
            db.KHACHHANGs.Remove(khachhang);
            db.SaveChangesAsync();
            //Thông báo
            TempData["Message"] = "Xóa khách hàng thành công";
            TempData["NotiType"] = "success"; //success là class trong bootstrap
            return Json("ok");
        }
    
    }
}