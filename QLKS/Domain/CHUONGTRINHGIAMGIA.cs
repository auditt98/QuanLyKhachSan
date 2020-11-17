namespace QLKS.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHUONGTRINHGIAMGIA")]
    public partial class CHUONGTRINHGIAMGIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHUONGTRINHGIAMGIA()
        {
            LOAIPHONGs = new HashSet<LOAIPHONG>();
        }

        public int ID { get; set; }

        //[Required]
        //[StringLength(10)]
        public string Ma { get; set; }

        //[Required]
        //[StringLength(50)]
        public string Ten { get; set; }

        public double TiLeGiamGia { get; set; }

        public DateTime TuNgay { get; set; }

        public DateTime DenNgay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOAIPHONG> LOAIPHONGs { get; set; }
    }
}
