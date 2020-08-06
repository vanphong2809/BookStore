namespace BookStoreFinal.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class context : DbContext
    {
        public context()
            : base("name=context1")
        {
        }

        public virtual DbSet<AUTHOR> AUTHOR { get; set; }
        public virtual DbSet<BOOKS> BOOKS { get; set; }
        public virtual DbSet<COMMENT> COMMENT { get; set; }
        public virtual DbSet<CUSTOMERS> CUSTOMERS { get; set; }
        public virtual DbSet<GENRE> GENRE { get; set; }
        public virtual DbSet<ORDER> ORDER { get; set; }
        public virtual DbSet<ORDERDETAIL> ORDERDETAIL { get; set; }
        public virtual DbSet<POST> POST { get; set; }
        public virtual DbSet<PUBLISHER> PUBLISHER { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<WHISHLIST> WHISHLIST { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AUTHOR>()
                .HasMany(e => e.BOOKS)
                .WithOptional(e => e.AUTHOR)
                .HasForeignKey(e => e.AUTHOR_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<BOOKS>()
                .HasMany(e => e.ORDERDETAIL)
                .WithOptional(e => e.BOOKS)
                .HasForeignKey(e => e.BOOK_ID);

            modelBuilder.Entity<BOOKS>()
                .HasMany(e => e.WHISHLIST)
                .WithOptional(e => e.BOOKS)
                .HasForeignKey(e => e.BOOK_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CUSTOMERS>()
                .HasMany(e => e.ORDER)
                .WithOptional(e => e.CUSTOMERS)
                .HasForeignKey(e => e.CUSTOMER_ID);

            modelBuilder.Entity<CUSTOMERS>()
                .HasMany(e => e.POST)
                .WithOptional(e => e.CUSTOMERS)
                .HasForeignKey(e => e.CUSTOMER_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CUSTOMERS>()
                .HasMany(e => e.WHISHLIST)
                .WithOptional(e => e.CUSTOMERS)
                .HasForeignKey(e => e.CUSTOMER_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<GENRE>()
                .HasMany(e => e.BOOKS)
                .WithOptional(e => e.GENRE)
                .HasForeignKey(e => e.GENRE_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ORDER>()
                .HasMany(e => e.ORDERDETAIL)
                .WithOptional(e => e.ORDER)
                .HasForeignKey(e => e.ORDER_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<POST>()
                .HasMany(e => e.COMMENT)
                .WithOptional(e => e.POST)
                .HasForeignKey(e => e.POST_ID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<PUBLISHER>()
                .HasMany(e => e.BOOKS)
                .WithOptional(e => e.PUBLISHER)
                .HasForeignKey(e => e.PUBLISHER_ID)
                .WillCascadeOnDelete();
        }
    }
}
