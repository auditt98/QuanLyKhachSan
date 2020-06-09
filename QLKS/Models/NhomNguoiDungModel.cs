using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKS.Models
{
    public class NhomNguoiDungModel
    {
        public NhomNguoiDungModel()
        {
            this.DanhSachQuyen = new List<SelectListItem>();
        }

        public int? ID { get; set; }

        public string ten { get; set; }

        public string ma { get; set; }

        public List<SelectListItem> DanhSachQuyen { get; set; }

        public List<int> SelectedQuyens { get; set; }

        public virtual IList<NguoiDungModel> NGUOIDUNGs { get; set; }

        public virtual IList<QuyenModel> QUYENs { get; set; }
    }
}