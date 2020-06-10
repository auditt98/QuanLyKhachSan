using AutoMapper;
using QLKS.Domain;
using QLKS.Models;
using QLKS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static QLKS.Extensions.Enum;

namespace QLKS.Controllers
{
    public class NhomNguoiDungController : Controller
    {
        // GET: NhomNguoiDung
        private QLKSContext db = new QLKSContext();
        private NguoiDungServices _nguoiDungServices = new NguoiDungServices();
        private QuyenServices _quyenServices = new QuyenServices();
        public ActionResult List()
        {
            if (!_nguoiDungServices.isLoggedIn())
            {
                TempData["Message"] = "Bạn chưa đăng nhập, vui lòng đăng nhập";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("Login", "NguoiDung");
            }
            if (!_quyenServices.Authorize1(db,(int)EnumQuyen.NHOMNGUOIDUNG_XEM))
            {
                return RedirectToAction("ViewDenied", "QLKS");
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
            if (!_quyenServices.Authorize((int)EnumQuyen.NHOMNGUOIDUNG_THEM))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            var model = new NhomNguoiDungModel();
            var maxId = db.NHOMNGUOIDUNGs.Select(c => c.ID).DefaultIfEmpty(0).Max();
            var newId = (maxId + 1).ToString().PadLeft(7, '0');
            model.ma = "NHOM" + "-" + newId;
            var allQuyen = _quyenServices.GetAllQuyen(new List<int>()).ToList();
            model.DanhSachQuyen = allQuyen;
            return View(model);
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
            if (!_quyenServices.Authorize((int)EnumQuyen.NHOMNGUOIDUNG_THEM))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            var nhomNguoiDung = AutoMapper.Mapper.Map<NHOMNGUOIDUNG>(model);
            db.NHOMNGUOIDUNGs.Add(nhomNguoiDung);
            if(model.SelectedQuyens != null)
            {
                if(model.SelectedQuyens.Count > 0)
                {
                    foreach (var quyen in model.SelectedQuyens)
                    {
                        var i = db.QUYENs.Find(quyen);
                        nhomNguoiDung.QUYENs.Add(i);
                    }
                }
            }
            db.SaveChanges();
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

            if (!_quyenServices.Authorize((int)EnumQuyen.NHOMNGUOIDUNG_SUA))
            {
                return RedirectToAction("ViewDenied", "QLKS");
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
            var listQuyen = nhomNguoiDung.QUYENs.Select(c => c.ID).ToList();
            //prepare model
            var model = new NhomNguoiDungModel();
            model.ID = nhomNguoiDung.ID;
            model.ma = nhomNguoiDung.ma;
            model.SelectedQuyens = nhomNguoiDung.QUYENs.Select(c => c.ID).ToList();
            model.ten = nhomNguoiDung.ten;
            //var nhomNguoiDungModel = AutoMapper.Mapper.Map<NhomNguoiDungModel>(nhomNguoiDung);
            var allQuyen = _quyenServices.GetAllQuyen(listQuyen).ToList();
            model.DanhSachQuyen = allQuyen;
            return View(model);
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
            if (!_quyenServices.Authorize((int)EnumQuyen.NHOMNGUOIDUNG_SUA))
            {
                return RedirectToAction("ViewDenied", "QLKS");
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
            item.ID = model.ID.Value;
            item.QUYENs.Clear();
            if (model.SelectedQuyens != null)
            {
                if (model.SelectedQuyens.Count > 0)
                {
                    foreach (var quyen in model.SelectedQuyens)
                    {
                        var i = db.QUYENs.Find(quyen);
                        item.QUYENs.Add(i);
                    }
                }
            }
            db.SaveChanges();
            TempData["Message"] = "Cập nhật thành công";
            TempData["NotiType"] = "success"; //success là class trong bootstrap
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (!_quyenServices.Authorize((int)EnumQuyen.NHOMNGUOIDUNG_XOA))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            var nhomnguoidung = db.NHOMNGUOIDUNGs.Find(id);
            db.NHOMNGUOIDUNGs.Remove(nhomnguoidung);
            db.SaveChanges();
            //Thông báo
            TempData["Message"] = "Xóa thành công";
            TempData["NotiType"] = "success"; //success là class trong bootstrap
            return Json("ok");
        }

    }
}