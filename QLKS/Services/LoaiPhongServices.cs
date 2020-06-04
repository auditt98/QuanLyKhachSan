using QLKS.Domain;
using QLKS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKS.Services
{
    public class LoaiPhongServices
    {
        private QLKSContext db = new QLKSContext();
        
        public IEnumerable<SelectListItem> PrepareSelectListLoaiPhong(int? selected)
        {
            var items = db.LOAIPHONGs.Select(c => new SelectListItem {
                Text = c.tenloaiphong,
                Value = c.ID.ToString(),
                Selected = c.ID == selected
            }).ToList();
            var firstRow = new SelectListItem { Value = null, Text = "--Chọn loại phòng--" };
            items = items.Prepend(firstRow).ToList();
            return items;
        }

        public LOAIPHONG GetLoaiPhongById(int id)
        {
            var phong = db.LOAIPHONGs.Find(id);
            if(phong != null)
            {
                return phong;
            }
            else
            {
                return null;
            }
        }
    }
}