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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QUYEN()
        {
            NHOMNGUOIDUNGs = new HashSet<NHOMNGUOIDUNG>();
        }

        public int ID { get; set; }

        //[StringLength(50)]
        public string Ten { get; set; }

        //[StringLength(10)]
        public string Ma { get; set; }

        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHOMNGUOIDUNG> NHOMNGUOIDUNGs { get; set; }
    }
}
