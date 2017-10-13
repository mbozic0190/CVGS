namespace Conestoga_Virtual_Game_Store.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public game()
        {
            game_platforms = new HashSet<game_platforms>();
            wishlists = new HashSet<wishlist>();
        }

        [Key]
        public int game_id { get; set; }

        [StringLength(50)]
        public string game_name { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Column(TypeName = "date")]
        public DateTime? release_date
        { get; set; }

        [Column(TypeName = "money")]
        public decimal price { get; set; }

        public int category_id { get; set; }

        public int developer_id { get; set; }

        public virtual category category { get; set; }

        public virtual developer developer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<game_platforms> game_platforms { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wishlist> wishlists { get; set; }
    }
}
