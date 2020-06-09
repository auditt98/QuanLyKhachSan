using QLKS.Domain;
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
			//var data = from lp in db.LOAIPHONGs
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
			return View();
			
		}
	}
}