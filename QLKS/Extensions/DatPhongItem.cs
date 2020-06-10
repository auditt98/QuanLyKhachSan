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

		public DateTime? ngaydukienden { get; set; }

		public DateTime? ngaydukiendi { get; set; }
	}
}