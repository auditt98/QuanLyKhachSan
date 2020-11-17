namespace QLKS.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SUDUNGDICHVU")]
    public partial class SUDUNGDICHVU
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CHITIETTHUEPHONG_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DICHVU_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime ThoiGianSuDung { get; set; }

        public int SoLuong { get; set; }

        public int? DonGia { get; set; }

        public int? NGUOIDUNG_ID { get; set; }

        public virtual CHITIETTHUEPHONG CHITIETTHUEPHONG { get; set; }

        public virtual DICHVU DICHVU { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }
    }
}
