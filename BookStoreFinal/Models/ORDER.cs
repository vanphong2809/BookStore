namespace BookStoreFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDER")]
    public partial class ORDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDER()
        {
            ORDERDETAIL = new HashSet<ORDERDETAIL>();
        }

        public int ID { get; set; }

        [StringLength(255)]
        public string ADDRESS { get; set; }

        [StringLength(255)]
        public string EMAIL { get; set; }

        [StringLength(255)]
        public string PHONE { get; set; }

        public int? TOTALAMOUNT { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CREATED_DATE { get; set; }

        public bool? STATUS { get; set; }

        public int? PAYMENTMETHOD { get; set; }

        public int? CUSTOMER_ID { get; set; }

        public virtual CUSTOMERS CUSTOMERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDERDETAIL> ORDERDETAIL { get; set; }
    }
}
