namespace Conestoga_Virtual_Game_Store.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class payment_type : DbContext
    {
        public payment_type()
            : base("name=payment_type")
        {
        }

        public virtual DbSet<payment_types> payment_types { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<payment_types>()
                .Property(e => e.payment_type_description)
                .IsUnicode(false);
        }
    }
}
