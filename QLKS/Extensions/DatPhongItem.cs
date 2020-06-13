using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLKS.Extensions
{
	[Serializable]
	public class DatPhongItem
	{
		[Key]
		public int Id { get; set; }

		public static int count = 0;
		public int loaiphongId { get; set; }

		public string tenloaiphong { get; set; }
		public string ngaydukienden { get; set; }

		public string ngaydukiendi { get; set; }

		public int songay { get; set; }
		public int nguoilon { get; set; }

		public int trecon { get; set; }

		public int gia { get; set; }

		public DatPhongItem()
		{
			count++;
			Id = count;
		}
	}
}