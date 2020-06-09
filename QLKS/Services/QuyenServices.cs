using QLKS.Domain;
using QLKS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKS.Services
{
    public class QuyenServices
    {
        QLKSContext db = new QLKSContext();

        public IEnumerable<SelectListItem> GetAllQuyen(List<int> selected)
        {
            var items = db.QUYENs.Select(c => new SelectListItem
            {
                Text = c.ten,
                Value = c.ID.ToString(),
                Selected = selected.Contains(c.ID)
            }).ToList();
            return items;
        }

    }
}