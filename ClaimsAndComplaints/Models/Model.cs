namespace ClaimsAndComplaints.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Complaint> Complaint { get; set; }
        public virtual DbSet<ComplaintResponse> ComplaintResponse { get; set; }
        public virtual DbSet<ComplaintType> ComplaintType { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Reclaim> Reclaim { get; set; }
        public virtual DbSet<ReclaimResponse> ReclaimResponse { get; set; }
        public virtual DbSet<ReclaimType> ReclaimType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.DocumentNo)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Complaint>()
                .Property(e => e.detail)
                .IsUnicode(false);

            modelBuilder.Entity<ComplaintResponse>()
                .Property(e => e.detail)
                .IsUnicode(false);

            modelBuilder.Entity<ComplaintType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.DocumentNo)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Reclaim>()
                .Property(e => e.detail)
                .IsUnicode(false);

            modelBuilder.Entity<ReclaimResponse>()
                .Property(e => e.detail)
                .IsUnicode(false);

            modelBuilder.Entity<ReclaimType>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
