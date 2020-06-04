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
        public LOAIPHONG()
        {
            PHONGs = new HashSet<PHONG>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string tenloaiphong { get; set; }

        public string ghichu { get; set; }

        [StringLength(20)]
        public string ma { get; set; }

        [StringLength(500)]
        public string anh { get; set; }

        [StringLength(100)]
        public string khungnhin { get; set; }

        public int? dientich { get; set; }

        [StringLength(100)]
        public string giuong { get; set; }

        public int? nguoilon { get; set; }

        public int? trecon { get; set; }

        public string thongtin { get; set; }

        public virtual ICollection<PHONG> PHONGs { get; set; }
    }
}
