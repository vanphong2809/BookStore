namespace BookStoreFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDERDETAIL")]
    public partial class ORDERDETAIL
    {
        public int ID { get; set; }

        public int? AMOUNT { get; set; }

        public int? PRICE { get; set; }

        public int? QUANTITY { get; set; }

        [StringLength(255)]
        public string NOTE { get; set; }

        public int? ORDER_ID { get; set; }

        public int? BOOK_ID { get; set; }

        public virtual BOOKS BOOKS { get; set; }

        public virtual ORDER ORDER { get; set; }
    }
}
