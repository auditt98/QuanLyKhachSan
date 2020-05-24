using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Models
{
    public partial class Quyen
    {
        public int ID { get; set; }

        public string ten { get; set; }

        public string ma { get; set; }

        public DateTime? ngaytao { get; set; }

        public int? nguoitao { get; set; }

        public string ipchinhsua { get; set; }

        public DateTime? ngaychinhsua { get; set; }

        public virtual NguoiDung NGUOITAO { get; set; }

        public virtual NguoiDung NGUOISUA { get; set; }

        //public virtual ICollection<NHOMNGUOIDUNG> NHOMNGUOIDUNGs { get; set; }

    }
}