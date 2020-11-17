namespace QLKS.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAIPHONG")]
    public partial class LOAIPHONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAIPHONG()
        {
            DATPHONGs = new HashSet<DATPHONG>();
            PHONGs = new HashSet<PHONG>();
            CHUONGTRINHGIAMGIAs = new HashSet<CHUONGTRINHGIAMGIA>();
        }

        public int ID { get; set; }

        //[Required]
        //[StringLength(50)]
        public string Ten { get; set; }

        //[Required]
        //[StringLength(10)]
        public string Ma { get; set; }

        public string AnhDaiDien { get; set; }

        public string ThongTin { get; set; }

        public int GiaThue { get; set; }

        public int? SoNguoiLon { get; set; }

        public int? SoTreEm { get; set; }

        public int? SoGiuongDon { get; set; }

        public int? SoGiuongDoi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DATPHONG> DATPHONGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHONG> PHONGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHUONGTRINHGIAMGIA> CHUONGTRINHGIAMGIAs { get; set; }
    }
}
