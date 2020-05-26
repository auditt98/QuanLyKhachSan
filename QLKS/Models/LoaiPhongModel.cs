using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Models
{
    public class LoaiPhongModel
    {
        public int? ID { get; set; }

        public string tenloaiphong { get; set; }

        public string ghichu { get; set; }

        public string anh { get; set; }

        public string khungnhin { get; set; }

        public int? dientich { get; set; }

        public string giuong { get; set; }

        public int? nguoilon { get; set; }

        public int? trecon { get; set; }

        public string tiennghi { get; set; }

        public string thongtin { get; set; }

        public string ma { get; set; }
    }
}