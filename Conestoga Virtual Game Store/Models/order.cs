namespace Conestoga_Virtual_Game_Store.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class order
    {
        [Key]
        public int order_id { get; set; }

        public int user_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? order_date { get; set; }

        [Required]
        public int? payment_type_id { get; set; }

        public int? card_number { get; set; }

        [StringLength(50)]
        public string billing_address_1 { get; set; }

        [StringLength(50)]
        public string billing_address_2 { get; set; }

        [StringLength(25)]
        public string billing_city { get; set; }

        [StringLength(20)]
        public string billing_province { get; set; }

        [StringLength(20)]
        public string billing_country { get; set; }

        [StringLength(8)]
        public string billing_postal_code { get; set; }

        [StringLength(25)]
        public string billing_first_name { get; set; }

        [StringLength(25)]
        public string billing_last_name { get; set; }

        [StringLength(50)]
        public string shipping_address_1 { get; set; }

        [StringLength(50)]
        public string shipping_address_2 { get; set; }

        [StringLength(25)]
        public string shipping_city { get; set; }

        [StringLength(20)]
        public string shipping_province { get; set; }

        [StringLength(20)]
        public string shipping_country { get; set; }

        [StringLength(8)]
        public string shipping_postal_code { get; set; }

        [StringLength(25)]
        public string shipping_first_name { get; set; }

        [StringLength(25)]
        public string shipping_last_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_details> order_details { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_shipments> order_shipments { get; set; }

        public virtual user user { get; set; }
    }
}
