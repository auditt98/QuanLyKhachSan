using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Models
{
    public class VatTuModel
    {
        public int? ID { get; set; }

        public string ten { get; set; }

        public DateTime? ngaymua { get; set; }

        public DateTime? ngaysudung { get; set; }

        public int? soluong { get; set; }

        public string mota { get; set; }

        public int? sotien { get; set; }

        public int? PHONG_ID { get; set; }
    }
}