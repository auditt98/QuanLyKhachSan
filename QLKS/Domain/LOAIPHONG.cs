namespace QLKS.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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

        [DisplayName("Tên loại phòng")]
        public string tenloaiphong { get; set; }

        [DisplayName("Ghi chú")]
        public string ghichu { get; set; }

        [DisplayName("Giá")]
        public string ma { get; set; }

        [DisplayName("Ảnh")]
        public string anh { get; set; }

        [DisplayName("View")]
        public string khungnhin { get; set; }

        [DisplayName("Diện tích")]
        public int? dientich { get; set; }

        [DisplayName("Giường")]
        public string giuong { get; set; }

        [DisplayName("Sỗ người lớn")]
        public int? nguoilon { get; set; }

        [DisplayName("Số trẻ em")]
        public int? trecon { get; set; }

        [DisplayName("Thông tin")]
        public string thongtin { get; set; }

        public virtual ICollection<PHONG> PHONGs { get; set; }
    }
}
