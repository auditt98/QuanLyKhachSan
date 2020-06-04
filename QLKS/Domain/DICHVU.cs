namespace QLKS.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DICHVU")]
    public partial class DICHVU
    {

        public DICHVU()
        {
            SUDUNGDICHVUs = new HashSet<SUDUNGDICHVU>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string tendichvu { get; set; }

        public int? dongia { get; set; }

        [StringLength(10)]
        public string ma { get; set; }

        public virtual ICollection<SUDUNGDICHVU> SUDUNGDICHVUs { get; set; }
    }
}
