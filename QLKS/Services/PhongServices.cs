using QLKS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKS.Services
{
    public class PhongServices
    {
        private QLKSContext db = new QLKSContext();
        public IEnumerable<SelectListItem> PrepareSelectListPhong(int? selected)
        {
            var items = db.PHONGs.Select(c => new SelectListItem
            {
                Text = c.ma,
                Value = c.ID.ToString(),
                Selected = c.ID == selected
            }).ToList();
            var firstRow = new SelectListItem { Value = null, Text = "--Chọn phòng--" };
            items = items.Prepend(firstRow).ToList();
            return items;
        }
    }
}