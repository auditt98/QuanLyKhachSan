using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Extensions
{
	[Serializable]
	public class DatPhongItem
	{
		public int loaiphongId { get; set; }

		public string tenloaiphong { get; set; }
		public string ngaydukienden { get; set; }

		public string ngaydukiendi { get; set; }

		public int songay { get; set; }
		public int nguoilon { get; set; }

		public int trecon { get; set; }

		public int gia { get; set; }
	}
}