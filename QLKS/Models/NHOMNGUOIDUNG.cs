using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Models
{
    public class NhomNguoiDung
    {
        public int ID { get; set; }

        public string ten { get; set; }

        public string ma { get; set; }

        public virtual IList<NguoiDung> NGUOIDUNGs { get; set; }

        public virtual IList<Quyen> QUYENs { get; set; }
    }
}