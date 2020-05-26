namespace QLKS.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VATTU")]
    public partial class VATTU
    {
        public int ID { get; set; }

        public string ten { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaymua { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaysudung { get; set; }

        public int? soluong { get; set; }

        public string mota { get; set; }

        public int? sotien { get; set; }

        public int? PHONG_ID { get; set; }

        public virtual PHONG PHONG { get; set; }
    }
}
