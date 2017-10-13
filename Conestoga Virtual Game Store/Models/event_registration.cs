namespace Conestoga_Virtual_Game_Store.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class event_registration
    {
        [Key]
        public int registration_id { get; set; }

        public int event_id { get; set; }

        public int user_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? registration_date { get; set; }

        public virtual _event _event { get; set; }

        public virtual user user { get; set; }
    }
}
