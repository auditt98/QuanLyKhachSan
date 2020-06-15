using QLKS.Domain;
using QLKS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static QLKS.Extensions.Enum;

namespace QLKS.Controllers
{
    public class QLKSController : Controller
    {
        // GET: QLKS
        QLKSContext db = new QLKSContext();
        private NguoiDungServices _nguoiDungServices = new NguoiDungServices();
        private QuyenServices _quyenServices = new QuyenServices();
        public ActionResult Index()
        {
            if (!_nguoiDungServices.isLoggedIn())
            {
                TempData["Message"] = "Bạn chưa đăng nhập, vui lòng đăng nhập";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("Login", "NguoiDung");
            }
            var item = db.NHOMNGUOIDUNGs.First();
            return View(item);
        }

        public ActionResult ViewDenied()
        {
            if (!_nguoiDungServices.isLoggedIn())
            {
                TempData["Message"] = "Bạn chưa đăng nhập, vui lòng đăng nhập";
                TempData["NotiType"] = "danger"; //success là class trong bootstrap
                return RedirectToAction("Login", "NguoiDung");
            }
            return View();
        }
    }
}