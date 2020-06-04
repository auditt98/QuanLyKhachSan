namespace QLKS.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAITINHTRANG")]
    public partial class LOAITINHTRANG
    {
        public LOAITINHTRANG()
        {
            PHONGs = new HashSet<PHONG>();
        }

        public int ID { get; set; }

        [StringLength(20)]
        public string ma { get; set; }

        [StringLength(50)]
        public string ten { get; set; }

        public virtual ICollection<PHONG> PHONGs { get; set; }
    }
}
