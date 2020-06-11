using QLKS.Domain;
using QLKS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//
namespace QLKS.Services
{
    public class LoaiTinhTrangServices
    {
        private QLKSContext db = new QLKSContext();
        
        public IEnumerable<SelectListItem> PrepareLoaiTinhTrangPhong(int? selected)
        {
            var items = db.LOAITINHTRANGs.Where(c => c.ID <= 4).Select(c => new SelectListItem {
                Text = c.ten,
                Value = c.ID.ToString(),
                Selected = c.ID == selected
            }).ToList();
            var firstRow = new SelectListItem { Value = null, Text = "--Chọn tình trạng--" };
            items = items.Prepend(firstRow).ToList();
            return items;
        }

    }
}