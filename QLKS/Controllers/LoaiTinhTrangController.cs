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
using QLKS.Services;
using static QLKS.Extensions.Enum;
using System.Data.SqlClient;

namespace QLKS.Controllers
{
    public class LoaiTinhTrangController : Controller
    {
        private QLKSContext db = new QLKSContext();
        private NguoiDungServices _nguoiDungServices = new NguoiDungServices();
        private QuyenServices _quyenServices = new QuyenServices();
        private LichSuServices _lichSuServices = new LichSuServices();

        // GET: LoaiTinhTrang/List
        public ActionResult List()
        {
            if (!_nguoiDungServices.isLoggedIn())
            {
                TempData["Message"] = "Bạn chưa đăng nhập, vui lòng đăng nhập";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("Login", "NguoiDung");
            }
            if (!_quyenServices.Authorize((int)EnumQuyen.LOAITINHTRANG_XEM))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            return View();
        }

        [HttpPost]
        public ActionResult PopulateLoaiTinhTrang()
        {
            var danhsachloaitinhtrang = db.LOAITINHTRANGs.Select(c => new
            {
                ma = c.Ma,
                ten = c.Ten,
                uid = c.ID
            }).OrderBy(c => c.uid).ToList();
            var result = new { data = danhsachloaitinhtrang };
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
            if (!_quyenServices.Authorize((int)EnumQuyen.LOAITINHTRANG_THEM))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }

            var loaiTinhTrangModel = new LoaiTinhTrangModel();
            var maxId = db.LOAITINHTRANGs.Select(c => c.ID).DefaultIfEmpty(0).Max();
            var newId = (maxId + 1).ToString().PadLeft(7, '0');
            loaiTinhTrangModel.Ma = "TT" + "-" + newId;
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
            if (!_quyenServices.Authorize((int)EnumQuyen.LOAITINHTRANG_THEM))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            var item = AutoMapper.Mapper.Map<LOAITINHTRANG>(model);
            int a = 0;
            db.Database.ExecuteSqlCommand("exec SP_CreateOrUpdate_LOAITINHTRANG @Type, @ID, @Ma, @Ten, @UpdateID", new SqlParameter("@Type", int.Parse("0")), new SqlParameter("@ID", a), new SqlParameter("@Ten", item.Ten), new SqlParameter("@Ma", item.Ma), new SqlParameter("@UpdateID", int.Parse("0")));

            //db.LOAITINHTRANGs.Add(loaitinhtrang);
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
            if (!_quyenServices.Authorize((int)EnumQuyen.LOAITINHTRANG_SUA))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            if (id == null)
            {
                return RedirectToAction("List");
            }
            var loaitinhtrang = db.LOAITINHTRANGs.Find(id);

            if (loaitinhtrang == null)
            {
                TempData["Message"] = "Không tìm thấy tình trạng này";
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
            if (!_quyenServices.Authorize((int)EnumQuyen.LOAITINHTRANG_SUA))
            {
                TempData["Message"] = "Bạn không có quyền thực hiện chức năng này";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("ViewDenied", "QLKS");
            }
            var item = db.LOAITINHTRANGs.Where(c => c.ID == model.ID).FirstOrDefault();
            if (item == null)
            {
                TempData["Message"] = "Có lỗi xảy ra";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("List");
            }
            ////map from model to database object
            //item = Mapper.Map(model, item);
            int a = 0;
            a = db.Database.ExecuteSqlCommand("exec SP_CreateOrUpdate_LOAITINHTRANG @Type, @ID, @Ma, @Ten, @UpdateID", new SqlParameter("@Type", int.Parse("1")), new SqlParameter("@ID", a), new SqlParameter("@Ten", model.Ten), new SqlParameter("@Ma", model.Ma), new SqlParameter("@UpdateID", item.ID));

            db.SaveChanges();
            _lichSuServices.LuuLichSu((int)Session["ID"], (int)EnumLoaiHanhDong.SUA, item.GetType().ToString());
            TempData["Message"] = "Cập nhật thành công";
            TempData["NotiType"] = "success"; //success là class trong bootstrap
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (!_quyenServices.Authorize((int)EnumQuyen.LOAITINHTRANG_XOA))
            {
                return RedirectToAction("ViewDenied", "QLKS");
            }
            var item = db.LOAITINHTRANGs.Find(id);
            if (item != null)
            {
                int a = 0;
                a = db.Database.ExecuteSqlCommand("exec SP_Delete_LOAITINHTRANG @ID", new SqlParameter("@ID", item.ID));

                //db.LOAITINHTRANGs.Remove(loaitinhtrang);
                _lichSuServices.LuuLichSu((int)Session["ID"], (int)EnumLoaiHanhDong.XOA, item.GetType().ToString());
                db.SaveChanges();
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

        [HttpPost]
        public ActionResult CheckQuyen()
        {
            if (!_quyenServices.Authorize((int)EnumQuyen.LOAITINHTRANG_XEM))
            {
                return Json("no");
            }
            return Json("yes");
        }

    }
}