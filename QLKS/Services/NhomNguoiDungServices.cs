using QLKS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static QLKS.Extensions.Enum;
//
namespace QLKS.Services
{
    public class NhomNguoiDungServices
    {
        private QLKSContext db = new QLKSContext();

        public List<SelectListItem> PrepareSelectListNhomNguoiDung(int id)
        {
            var items = db.NHOMNGUOIDUNGs.Where(c => c.ID != (int)EnumNhomNguoiDung.ADMIN).Select(c => new SelectListItem
            {
                Text = c.Ten,
                Value = c.ID.ToString(),
                Selected = c.ID == id
            }).ToList();

            foreach(var i in items)
            {
                if(i.Value == ((int)EnumNhomNguoiDung.KETOAN).ToString())
                {
                    i.Text = "Nhân viên kế toán";
                }
                if(i.Value == ((int)EnumNhomNguoiDung.LETAN).ToString())
                {
                    i.Text = "Nhân viên lễ tân";
                }
                if(i.Value == ((int)EnumNhomNguoiDung.PHONG).ToString())
                {
                    i.Text = "Nhân viên buồng phòng";
                }
            }
            return items;
        }

    }
}