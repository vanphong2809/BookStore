namespace BookStoreFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COMMENT")]
    public partial class COMMENT
    {
        public int ID { get; set; }

        public int? STATUS { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CREATED { get; set; }

        [StringLength(255)]
        public string EMAIL { get; set; }

        [StringLength(255)]
        public string NAME { get; set; }

        public string CONTENT { get; set; }

        public int? POST_ID { get; set; }

        public virtual POST POST { get; set; }
    }
}
