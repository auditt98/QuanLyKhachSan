using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Models
{
    public partial class DichVu
    {
        public int ID { get; set; }

        public string tendichvu { get; set; }

        public int? dongia { get; set; }

        public string ma { get; set; }
    }
}