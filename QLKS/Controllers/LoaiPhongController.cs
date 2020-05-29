using QLKS.Domain;
using QLKS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKS.Controllers
{
	public class LoaiPhongController : Controller
	{
		private QLKSContext db = new QLKSContext();
		// GET: LoaiPhong/List
		public ActionResult List()
		{
			return View(db.LOAIPHONGs.ToList());
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(LOAIPHONG model)
		{
			if (!ModelState.IsValid)
			{
				return View("Create", model);
			}
			db.LOAIPHONGs.Add(model);
			db.SaveChangesAsync();
			TempData["ThongBao"] = "Thêm mới thành công";
			return RedirectToAction("List");
		}

		public ActionResult Edit(int id)
		{
			return View(db.LOAIPHONGs.FirstOrDefault(i => i.ID == id));
		}

		[HttpPost]
		public ActionResult Edit(LOAIPHONG model, HttpPostedFileBase UploadImage)
		{
			//try
			//{
			if (ModelState.IsValid)
			{
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
				var loaiPhong = db.LOAIPHONGs.Find(model.ID);
				loaiPhong.ma = model.ma;//gia loai phong
				loaiPhong.anh = model.anh;
				loaiPhong.dientich = model.dientich;
				loaiPhong.giuong = model.giuong;
				loaiPhong.nguoilon = model.nguoilon;
				loaiPhong.trecon = model.trecon;
				loaiPhong.khungnhin = model.khungnhin;
				loaiPhong.tenloaiphong = model.tenloaiphong;
				loaiPhong.thongtin = model.thongtin;
				db.SaveChanges();

			}
			return RedirectToAction("List");
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			var loaiPhong = db.LOAIPHONGs.Find(id);
			db.LOAIPHONGs.Remove(loaiPhong);
			db.SaveChanges();
			return RedirectToAction("List");
		}
	}
}