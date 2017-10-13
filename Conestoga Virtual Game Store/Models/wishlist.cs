namespace Conestoga_Virtual_Game_Store.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class wishlist
    {
        [Key]
        public int wishlist_id { get; set; }

        public int user_id { get; set; }

        public int game_id { get; set; }

        public virtual game game { get; set; }

        public virtual user user { get; set; }
    }
}
