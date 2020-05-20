namespace QLKS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DICHVU")]
    public partial class DICHVU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUDUNGDICHVU> SUDUNGDICHVUs { get; set; }
    }
}
