namespace Conestoga_Virtual_Game_Store.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class order_details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public order_details()
        {
            order_shipment_details = new HashSet<order_shipment_details>();
        }

        [Key]
        public int order_detail_id { get; set; }

        public int order_id { get; set; }

        public int game_platform_id { get; set; }

        [StringLength(1)]
        public string physical_copy { get; set; }

        public int? qty_ordered { get; set; }

        public virtual game_platforms game_platforms { get; set; }

        public virtual order order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_shipment_details> order_shipment_details { get; set; }
    }
}
