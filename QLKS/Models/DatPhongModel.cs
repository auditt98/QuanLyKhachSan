using FluentValidation.Attributes;
using QLKS.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKS.Models
{
	[Validator(typeof(DatPhongValidator))]
	public class DatPhongModel
	{
		public int? PHONG_ID { get; set; }

		public int? DATPHONG_ID { get; set; }

		public string tenkhachhang { get; set; }
 
		public string socmt { get; set; }

		public string sodienthoai { get; set; }

		public string email { get; set; }

		public DateTime? ngaydukienden { get; set; }

		public DateTime? ngaydukiendi { get; set; }

		//public IEnumerable<SelectListItem> DanhSachPhong { get; set; }

		public string MaDatPhong { get; set; }

        public int? LOAIPHONG_ID { get; set; }

		public IEnumerable<SelectListItem> DanhSachLoaiPhong { get; set; }

		public int? SoPhong { get; set; }

        public bool IsFromCheckIn { get; set; }
    }
}