namespace BookStoreFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CUSTOMERS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUSTOMERS()
        {
            ORDER = new HashSet<ORDER>();
            POST = new HashSet<POST>();
            WHISHLIST = new HashSet<WHISHLIST>();
        }

        public int ID { get; set; }

        [StringLength(255)]
        public string NAME { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập tên đăng nhập")]
        [StringLength(255)]
        public string USERNAME { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập tên mật khẩu")]

        [StringLength(255)]
        public string PASSWORD { get; set; }

        [StringLength(255)]
        public string AVATAR { get; set; }

        public bool? GENDER { get; set; }

        [StringLength(255)]
        public string ADDRESS { get; set; }

        [StringLength(255)]
        public string EMAIL { get; set; }

        [StringLength(255)]
        public string PHONE { get; set; }

        public int? ROLE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER> ORDER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POST> POST { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WHISHLIST> WHISHLIST { get; set; }
    }
}
