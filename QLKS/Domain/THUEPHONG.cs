namespace QLKS.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THUEPHONG")]
    public partial class THUEPHONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THUEPHONG()
        {
            CHITIETTHUEPHONGs = new HashSet<CHITIETTHUEPHONG>();
            THANHTOANs = new HashSet<THANHTOAN>();
        }

        public int ID { get; set; }

        //[StringLength(20)]
        public string Ma { get; set; }

        public int? NGUOIDUNG_ID { get; set; }

        public int KHACHHANG_ID { get; set; }

        public DateTime? NgayDen { get; set; }

        public DateTime? NgayDi { get; set; }

        public int? LOAITINHTRANG_ID { get; set; }

        public DateTime? ThoiGianThue { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETTHUEPHONG> CHITIETTHUEPHONGs { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual LOAITINHTRANG LOAITINHTRANG { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THANHTOAN> THANHTOANs { get; set; }
    }
}
