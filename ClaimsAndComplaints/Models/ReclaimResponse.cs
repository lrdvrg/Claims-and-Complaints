namespace ClaimsAndComplaints.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReclaimResponse")]
    public partial class ReclaimResponse
    {
        [Key]
        public int IdReclaimResponse { get; set; }

        public int? IdReclaim { get; set; }

        public int? IdEmployee { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ResponseDate { get; set; }

        [StringLength(300)]
        public string detail { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Reclaim Reclaim { get; set; }
    }
}
