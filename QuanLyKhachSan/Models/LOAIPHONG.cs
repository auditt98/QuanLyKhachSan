namespace QuanLyKhachSan
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
            PHONGs = new HashSet<PHONG>();
        }

        [Key]
       
        public int ID { get; set; }

        [StringLength(50)]
        public string tenloaiphong { get; set; }

        public string ghichu { get; set; }

        public string anh { get; set; }

        public string khungnhin { get; set; }

        public int dientich { get; set; }

        public string giuong { get; set; }

        public int nguoilon { get; set; }

        public int trecon { get; set; }

        public string tiennghi { get; set; }

        public string thongtin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHONG> PHONGs { get; set; }
    }
}
