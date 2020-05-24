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
            SUDUNGDICHVUs = new HashSet<SUDUNGDICHVU>();
            THANHTOANs = new HashSet<THANHTOAN>();
        }

        public int ID { get; set; }

        public string ma { get; set; }

        public int? NGUOIDUNG_ID { get; set; }

        public int? KHACHHANG_ID { get; set; }

        public virtual ICollection<CHITIETTHUEPHONG> CHITIETTHUEPHONGs { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }

        public virtual ICollection<SUDUNGDICHVU> SUDUNGDICHVUs { get; set; }

        public virtual ICollection<THANHTOAN> THANHTOANs { get; set; }
    }
}
