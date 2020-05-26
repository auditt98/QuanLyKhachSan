namespace QLKS.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETDATPHONG")]
    public partial class CHITIETDATPHONG
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PHONG_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DATPHONG_ID { get; set; }

        public string tenkhachhang { get; set; }

        public string socmt { get; set; }

        public string sodienthoai { get; set; }

        public string email { get; set; }

        public DateTime? ngaydukienden { get; set; }

        public DateTime? ngaydukiendi { get; set; }

        public virtual DATPHONG DATPHONG { get; set; }

        public virtual PHONG PHONG { get; set; }
    }
}
