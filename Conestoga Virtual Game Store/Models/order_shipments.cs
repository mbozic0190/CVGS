namespace Conestoga_Virtual_Game_Store.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class order_shipments
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public order_shipments()
        {
            order_shipment_details = new HashSet<order_shipment_details>();
        }

        [Key]
        public int order_shipment_id { get; set; }

        public int order_id { get; set; }

        public int shipped_by { get; set; }

        [Column(TypeName = "date")]
        public DateTime? shipment_date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_shipment_details> order_shipment_details { get; set; }

        public virtual order order { get; set; }

        public virtual user user { get; set; }
    }
}
