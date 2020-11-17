namespace QLKS.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETTHUEPHONG")]
    public partial class CHITIETTHUEPHONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHITIETTHUEPHONG()
        {
            SUDUNGDICHVUs = new HashSet<SUDUNGDICHVU>();
        }

        public int ID { get; set; }

        public int THUEPHONG_ID { get; set; }

        public int PHONG_ID { get; set; }

        public virtual PHONG PHONG { get; set; }

        public virtual THUEPHONG THUEPHONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUDUNGDICHVU> SUDUNGDICHVUs { get; set; }
    }
}
