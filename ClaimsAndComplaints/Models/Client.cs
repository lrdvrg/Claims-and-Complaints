namespace ClaimsAndComplaints.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Complaint = new HashSet<Complaint>();
            Reclaim = new HashSet<Reclaim>();
        }

        [Key]
        public int IdClient { get; set; }

        [StringLength(60)]
        public string Name { get; set; }

        [StringLength(15)]
        public string DocumentNo { get; set; }

        [StringLength(13)]
        public string Phone { get; set; }

        [StringLength(20)]
        public string email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Complaint> Complaint { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reclaim> Reclaim { get; set; }
    }
}
