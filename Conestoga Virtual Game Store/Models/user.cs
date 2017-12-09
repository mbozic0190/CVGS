namespace Conestoga_Virtual_Game_Store.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            event_registration = new HashSet<event_registration>();
            events = new HashSet<_event>();
            order_shipments = new HashSet<order_shipments>();
            orders = new HashSet<order>();
            reviews = new HashSet<review>();
            reviews1 = new HashSet<review>();
            wishlists = new HashSet<wishlist>();
        }

        [Key]
        public int user_id { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Is Employee")]
        public string employee_flag { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Display Name")]
        public string display_name { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "First Name")]
        public string first_name { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Last Name")]
        public string last_name { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [Display(Name = "Birthday")]
        public DateTime? birth_date { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [StringLength(1)]
        [Display(Name = "Gender")]
        public string gender { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Recieve Promotional Emails")]
        public string promotional_emails { get; set; }

        [Display(Name = "Favourite Category")]
        public int? category_id { get; set; }

        [Display(Name = "Favourite Platform")]
        public int? platform_id { get; set; }

        public virtual category category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<event_registration> event_registration { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<_event> events { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_shipments> order_shipments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> orders { get; set; }

        public virtual platform platform { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<review> reviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<review> reviews1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wishlist> wishlists { get; set; }
    }
}
