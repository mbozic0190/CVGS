namespace Conestoga_Virtual_Game_Store.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user_payment_info
    {
        [Key]
        public int payment_id { get; set; }

        public int user_id { get; set; }

        public int payment_type_id { get; set; }

        public int? card_number { get; set; }

        [StringLength(50)]
        public string address_1 { get; set; }

        [StringLength(50)]
        public string address_2 { get; set; }

        [StringLength(25)]
        public string city { get; set; }

        [StringLength(20)]
        public string province { get; set; }

        [StringLength(20)]
        public string country { get; set; }

        [StringLength(8)]
        public string postal_code { get; set; }

        [StringLength(25)]
        public string first_name { get; set; }

        [StringLength(25)]
        public string last_name { get; set; }
    }
}
