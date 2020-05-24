namespace QLKS.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        public KHACHHANG()
        {
            DATPHONGs = new HashSet<DATPHONG>();
            THUEPHONGs = new HashSet<THUEPHONG>();
        }

        public int ID { get; set; }

        public string ma { get; set; }

        public string tenkhachhang { get; set; }

        public bool? gioitinh { get; set; }

        public string socmt { get; set; }

        public string sodienthoai { get; set; }

        public string email { get; set; }

        public virtual ICollection<DATPHONG> DATPHONGs { get; set; }

        public virtual ICollection<THUEPHONG> THUEPHONGs { get; set; }
    }
}
