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

        public bool Authorize(params int[] listQuyen)
        {
            var nguoidung_id = HttpContext.Current.Session["ID"];
            var nguoidung = db.NGUOIDUNGs.Find(nguoidung_id);
            if(nguoidung == null)
            {
                return false;
            }
            foreach(var quyen in listQuyen)
            {
                var q = db.QUYENs.Find(quyen);
                var nhom = nguoidung.NHOMNGUOIDUNG_ID;
                if(q == null)
                {
                    return false;
                }
                else
                {
                    if(nguoidung.NHOMNGUOIDUNG == null || nguoidung.NHOMNGUOIDUNG_ID == null)
                    {
                        return false;
                    }
                    if (!nguoidung.NHOMNGUOIDUNG.QUYENs.Contains(q))
                    {
                        return false;
                    }
                }

            }
            return true;

        }
        public bool Authorize1(QLKSContext dbContext, params int[] listQuyen)
        {
            var nguoidung_id = HttpContext.Current.Session["ID"];
            var nguoidung = dbContext.NGUOIDUNGs.Find(nguoidung_id);
            if (nguoidung == null)
            {
                return false;
            }
            foreach (var quyen in listQuyen)
            {
                var q = dbContext.QUYENs.Find(quyen);
                var nhom = nguoidung.NHOMNGUOIDUNG_ID;
                if (q == null)
                {
                    return false;
                }
                else
                {
                    if (nguoidung.NHOMNGUOIDUNG == null || nguoidung.NHOMNGUOIDUNG_ID == null)
                    {
                        return false;
                    }
                    if (!nguoidung.NHOMNGUOIDUNG.QUYENs.Contains(q))
                    {
                        return false;
                    }
                }

            }
            return true;

        }
    }
}