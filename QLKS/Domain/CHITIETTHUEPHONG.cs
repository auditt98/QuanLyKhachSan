namespace QLKS.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETTHUEPHONG")]
    public partial class CHITIETTHUEPHONG
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PHONG_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int THUEPHONG_ID { get; set; }

        public DateTime? ngayvao { get; set; }

        public DateTime? ngayra { get; set; }

        [StringLength(20)]
        public string maktra { get; set; }

        public int? NGUOIDUNG_ID { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }

        public virtual PHONG PHONG { get; set; }

        public virtual THUEPHONG THUEPHONG { get; set; }
    }
}
