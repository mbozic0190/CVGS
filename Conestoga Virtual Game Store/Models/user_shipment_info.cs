namespace Conestoga_Virtual_Game_Store.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user_shipment_info
    {
        [Key]
        public int shipment_id { get; set; }

        public int user_id { get; set; }

        [StringLength(50)]
        [Display(Name = "Address 1")]
        public string address_1 { get; set; }

        [StringLength(50)]
        [Display(Name = "Address 2")]
        public string address_2 { get; set; }

        [StringLength(25)]
        [Display(Name = "City")]
        public string city { get; set; }

        [StringLength(20)]
        [Display(Name = "Province")]
        public string province { get; set; }

        [StringLength(20)]
        [Display(Name = "Country")]
        public string country { get; set; }

        [StringLength(8)]
        [Display(Name = "Postal Code")]
        public string postal_code { get; set; }

        [StringLength(25)]
        [Display(Name = "First Name")]
        public string first_name { get; set; }

        [StringLength(25)]
        [Display(Name = "Last Name")]
        public string last_name { get; set; }
    }
}
