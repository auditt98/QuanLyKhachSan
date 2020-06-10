namespace QLKS.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DATPHONG")]
    public partial class DATPHONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DATPHONG()
        {
            CHITIETDATPHONGs = new HashSet<CHITIETDATPHONG>();
        }

        public int ID { get; set; }

        public int? KHACHHANG_ID { get; set; }

        [StringLength(20)]
        public string ma { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDATPHONG> CHITIETDATPHONGs { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
