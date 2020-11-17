namespace QLKS.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHONG")]
    public partial class PHONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHONG()
        {
            CHITIETTHUEPHONGs = new HashSet<CHITIETTHUEPHONG>();
        }

        public int ID { get; set; }

        //[StringLength(10)]
        public string SoPhong { get; set; }

        public int SoTang { get; set; }

        public int LOAIPHONG_ID { get; set; }

        public int? LOAITINHTRANG_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETTHUEPHONG> CHITIETTHUEPHONGs { get; set; }

        public virtual LOAIPHONG LOAIPHONG { get; set; }

        public virtual LOAITINHTRANG LOAITINHTRANG { get; set; }
    }
}
