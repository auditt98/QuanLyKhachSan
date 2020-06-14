using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKS.Controllers
{
    public class DoanhThuController : Controller
    {
        // GET: DoanhThu
        public ActionResult Chung()
        {
            return View();
        }
        public ActionResult DoanhThuTP()
        {
            return View();
        }
        public ActionResult DoanhThuDV()
        {
            return View();
        }
    }
}