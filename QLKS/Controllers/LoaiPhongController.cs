using AutoMapper;
using QLKS.Domain;
using QLKS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLKS.Services;
using static QLKS.Extensions.Enum;
using Newtonsoft.Json;

namespace QLKS.Controllers
{
	public class LoaiPhongController : Controller
	{
		private QLKSContext db = new QLKSContext();
		private NguoiDungServices _nguoiDungServices = new NguoiDungServices();
		private LichSuServices _lichSuServices = new LichSuServices();
		private QuyenServices _quyenServices = new QuyenServices();
		// GET: LoaiPhong/List
		public ActionResult List()
		{
			if (!_nguoiDungServices.isLoggedIn())
			{
				TempData["Message"] = "Bạn chưa đăng nhập, vui lòng đăng nhập";
				TempData["NotiType"] = "danger"; //success là class trong bootstrap
				return RedirectToAction("Login", "NguoiDung");
			}
			if (!_quyenServices.Authorize((int)EnumQuyen.LOAIPHONG_XEM))
			{
				return RedirectToAction("ViewDenied", "QLKS");
			}
			return View(db.LOAIPHONGs.ToList());
		}

		[HttpPost]
		public ActionResult PopulateLoaiPhong()
		{
			var danhSachLoaiPhong = db.LOAIPHONGs.Select(c => new
			{
				ma = c.ma,
				ten = c.tenloaiphong,
				anh = c.anh,
				giuong = c.giuong,
				thongtin = c.thongtin,
				uid = c.ID
			}).OrderBy(c => c.uid).ToList();
			var result = new { data = danhSachLoaiPhong };
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
			if (!_quyenServices.Authorize((int)EnumQuyen.LOAIPHONG_THEM))
			{
				return RedirectToAction("ViewDenied", "QLKS");
			}
			var loaiPhongModel = new LoaiPhongModel();
			var maxId = db.LOAIPHONGs.Select(c => c.ID).DefaultIfEmpty(0).Max();
			var newId = (maxId + 1).ToString().PadLeft(7, '0');
			loaiPhongModel.ma = "LP" + "-" + newId;
			return View(loaiPhongModel);
		}

		[HttpPost]
		public ActionResult Create(LoaiPhongModel model, HttpPostedFileBase UploadImage)
		{
			if (!_quyenServices.Authorize((int)EnumQuyen.LOAIPHONG_THEM))
			{
				return RedirectToAction("ViewDenied", "QLKS");
			}
			if (!ModelState.IsValid)
			{
				TempData["Message"] = "Có lỗi xảy ra! Vui lòng kiểm tra lại thông tin.";
				TempData["NotiType"] = "success"; //success là class trong bootstrap
				return View("Create", model);
			}
			if (UploadImage != null)
			{
				if (UploadImage.ContentType == "image/jpg" || UploadImage.ContentType == "image/png" || UploadImage.ContentType == "image/jpeg")
				{
					string fileName = Path.GetFileName(DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + "" + UploadImage.FileName);
					string path = Path.Combine(Server.MapPath("~/Content/imgLoaiPhong"), fileName);
					UploadImage.SaveAs(path);
					//UploadImage.SaveAs(Server.MapPath("/") + "/Content/imgLoaiPhong/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + UploadImage.FileName);
					model.anh = fileName;
				}
				else
				{
					ModelState.AddModelError("", "lỗi dữ liệu ảnh !");
				}
			}
			var item = AutoMapper.Mapper.Map<LOAIPHONG>(model);
			db.LOAIPHONGs.Add(item);
			db.SaveChanges();
			_lichSuServices.LuuLichSu((int)Session["ID"], (int)EnumLoaiHanhDong.THEM, item.ToString());
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
			if (!_quyenServices.Authorize((int)EnumQuyen.LOAIPHONG_SUA))
			{
				return RedirectToAction("ViewDenied", "QLKS");
			}
			if (id == null)
			{
				return RedirectToAction("List");
			}
			var loaiphong = db.LOAIPHONGs.Find(id);
			if (loaiphong== null)
			{
				TempData["Message"] = "Không thấy loại phòng này";
				TempData["NotiType"] = "danger"; //success là class trong bootstrap
				return RedirectToAction("List");
			}
			//prepare model
			var loaiPhongModel = AutoMapper.Mapper.Map<LoaiPhongModel>(loaiphong);
			return View(loaiPhongModel);
		}

		[HttpPost]
		public ActionResult Edit(LoaiPhongModel model, HttpPostedFileBase UploadImage)
		{
			if (!_quyenServices.Authorize((int)EnumQuyen.LOAIPHONG_SUA))
			{
				return RedirectToAction("ViewDenied", "QLKS");
			}
			if (ModelState.IsValid)
			{
				if (UploadImage != null)
				{
					if (UploadImage.ContentType == "image/jpg" || UploadImage.ContentType == "image/png" || UploadImage.ContentType == "image/jpeg")
					{
						string fileName = Path.GetFileName(DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + "" + UploadImage.FileName);
						string path = Path.Combine(Server.MapPath("~/Content/imgLoaiPhong"), fileName);
						UploadImage.SaveAs(path);
						model.anh = fileName;
					}
					else
					{
						ModelState.AddModelError("", "lỗi dữ liệu ảnh !");
					}
				}
				var item = db.LOAIPHONGs.Where(c => c.ID == model.ID).FirstOrDefault();
				if (item == null)
				{
					TempData["Message"] = "Có lỗi xảy ra";
					TempData["NotiType"] = "danger"; //success là class trong bootstrap
					return RedirectToAction("List");
				}
				item = Mapper.Map(model, item);
				db.SaveChanges();
				_lichSuServices.LuuLichSu((int)Session["ID"], (int)EnumLoaiHanhDong.SUA, item.ToString());
				TempData["Message"] = "Cập nhật thành công";
				TempData["NotiType"] = "success"; //success là class trong bootstrap
				return RedirectToAction("List");
			}
			else
			{
				TempData["Message"] = "Có lỗi xảy ra! Vui lòng kiểm tra lại thông tin.";
				TempData["NotiType"] = "danger"; //success là class trong bootstrap
				return View("Edit", model);
			}
		}

		[HttpPost]
		public ActionResult Delete(int id)
		{
			if (!_quyenServices.Authorize((int)EnumQuyen.LOAIPHONG_XOA))
			{
				return RedirectToAction("ViewDenied", "QLKS");
			}
			var item = db.LOAIPHONGs.Where(c => c.ID == id).FirstOrDefault();
			if (item != null)
			{
				try
				{
					db.LOAIPHONGs.Remove(item);
					db.SaveChanges();
				}
				catch
				{
					throw new Exception();
				}

				//Thông báo
				TempData["Message"] = "Xóa loại phòng thành công";
				TempData["NotiType"] = "success";
				_lichSuServices.LuuLichSu((int)Session["ID"], (int)EnumLoaiHanhDong.XOA, item.ToString());
				return Json("ok");
			}
			else
			{
				TempData["Message"] = "Đã có lỗi xảy ra";
				TempData["NotiType"] = "danger"; 
				return Json("error");
			}
		}

		[HttpPost]
		public ActionResult CheckQuyen()
		{
			if (!_quyenServices.Authorize((int)EnumQuyen.LOAIPHONG_XEM))
			{
				return Json("no");
			}
			return Json("yes");
		}
	}
}