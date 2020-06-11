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
			var cart = Session[CommonConstants.DatPhongSession];
			var list = new List<DatPhongItem>();
			if (cart != null)
			{
				list = (List<DatPhongItem>)cart;
			}

			return View(db.LOAIPHONGs.ToList());
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
			string dateIn = check_in.ToString();
			ViewBag.check_in = check_in;
			ViewBag.check_out = check_out;
			ViewBag.adults = adults;
			ViewBag.children = children;



			var data = from lp in db.LOAIPHONGs select lp;
			//		   select new
			//		   {
			//			   lp.ID,
			//			   lpCount = db.PHONGs.Where(c => c.LOAIPHONG_ID == 1 && c.LOAITINHTRANG_ID == (int)EnumLoaiTinhTrang.TRONG).ToList().Count
			//		   };
			//var a = data.ToList();
			//var sophongtrong = db.PHONGs.Where(c => c.LOAIPHONG_ID == 1 && c.LOAITINHTRANG_ID == (int)EnumLoaiTinhTrang.TRONG).ToList().Count;
			//if (adults != null)
			//{
			//	data = data.Where(d => d.nguoilon >= adults);
			//}
			//if (children != null)
			//{
			//	data = data.Where(d => d.trecon >= children);
			//}
			return View(data.ToList());
			
		}
		[HttpGet]
		public ActionResult ThanhToan()
		{			
			return View();
		}
		[HttpPost]
		public ActionResult ThanhToan(int id , int diachi ,string sdt)
		{
			return View();
		}
		public JsonResult ListCart()
		{
			var sessionCart = (List<DatPhongItem>)Session[CommonConstants.DatPhongSession];
			return Json(new
			{
				data = sessionCart,
				status = true
			}) ;
		}
		public JsonResult ADD(int id ,DateTime check_in ,DateTime check_out)
		{
			var cart = Session[CommonConstants.DatPhongSession];
			var item = new DatPhongItem();
			item.loaiphongId = id;
			item.ngaydukienden = check_in;
			item.ngaydukiendi = check_out;

			if (cart != null)
			{
				var list =  (List<DatPhongItem>)cart;
				list.Add(item);
				//gán vào session 	
				Session[CommonConstants.DatPhongSession] = list;
			}
			else
			{
				var list = new List<DatPhongItem>();
				list.Add(item);
				//gán vào session 	
				Session[CommonConstants.DatPhongSession] = list;
			}
			return Json(new
			{
				status = true
			});
		}
	}
}