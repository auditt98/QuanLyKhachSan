namespace QLKS.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHOMNGUOIDUNG")]
    public partial class NHOMNGUOIDUNG
    {
        public NHOMNGUOIDUNG()
        {
            NGUOIDUNGs = new HashSet<NGUOIDUNG>();
            QUYENs = new HashSet<QUYEN>();
        }

        public int ID { get; set; }

        public string ten { get; set; }

        public string ma { get; set; }

        public virtual ICollection<NGUOIDUNG> NGUOIDUNGs { get; set; }

        public virtual ICollection<QUYEN> QUYENs { get; set; }
    }
}
