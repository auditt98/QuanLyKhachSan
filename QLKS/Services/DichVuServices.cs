using QLKS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKS.Services
{
    public class DichVuServices
    {
        private QLKSContext db = new QLKSContext();

        public IEnumerable<SelectListItem> PrepareSelectListDichVu(int? selected)
        {
            var items = db.DICHVUs.Select(c => new SelectListItem
            {
                Text = c.Ten,
                Value = c.ID.ToString(),
                Selected = c.ID == selected
            }).ToList();
            if (selected == 0)
            {
                var firstRow = new SelectListItem { Value = null, Text = "--Chọn dịch vụ--" };
                items = items.Prepend(firstRow).ToList();
            }
            return items;
        }
    }
}