namespace QLKS.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUYEN")]
    public partial class QUYEN
    {
        public QUYEN()
        {
            NHOMNGUOIDUNGs = new HashSet<NHOMNGUOIDUNG>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string ten { get; set; }

        [StringLength(10)]
        public string ma { get; set; }

        public DateTime? ngaytao { get; set; }

        public int? nguoitao { get; set; }

        [StringLength(50)]
        public string ipchinhsua { get; set; }

        public DateTime? ngaychinhsua { get; set; }

        public int? nguoisua { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG1 { get; set; }

        public virtual ICollection<NHOMNGUOIDUNG> NHOMNGUOIDUNGs { get; set; }
    }
}
