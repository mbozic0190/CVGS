namespace Conestoga_Virtual_Game_Store.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class game_collection
    {
        [Key]
        public int game_collection_id { get; set; }

        public int user_id { get; set; }

        public int? game_id { get; set; }
    }
}
