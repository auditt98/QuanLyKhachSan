using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Models
{
    public class sp_Result_ThongKePhong
    {
        public int? ID { get; set; }
        public string Ten { get; set; }
        public int? GiaThue { get; set; }
        public int? TongSoLuongPhong { get; set; }
        public int? SoPhongDatTruoc { get; set; }
        public int? SoPhongDaThue { get; set; }
        public int? SoPhongTrong { get; set; }
    }
}