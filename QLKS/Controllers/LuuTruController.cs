using Microsoft.Ajax.Utilities;
using QLKS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKS.Controllers
{
    public class LuuTruController : Controller
    {
        // GET: LuuTru
        QLKSContext db = new QLKSContext();
        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PopulateLuuTru()
        {
            var danhSachNhomNguoiDung = db.LUUTRUs.Select(c => new
            {
                loaihanhdong = c.loaihanhdong,
                ngaychinhsua = c.ngaychinhsua,
                tennguoidung = c.NGUOIDUNG.tennguoidung,
                ghichu = c.ghichu,
                uid = c.ID
            }).OrderBy(c => c.uid).ToList();
            var result = new { data = danhSachNhomNguoiDung };
            return Json(result);
        }
    }
}