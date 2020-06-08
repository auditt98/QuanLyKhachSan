using QLKS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Services
{
    public class KhachHangServices
    {
        QLKSContext db = new QLKSContext();
        public string GenMaKhachHang()
        {
            var maxId = db.KHACHHANGs.Select(c => c.ID).DefaultIfEmpty(0).Max();
            var newId = (maxId + 1).ToString().PadLeft(7, '0');
            var ma = "KH" + "-" + newId;
            return ma;
        }
    }
}