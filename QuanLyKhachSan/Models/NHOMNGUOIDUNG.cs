namespace QuanLyKhachSan
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHOMNGUOIDUNG")]
    public partial class NHOMNGUOIDUNG
    {
        public NHOMNGUOIDUNG()
        {
            NGUOIDUNGs = new HashSet<NGUOIDUNG>();
            QUYENs = new HashSet<QUYEN>();
        }
        [Key]
        [StringLength(10)]
        public string idnhomnguoidung { get; set; }
        [StringLength(50)]
        public string tennhomnguoidung { get; set; }
        public virtual ICollection<NGUOIDUNG> NGUOIDUNGs { get; set; }
        public virtual ICollection<QUYEN> QUYENs { get; set; }
    }
}
