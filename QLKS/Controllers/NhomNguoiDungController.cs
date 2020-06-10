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
            var model = new NhomNguoiDungModel();
            var maxId = db.NHOMNGUOIDUNGs.Select(c => c.ID).DefaultIfEmpty(0).Max();
            var newId = (maxId + 1).ToString().PadLeft(7, '0');
            model.ma = "NHOM" + "-" + newId;
            var allQuyen = _quyenServices.GetAllQuyen(new List<int>()).ToList();
            foreach(var quyen in allQuyen)
            {
                var quyenModel = new QuyenModel();
                switch (Convert.ToInt32(quyen.Value))
                {
                    case (int)EnumQuyen.CAPQUYEN:
                        quyen.Text = "Cấp quyền";
                        break;
                    case (int)EnumQuyen.DM_DICHVU:
                        quyen.Text = "Quản lý danh mục dịch vụ";
                        break;
                    case (int)EnumQuyen.DM_KHACHHANG:
                        quyen.Text = "Quản lý danh mục khách hàng";
                        break;
                    case (int)EnumQuyen.DM_LOAIPHONG:
                        quyen.Text = "Quản lý danh mục loại phòng";
                        break;
                    case (int)EnumQuyen.DM_PHONG:
                        quyen.Text = "Quản lý danh mục phòng";
                        break;
                    case (int)EnumQuyen.DM_VATTU:
                        quyen.Text = "Quản lý danh mục vật tư";
                        break;
                    case (int)EnumQuyen.THONGKEDATPHONG:
                        quyen.Text = "Thống kê đặt phòng";
                        break;
                    case (int)EnumQuyen.THONGKEDOANHTHU:
                        quyen.Text = "Thống kê doanh thu";
                        break;
                    case (int)EnumQuyen.THONGKEDOANHTHUDICHVU:
                        quyen.Text = "Thống kê doanh thu dịch vụ";
                        break;
                    case (int)EnumQuyen.THUEPHONG:
                        quyen.Text = "Nghiệp vụ thuê phòng";
                        break;
                    case (int)EnumQuyen.TRAPHONG:
                        quyen.Text = "Nghiệp vụ trả phòng";
                        break;
                    default:
                        break;
                }
                model.DanhSachQuyen.Add(quyen);
            }
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
            var nhomNguoiDungModel = AutoMapper.Mapper.Map<NhomNguoiDungModel>(nhomNguoiDung);
            var allQuyen = _quyenServices.GetAllQuyen(listQuyen).ToList();
            foreach (var quyen in allQuyen)
            {
                var quyenModel = new QuyenModel();
                switch (Convert.ToInt32(quyen.Value))
                {
                    case (int)EnumQuyen.CAPQUYEN:
                        quyen.Text = "Cấp quyền";
                        break;
                    case (int)EnumQuyen.DM_DICHVU:
                        quyen.Text = "Quản lý danh mục dịch vụ";
                        break;
                    case (int)EnumQuyen.DM_KHACHHANG:
                        quyen.Text = "Quản lý danh mục khách hàng";
                        break;
                    case (int)EnumQuyen.DM_LOAIPHONG:
                        quyen.Text = "Quản lý danh mục loại phòng";
                        break;
                    case (int)EnumQuyen.DM_PHONG:
                        quyen.Text = "Quản lý danh mục phòng";
                        break;
                    case (int)EnumQuyen.DM_VATTU:
                        quyen.Text = "Quản lý danh mục vật tư";
                        break;
                    case (int)EnumQuyen.THONGKEDATPHONG:
                        quyen.Text = "Thống kê đặt phòng";
                        break;
                    case (int)EnumQuyen.THONGKEDOANHTHU:
                        quyen.Text = "Thống kê doanh thu";
                        break;
                    case (int)EnumQuyen.THONGKEDOANHTHUDICHVU:
                        quyen.Text = "Thống kê doanh thu dịch vụ";
                        break;
                    case (int)EnumQuyen.THUEPHONG:
                        quyen.Text = "Nghiệp vụ thuê phòng";
                        break;
                    case (int)EnumQuyen.TRAPHONG:
                        quyen.Text = "Nghiệp vụ trả phòng";
                        break;
                    default:
                        break;
                }
                nhomNguoiDungModel.DanhSachQuyen.Add(quyen);
            }
            nhomNguoiDungModel.DanhSachQuyen = allQuyen;
            return View(nhomNguoiDungModel);
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
            var item = db.NHOMNGUOIDUNGs.Where(c => c.ID == model.ID).FirstOrDefault();
            if (item == null)
            {
                TempData["Message"] = "Có lỗi xảy ra";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("List");
            }
            //map from model to database object
            item = Mapper.Map(model, item);
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