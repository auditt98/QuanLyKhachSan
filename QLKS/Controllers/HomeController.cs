using QLKS.Domain;
using QLKS.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKS.Controllers
{
	public class HomeController : Controller
	{
		private QLKSContext db = new QLKSContext();
		public ActionResult Index()
		{
			//var cart = Session[CommonConstants.DatPhongSession];
			//var list = new List<DatPhongItem>();
			//if (cart != null)
			//{
			//	list = (List<DatPhongItem>)cart;
			//}
			return RedirectToAction("Login", "NguoiDung");
			//return View(db.LOAIPHONGs.ToList());
		}
		// GET: LoaiPhong/Details
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return RedirectToAction("Details");
			}
			var loaiphong = db.LOAIPHONGs.Find(id);
			if (loaiphong == null)
			{
				TempData["Message"] = "Không thấy loại phòng này";
				TempData["NotiType"] = "danger"; //success là class trong bootstrap
				return RedirectToAction("Details");
			}
			//prepare model
			return View(loaiphong);
		}
		public ActionResult DatPhong(DateTime? check_in, DateTime? check_out, int? adults, int? children)
		{
			//string dateIn = check_in.ToString();
			//ViewBag.check_in = check_in;
			//ViewBag.check_out = check_out;
			//ViewBag.adults = adults;
			//ViewBag.children = children;

			//var a = 1;
			//IQueryable<LOAIPHONG> data = db.LOAIPHONGs;
			////var data = db.LOAIPHONGs.Select(lp => new
			////{
			////	Id = lp.ID,
			////	tenloaiphong = lp.tenloaiphong,
			////	gia = lp.PHONGs.Max(p=>p.giathue),
			////	anh1= lp.anh,
			////	khungnhin = lp.khungnhin,
			////	dientich =lp.dientich,
			////	giuong = lp.giuong,
			////	nguoilon = lp.nguoilon,
			////	trecon =lp.trecon,

			////});

			////var a = data.ToList();
			////var sophongtrong = db.PHONGs.Where(c => c.LOAIPHONG_ID == 1 && c.LOAITINHTRANG_ID == (int)EnumLoaiTinhTrang.TRONG).ToList().Count;
			//if (adults != null)
			//{
			//	data = data.Where(d => d.SoNguoiLon >= adults);
			//}
			//if (children != null)
			//{
			//	data = data.Where(d => d.SoTreEm >= children);
			//}
			//return View(data.ToList());
			return Content("");

		}
		[HttpGet]
		public ActionResult ThanhToan()
		{
			return View();
		}
		[HttpPost]
		public ActionResult ThanhToan(string txtName, string txtCMND, string txtPhone, string txtEmail)
		{
			var cart = Session[CommonConstants.DatPhongSession];
			var list = new List<DatPhongItem>();

			if (cart != null && txtName != "" && txtPhone.Length > 9)
			{
				list = (List<DatPhongItem>)cart;
				//thêm thông tin giao hàng
				var datPhong = new DATPHONG();
				db.DATPHONGs.Add(datPhong);
				db.SaveChanges();
				//them chi tiết bill
				foreach (var item in list)
				{
					//var phong = db.PHONGs.Where(p => p.LOAIPHONG_ID == item.loaiphongId && p.LOAITINHTRANG_ID == 1).FirstOrDefault(); // phong trong
					//var chiTietDatPhong = new CHITIETDATPHONG();
					//chiTietDatPhong.DATPHONG_ID = datPhong.ID;
					//chiTietDatPhong.PHONG_ID = phong.ID;
					//chiTietDatPhong. = txtName;
					//chiTietDatPhong.sodienthoai = txtPhone;
					//chiTietDatPhong.socmt = txtCMND;
					//chiTietDatPhong.email = txtEmail;
					//chiTietDatPhong.ngaydukienden = Convert.ToDateTime(item.ngaydukienden);
					//chiTietDatPhong.ngaydukiendi = Convert.ToDateTime(item.ngaydukiendi);
					//phong.LOAITINHTRANG_ID = 3;
					//db.SaveChanges();
					//db.CHITIETDATPHONGs.Add(chiTietDatPhong);
					//db.SaveChanges();
					
				}
				ViewBag.suc = "Đặt phòng  thành công ! Chúng tôi sẽ liên hệ với quý khách sớm nhất .";
				Session[CommonConstants.DatPhongSession] = null;
				return View();
			}
			else
			{
				ViewBag.err = "Giỏ hàng chủa có sản phầm nào , hoặc bạn nhập thiếu thông tin khách hàng !";
				return View(list);
			}
		}
		public JsonResult ListCart()
		{
			var sessionCart = (List<DatPhongItem>)Session[CommonConstants.DatPhongSession];
			return Json(new
			{
				data = sessionCart,
				status = true
			});
		}
		//public JsonResult ADD(int id, DateTime check_in, DateTime check_out, int adults, int children)
		//{
		//	var loaiPhong = db.LOAIPHONGs.Find(id);
		//	var cart = Session[CommonConstants.DatPhongSession];
		//	var item = new DatPhongItem();
		//	item.loaiphongId = id;
		//	item.tenloaiphong = loaiPhong.tenloaiphong;
		//	item.ngaydukienden = check_in.ToString("yyyy-MM-dd");
		//	item.ngaydukiendi = check_out.ToString("yyyy-MM-dd");
		//	TimeSpan soNgay = check_out - check_in;
		//	item.songay = soNgay.Days;
		//	item.nguoilon = adults;
		//	item.trecon = children;
		//	item.gia = Convert.ToInt32(loaiPhong.PHONGs.Max(p=>p.giathue));

		//	if (cart != null)
		//	{
		//		var list = (List<DatPhongItem>)cart;
		//		list.Add(item);
		//		//gán vào session 	
		//		Session[CommonConstants.DatPhongSession] = list;
		//	}
		//	else
		//	{
		//		var list = new List<DatPhongItem>();
		//		list.Add(item);
		//		//gán vào session 	
		//		Session[CommonConstants.DatPhongSession] = list;
		//	}

		//	return Json(new
		//	{
		//		data = Session[CommonConstants.DatPhongSession],
		//		status = true
		//	});
		//}
		//public JsonResult DELETE(int id)
		//{
		//	var cart = (List<DatPhongItem>)Session[CommonConstants.DatPhongSession];
		//	cart.RemoveAll(x => x.Id == id);
		//	//gán vào session 	
		//	Session[CommonConstants.DatPhongSession] = cart;
		//	return Json(new
		//	{
		//		data = Session[CommonConstants.DatPhongSession],
		//		status = true
		//	});
		//}
	}
}