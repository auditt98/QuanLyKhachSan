using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Models
{
    public class NhomNguoiDungModel
    {
        public int? ID { get; set; }

        public string ten { get; set; }

        public string ma { get; set; }

        public virtual IList<NguoiDungModel> NGUOIDUNGs { get; set; }

        public virtual IList<QuyenModel> QUYENs { get; set; }
    }
}