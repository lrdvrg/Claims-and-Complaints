namespace ClaimsAndComplaints.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ComplaintResponse")]
    public partial class ComplaintResponse
    {
        [Key]
        public int IdComplaintResponse { get; set; }

        public int? IdComplaint { get; set; }

        public int? IdEmployee { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ResponseDate { get; set; }

        [StringLength(300)]
        public string detail { get; set; }

        public virtual Complaint Complaint { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
