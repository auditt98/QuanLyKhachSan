using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Models
{
    public partial class NguoiDungModel
    {
        public int? ID { get; set; }

        public string tendangnhap { get; set; }

        public string hash { get; set; }

        public string tennguoidung { get; set; }

        public string sodienthoai { get; set; }

        public DateTime? ngaysinh { get; set; }

        public string diachi { get; set; }

        public bool? gioitinh { get; set; }

        public string avatar { get; set; }

        public string malaymatkhau { get; set; }

        public IList<NhomNguoiDungModel> nhomNguoiDung { get; set; }
    }
}
