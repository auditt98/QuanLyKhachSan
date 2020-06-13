using QLKS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKS.Controllers
{
    public class LichSuController : Controller
    {
        // GET: LichSu
        QLKSContext db = new QLKSContext();
        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PopulateLichSu()
        {
            var danhSachLichSu= db.LUUTRUs.Select(c => new
            {
                loaihanhdong = c.loaihanhdong,
                ngaychinhsua = c.ngaychinhsua,
                tennguoidung = c.NGUOIDUNG.tennguoidung,
                tendangnhap = c.NGUOIDUNG.tendangnhap,
                ghichu = c.ghichu,
                uid = c.ID
            }).OrderBy(c => c.uid).ToList();
            var result = new { data = danhSachLichSu };
            return Json(result);
        }
    }
}