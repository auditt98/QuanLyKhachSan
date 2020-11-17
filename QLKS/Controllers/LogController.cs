using QLKS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKS.Controllers
{
    public class LogController : Controller
    {
        // GET: Log

        QLKSContext db = new QLKSContext();


        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PopulateLog()
        {
            var danhSachLichSu= db.LOGs.Select(c => new
            {
                loaihanhdong = c.LoaiHanhDong,
                tennguoidung = c.NGUOIDUNG.TenNguoiDung,
                tendangnhap = c.NGUOIDUNG.TenDangNhap,
                ngaychinhsua = c.ThoiGianChinhSua,
                ghichu = c.GhiChu,
                uid = c.ID
            }).OrderBy(c => c.uid).ToList();
            var result = new { data = danhSachLichSu };
            return Json(result);
        }
    }
}