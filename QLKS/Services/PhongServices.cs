using QLKS.Domain;
using QLKS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static QLKS.Extensions.Enum;

namespace QLKS.Services
{//
    public class PhongServices
    {
        private QLKSContext db = new QLKSContext();
        public IEnumerable<SelectListItem> PrepareSelectListPhong(int? selected)
        {
            var items = db.PHONGs.Select(c => new SelectListItem
            {
                Text = c.SoPhong,
                Value = c.ID.ToString(),
                Selected = c.ID == selected
            }).ToList();
            if (selected == 0)
            {
                var firstRow = new SelectListItem { Value = null, Text = "--Chọn phòng--" };
                items = items.Prepend(firstRow).ToList();
            }
            return items;
        }

        public IEnumerable<SelectListItem> PrepareSelectListPhongForThuePhong(int? thuephong = 0, int? phong = 0)
        {
            var itemThuePhong = db.THUEPHONGs.Find(thuephong);
            var listPhong = new List<PHONG>();
            foreach (var i in itemThuePhong.CHITIETTHUEPHONGs)
            {
                listPhong.Add(i.PHONG);
            }
            var items = listPhong.Select(c => new SelectListItem
            {
                Text = c.SoPhong,
                Value = c.ID.ToString(),
                Selected = c.ID == phong
            }).ToList();
            if(phong == 0)
            {
                var firstRow = new SelectListItem { Value = null, Text = "--Chọn phòng--" };
                items = items.Prepend(firstRow).ToList();
            }
            return items;
        }


        public List<PHONG> GetPhongTrongFromLoaiPhong(int? loaiphong)
        {
            var items = db.PHONGs.Where(c => c.LOAIPHONG.ID == loaiphong && c.LOAITINHTRANG_ID == (int)EnumLoaiTinhTrang.TRONG).ToList();
            return items;
        }
    }
}