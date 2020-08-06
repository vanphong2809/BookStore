namespace BookStoreFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BOOKS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BOOKS()
        {
            ORDERDETAIL = new HashSet<ORDERDETAIL>();
            WHISHLIST = new HashSet<WHISHLIST>();
        }

        public int ID { get; set; }

        [StringLength(255)]
        public string TITLE { get; set; }

        public string EXCERPT { get; set; }

        public string DESCRIPTION { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PUBLISH_DATE { get; set; }

        public int? PRICE { get; set; }

        [StringLength(255)]
        public string BOOK_URL { get; set; }

        [StringLength(255)]
        public string PREVIEW { get; set; }

        public int? PUBLISHER_ID { get; set; }

        public int? AUTHOR_ID { get; set; }

        public int? GENRE_ID { get; set; }

        public virtual AUTHOR AUTHOR { get; set; }

        public virtual GENRE GENRE { get; set; }

        public virtual PUBLISHER PUBLISHER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDERDETAIL> ORDERDETAIL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WHISHLIST> WHISHLIST { get; set; }
    }
}
