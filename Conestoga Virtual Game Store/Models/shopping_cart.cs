namespace Conestoga_Virtual_Game_Store.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class shopping_cart
    {
        [Key]
        public int shopping_cart_id { get; set; }

        public int user_id { get; set; }

        public int? platform_id { get; set; }

        public int? quantity { get; set; }
    }
}
