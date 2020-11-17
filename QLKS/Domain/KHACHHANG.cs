namespace QLKS.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            DATPHONGs = new HashSet<DATPHONG>();
            THUEPHONGs = new HashSet<THUEPHONG>();
        }

        public int ID { get; set; }

        //[StringLength(10)]
        public string Ma { get; set; }

        //[Required]
        //[StringLength(40)]
        public string Ten { get; set; }

        public bool? GioiTinh { get; set; }

        //[StringLength(15)]
        public string SoCMT { get; set; }

        //[StringLength(15)]
        public string SoDienThoai { get; set; }

        //[StringLength(100)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DATPHONG> DATPHONGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THUEPHONG> THUEPHONGs { get; set; }
    }
}
