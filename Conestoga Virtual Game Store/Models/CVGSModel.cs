namespace Conestoga_Virtual_Game_Store.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CVGSModel : DbContext
    {
        public CVGSModel()
            : base("name=CVGSModel")
        {
        }

        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<developer> developers { get; set; }
        public virtual DbSet<event_registration> event_registration { get; set; }
        public virtual DbSet<_event> events { get; set; }
        public virtual DbSet<game_platforms> game_platforms { get; set; }
        public virtual DbSet<game> games { get; set; }
        public virtual DbSet<order_details> order_details { get; set; }
        public virtual DbSet<order_shipment_details> order_shipment_details { get; set; }
        public virtual DbSet<order_shipments> order_shipments { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<platform> platforms { get; set; }
        public virtual DbSet<review> reviews { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<wishlist> wishlists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<category>()
                .Property(e => e.category_name)
                .IsUnicode(false);

            modelBuilder.Entity<category>()
                .HasMany(e => e.games)
                .WithRequired(e => e.category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<developer>()
                .Property(e => e.developer_name)
                .IsUnicode(false);

            modelBuilder.Entity<developer>()
                .HasMany(e => e.games)
                .WithRequired(e => e.developer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<_event>()
                .Property(e => e.event_name)
                .IsUnicode(false);

            modelBuilder.Entity<_event>()
                .Property(e => e.event_description)
                .IsUnicode(false);

            modelBuilder.Entity<_event>()
                .HasMany(e => e.event_registration)
                .WithRequired(e => e._event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<game_platforms>()
                .HasMany(e => e.order_details)
                .WithRequired(e => e.game_platforms)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<game_platforms>()
                .HasMany(e => e.reviews)
                .WithRequired(e => e.game_platforms)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<game>()
                .Property(e => e.game_name)
                .IsUnicode(false);

            modelBuilder.Entity<game>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<game>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<game>()
                .HasMany(e => e.game_platforms)
                .WithRequired(e => e.game)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<game>()
                .HasMany(e => e.wishlists)
                .WithRequired(e => e.game)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<order_details>()
                .Property(e => e.physical_copy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<order_details>()
                .HasMany(e => e.order_shipment_details)
                .WithRequired(e => e.order_details)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<order_shipments>()
                .HasMany(e => e.order_shipment_details)
                .WithRequired(e => e.order_shipments)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<order>()
                .HasMany(e => e.order_details)
                .WithRequired(e => e.order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<order>()
                .HasMany(e => e.order_shipments)
                .WithRequired(e => e.order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<platform>()
                .Property(e => e.platform_name)
                .IsUnicode(false);

            modelBuilder.Entity<platform>()
                .HasMany(e => e.game_platforms)
                .WithRequired(e => e.platform)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<review>()
                .Property(e => e.review_text)
                .IsUnicode(false);

            modelBuilder.Entity<review>()
                .Property(e => e.validated_flag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.employee_flag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.display_name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.gender)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.promotional_emails)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.event_registration)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.events)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.created_by)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.order_shipments)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.shipped_by)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.orders)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.reviews)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.reviews1)
                .WithOptional(e => e.user1)
                .HasForeignKey(e => e.validated_by);

            modelBuilder.Entity<user>()
                .HasMany(e => e.wishlists)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);
        }
    }
}
