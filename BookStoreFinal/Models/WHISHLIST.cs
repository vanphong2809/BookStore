namespace BookStoreFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WHISHLIST")]
    public partial class WHISHLIST
    {
        public int ID { get; set; }

        public int? BOOK_ID { get; set; }

        public int? CUSTOMER_ID { get; set; }

        public virtual BOOKS BOOKS { get; set; }

        public virtual CUSTOMERS CUSTOMERS { get; set; }
    }
}
