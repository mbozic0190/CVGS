namespace Conestoga_Virtual_Game_Store.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class payment_types
    {
        [Key]
        public int payment_type_id { get; set; }

        [StringLength(50)]
        public string payment_type_description { get; set; }
    }
}
