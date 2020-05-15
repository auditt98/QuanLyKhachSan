namespace QuanLyKhachSan
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

        [Key]
        [StringLength(10)]
        public string iddat { get; set; }

        [StringLength(10)]
        public string idkhachhang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDATPHONG> CHITIETDATPHONGs { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
