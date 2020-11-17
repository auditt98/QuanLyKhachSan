using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Models
{
    public class ChuongTrinhGiamGiaModel
    {
        public int? ID { get; set; }

        public string Ma { get; set; }

        public string Ten { get; set; }

        public double TiLeGiamGia { get; set; }

        public DateTime TuNgay { get; set; }

        public DateTime DenNgay { get; set; }
    }
}