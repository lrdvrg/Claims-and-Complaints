namespace ClaimsAndComplaints.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            ComplaintResponse = new HashSet<ComplaintResponse>();
            ReclaimResponse = new HashSet<ReclaimResponse>();
        }

        [Key]
        public int IdEmployee { get; set; }

        [StringLength(60)]
        public string Name { get; set; }

        [StringLength(15)]
        public string DocumentNo { get; set; }

        [StringLength(13)]
        public string Phone { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date, ErrorMessage = "Tiene que ser una fecha")]
        public DateTime? JoinDate { get; set; }

        public int? IdDepartment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComplaintResponse> ComplaintResponse { get; set; }

        public virtual Department Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReclaimResponse> ReclaimResponse { get; set; }
    }
}
