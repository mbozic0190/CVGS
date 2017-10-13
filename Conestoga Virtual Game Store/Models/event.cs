namespace Conestoga_Virtual_Game_Store.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("events")]
    public partial class _event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public _event()
        {
            event_registration = new HashSet<event_registration>();
        }

        [Key]
        public int event_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? event_date { get; set; }

        public int created_by { get; set; }

        [StringLength(50)]
        public string event_name { get; set; }

        [Column(TypeName = "text")]
        public string event_description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<event_registration> event_registration { get; set; }

        public virtual user user { get; set; }
    }
}
