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
	public class DatPhongModel
	{
        public int? PHONG_ID { get; set; }

        public int? DATPHONG_ID { get; set; }

        public string tenkhachhang { get; set; }
 
        public string socmt { get; set; }

        public string sodienthoai { get; set; }

        public string email { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ngaydukienden { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ngaydukiendi { get; set; }

        public IEnumerable<SelectListItem> DanhSachPhong { get; set; }



    }
}