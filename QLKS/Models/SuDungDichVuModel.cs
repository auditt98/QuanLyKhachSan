using QLKS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Models
{
    public class SuDungDichVuModel
    {
        public int THUEPHONG_ID { get; set; }

        public int DICHVU_ID { get; set; }

        public DateTime? ngaysudung { get; set; }

        public int? soluong { get; set; }

        public int? thanhtien { get; set; }

        public int? NGUOIDUNG_ID { get; set; }

        public IEnumerable<DichVuModel> danhsachdichvu { get; set; }

    }
}