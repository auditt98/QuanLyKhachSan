using QLKS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Data
{
    public class NGUOIDUNGServices
    {
        private QLKSContext db = new QLKSContext();
        public NGUOIDUNG GetNguoiDungById(int id)
        {
            return db.NGUOIDUNGs.Find(id);
        }

        public NGUOIDUNG GetNguoiDungByTenHoacSDT(string keySearch)
        {
            var nguoidung = db.NGUOIDUNGs.Where(x => x.tendangnhap == keySearch || x.sodienthoai == keySearch).FirstOrDefault();
            return nguoidung;
        }

        public NGUOIDUNG InsertNguoiDung(NGUOIDUNG nd)
        {
            //do some check here
            return db.NGUOIDUNGs.Add(nd);
        }
    }
}