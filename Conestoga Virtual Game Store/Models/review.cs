namespace Conestoga_Virtual_Game_Store.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class review
    {
        [Key]
        public int review_id { get; set; }

        public int user_id { get; set; }

        public int game_platform_id { get; set; }

        [Column(TypeName = "text")]
        public string review_text { get; set; }

        [Required]
        [StringLength(1)]
        public string validated_flag { get; set; }

        public int? validated_by { get; set; }

        public virtual game_platforms game_platforms { get; set; }

        public virtual user user { get; set; }

        public virtual user user1 { get; set; }
    }
}
