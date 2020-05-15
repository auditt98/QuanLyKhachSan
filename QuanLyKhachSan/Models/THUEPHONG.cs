namespace QuanLyKhachSan
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
            SUDUNGDICHVUs = new HashSet<SUDUNGDICHVU>();
            THANHTOANs = new HashSet<THANHTOAN>();
        }

        [Key]
        [StringLength(10)]
        public string idthue { get; set; }

        [StringLength(10)]
        public string idnguoidung { get; set; }

        [StringLength(10)]
        public string idkhachhang { get; set; }

        public virtual CHITIETTHUEPHONG CHITIETTHUEPHONG { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUDUNGDICHVU> SUDUNGDICHVUs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THANHTOAN> THANHTOANs { get; set; }
    }
}
