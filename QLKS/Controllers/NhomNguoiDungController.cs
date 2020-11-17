using AutoMapper;
using QLKS.Domain;
using QLKS.Models;
using QLKS.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        private LichSuServices _lichSuServices = new LichSuServices();

        public ActionResult List()
        {
            if (!_nguoiDungServices.isLoggedIn())
            {
                TempData["Message"] = "Bạn chưa đăng nhập, vui lòng đăng nhập";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("Login", "NguoiDung");
            }
            if (!_quyenServices.Authorize((int)EnumQuyen.NHOMNGUOIDUNG_XEM))
            {
                TempData["Message"] = "Bạn không có quyền thực hiện chức năng này";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("ViewDenied", "QLKS");
            }

            return View();
        }

        [HttpPost]
        public ActionResult PopulateNhomNguoiDung()
        {
            var danhSachNhomNguoiDung = db.NHOMNGUOIDUNGs.Select(c => new
            {
                ma = c.Ma,
                ten = c.Ten,
                uid = c.ID
            }).ToList();
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
                TempData["Message"] = "Bạn không có quyền thực hiện chức năng này";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("ViewDenied", "QLKS");
            }
            var model = new NhomNguoiDungModel();
            var maxId = db.NHOMNGUOIDUNGs.Select(c => c.ID).DefaultIfEmpty(0).Max();
            var newId = (maxId + 1).ToString().PadLeft(4, '0');
            model.Ma = "NHOM" + "-" + newId;
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
                TempData["Message"] = "Bạn không có quyền thực hiện chức năng này";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("ViewDenied", "QLKS");
            }
            var item = AutoMapper.Mapper.Map<NHOMNGUOIDUNG>(model);
            db.NHOMNGUOIDUNGs.Add(item);
            //int a = 0;
            //a = db.Database.ExecuteSqlCommand("exec SP_CreateOrUpdate_NHOMNGUOIDUNG @Type, @ID, @Ten, @Ma, @UpdateID", new SqlParameter("@Type", int.Parse("0")), new SqlParameter("@ID", a), new SqlParameter("@Ten", item.Ten), new SqlParameter("@Ma", item.Ma), new SqlParameter("@UpdateID", int.Parse("0")));
            //var nhomNguoiDung = db.NHOMNGUOIDUNGs.Find(a);

            if (model.SelectedQuyens != null)
            {
                if(model.SelectedQuyens.Count > 0)
                {
                    foreach (var quyen in model.SelectedQuyens)
                    {
                        var i = db.QUYENs.Find(quyen);
                        item.QUYENs.Add(i);
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
                TempData["Message"] = "Bạn không có quyền thực hiện chức năng này";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
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
            model.Ma = nhomNguoiDung.Ma;
            model.SelectedQuyens = nhomNguoiDung.QUYENs.Select(c => c.ID).ToList();
            model.Ten = nhomNguoiDung.Ten;
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
                TempData["Message"] = "Bạn không có quyền thực hiện chức năng này";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("ViewDenied", "QLKS");
            }
            var item = db.NHOMNGUOIDUNGs.Where(c => c.ID == model.ID).FirstOrDefault();
            if (item == null)
            {
                TempData["Message"] = "Có lỗi xảy ra";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("List");
            }
            item.Ten = model.Ten;
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
            _lichSuServices.LuuLichSu((int)Session["ID"], (int)EnumLoaiHanhDong.SUA, item.GetType().ToString());
            TempData["Message"] = "Cập nhật thành công";
            TempData["NotiType"] = "success"; //success là class trong bootstrap
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (!_quyenServices.Authorize((int)EnumQuyen.NHOMNGUOIDUNG_XOA))
            {
                TempData["Message"] = "Bạn không có quyền thực hiện chức năng này";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("ViewDenied", "QLKS");
            }
            var nhomnguoidung = db.NHOMNGUOIDUNGs.Find(id);
            int a = 0;
            a = db.Database.ExecuteSqlCommand("exec SP_Delete_NHOMNGUOIDUNG @ID", new SqlParameter("@ID", nhomnguoidung.ID));
            //db.NHOMNGUOIDUNGs.Remove(nhomnguoidung);
            db.SaveChanges();
            //Thông báo
            TempData["Message"] = "Xóa thành công";
            TempData["NotiType"] = "success"; //success là class trong bootstrap
            return Json("ok");
        }

        //[HttpPost]
        //public ActionResult CheckQuyen()
        //{
        //    if (!_quyenServices.Authorize((int)EnumQuyen.NHOMNGUOIDUNG_XEM))
        //    {
        //        return Json("no");
        //    }
        //    return Json("yes");
        //}
    }
}