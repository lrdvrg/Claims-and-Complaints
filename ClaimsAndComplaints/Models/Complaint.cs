namespace ClaimsAndComplaints.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Complaint")]
    public partial class Complaint
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Complaint()
        {
            ComplaintResponse = new HashSet<ComplaintResponse>();
        }

        [Key]
        public int IdComplaint { get; set; }

        public int? IdClient { get; set; }

        public int? IdProduct { get; set; }

        public int? IdComplaintType { get; set; }

        public int? IdDepartment { get; set; }


        [Column(TypeName = "date")]
        [DataType(DataType.Date, ErrorMessage = "Tiene que ser una fecha")]
        public DateTime? CreationDate { get; set; }

        [StringLength(300)]
        public string detail { get; set; }

        public virtual Client Client { get; set; }

        public virtual ComplaintType ComplaintType { get; set; }

        public virtual Department Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComplaintResponse> ComplaintResponse { get; set; }

        public virtual Product Product { get; set; }
    }
}
