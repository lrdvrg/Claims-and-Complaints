namespace ClaimsAndComplaints.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reclaim")]
    public partial class Reclaim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reclaim()
        {
            ReclaimResponse = new HashSet<ReclaimResponse>();
        }

        [Key]
        public int IdReclaim { get; set; }

        public int? IdClient { get; set; }

        public int? IdProduct { get; set; }

        public int? IdReclaimType { get; set; }

        public int? IdDepartment { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date, ErrorMessage = "Tiene que ser una fecha")]
        public DateTime? CreationDate { get; set; }

        [StringLength(300)]
        public string detail { get; set; }

        public virtual Client Client { get; set; }

        public virtual Product Product { get; set; }

        public virtual ReclaimType ReclaimType { get; set; }

        public virtual Department Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReclaimResponse> ReclaimResponse { get; set; }
    }
}
