namespace Conestoga_Virtual_Game_Store.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class order_shipment_details
    {
        [Key]
        public int order_shipment_detail_id { get; set; }

        public int order_detail_id { get; set; }

        public int? qty_ship { get; set; }

        public int order_shipment_id { get; set; }

        public virtual order_details order_details { get; set; }

        public virtual order_shipments order_shipments { get; set; }
    }
}
