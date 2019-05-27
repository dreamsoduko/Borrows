using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Borrows.Models
{
    public partial class Astea_TH_1401Context : DbContext
    {
        public virtual DbSet<ServiceDetails> serviceDetail { get; set; }

        public Astea_TH_1401Context()
        {
        }

        public Astea_TH_1401Context(DbContextOptions<Astea_TH_1401Context> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=10.192.64.211\\astea_as;Database=Astea_TH_1401;Trusted_Connection=false;User ID=sa;Password=Kyocer@m1ta");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<ServiceDetails>(entity =>
            {
                entity.HasKey(e => e.RequestID);

                //entity.Property(e => e.)
                //    .HasColumnName("borrow_id")
                //    .ValueGeneratedOnAdd();

                //entity.Property(e => e.BorrowStatus)
                //    .HasColumnName("borrow_status")
                //    .HasMaxLength(50);

                //entity.Property(e => e.CustomerName)
                //    .HasColumnName("customer_name")
                //    .HasMaxLength(50);

                //entity.Property(e => e.EntryDate)
                //    .HasColumnName("entry_date")
                //    .HasColumnType("datetime");

                //entity.Property(e => e.EntryName)
                //    .HasColumnName("entry_name")
                //    .HasMaxLength(50);

                //entity.Property(e => e.HeadApproverDate)
                //    .HasColumnName("head_approver_date")
                //    .HasColumnType("datetime");

                //entity.Property(e => e.HeadApproverId).HasColumnName("head_approver_id");

                //entity.Property(e => e.LogisticApproverDate)
                //    .HasColumnName("logistic_approver_date")
                //    .HasColumnType("datetime");

                //entity.Property(e => e.LogisticApproverId).HasColumnName("logistic_approver_id");

                //entity.Property(e => e.ManagerApproverDate)
                //    .HasColumnName("manager_approver_date")
                //    .HasColumnType("datetime");

                //entity.Property(e => e.ManagerApproverId).HasColumnName("manager_approver_id");

                //entity.Property(e => e.ProductId)
                //    .HasColumnName("product_id")
                //    .HasMaxLength(20);

                //entity.Property(e => e.RequestDate)
                //    .HasColumnName("request_date")
                //    .HasColumnType("date");

                //entity.Property(e => e.RequestName)
                //    .HasColumnName("request_name")
                //    .HasMaxLength(50);

                //entity.Property(e => e.SerialNo)
                //    .HasColumnName("serial_no")
                //    .HasMaxLength(20);

                //entity.Property(e => e.ServiceCode)
                //    .HasColumnName("service_code")
                //    .HasMaxLength(20);
            });
        }
    }
}
