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
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace QLKS.Controllers
{
    public class VatTuController : Controller
    {
        // GET: VatTu
        private QLKSContext db = new QLKSContext();
        private PhongServices _phongServices = new PhongServices();
        private NguoiDungServices _nguoiDungServices = new NguoiDungServices();
        private LichSuServices _lichSuServices = new LichSuServices();
        private QuyenServices _quyenServices = new QuyenServices();
        public ActionResult List()
        {
            if (!_nguoiDungServices.isLoggedIn())
            {
                TempData["Message"] = "Bạn chưa đăng nhập, vui lòng đăng nhập";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("Login", "NguoiDung");
            }
            if (!_quyenServices.Authorize((int)EnumQuyen.VATTU_XEM))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
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
            if (!_nguoiDungServices.isLoggedIn())
            {
                TempData["Message"] = "Bạn chưa đăng nhập, vui lòng đăng nhập";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("Login", "NguoiDung");
            }
            if (!_quyenServices.Authorize((int)EnumQuyen.VATTU_THEM))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            var vatTuModel = new VatTuModel();
            //prepare select list phong
            vatTuModel.DanhSachPhong = _phongServices.PrepareSelectListPhong(0);
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
            var item = AutoMapper.Mapper.Map<VATTU>(model);
            db.VATTUs.Add(item);
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
            if (!_quyenServices.Authorize((int)EnumQuyen.VATTU_SUA))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
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
            db.SaveChanges();
            _lichSuServices.LuuLichSu((int)Session["ID"], (int)EnumLoaiHanhDong.SUA, item.GetType().ToString());
            TempData["Message"] = "Cập nhật thành công";
            TempData["NotiType"] = "success"; //success là class trong bootstrap
            return RedirectToAction("List");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (!_quyenServices.Authorize((int)EnumQuyen.VATTU_XOA))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            var item = db.VATTUs.Find(id);
            if (item != null)
            {
                db.VATTUs.Remove(item);
                db.SaveChanges();
                //Thông báo
                _lichSuServices.LuuLichSu((int)Session["ID"], (int)EnumLoaiHanhDong.XOA, item.GetType().ToString());
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

        [HttpPost]
        public ActionResult CheckQuyen()
        {
            if (!_quyenServices.Authorize((int)EnumQuyen.VATTU_XEM))
            {
                return Json("no");
            }
            return Json("yes");
        }
    }
}