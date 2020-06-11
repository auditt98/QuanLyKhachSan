using QLKS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static QLKS.Extensions.Enum;
//
namespace QLKS.Services
{
    public class LichSuServices
    {
        QLKSContext db = new QLKSContext();

        public void LuuLichSu(int nguoidung, int loaihanhdong, string ghichu = "")
        {
            var tenHanhDong = Enum.GetName(typeof(EnumLoaiHanhDong), loaihanhdong);
            var log = new LUUTRU();
            log.loaihanhdong = tenHanhDong;
            log.ghichu = ghichu;
            log.NGUOIDUNG_ID = nguoidung;
            log.ngaychinhsua = DateTime.Now;
            db.LUUTRUs.Add(log);
            db.SaveChanges();
        }
    }
}