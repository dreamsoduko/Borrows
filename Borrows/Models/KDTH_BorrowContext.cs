using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Borrows.Models
{
    public partial class KDTH_BorrowContext : DbContext
    {
        public KDTH_BorrowContext()
        {
        }

        public KDTH_BorrowContext(DbContextOptions<KDTH_BorrowContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BorrowDb> BorrowDb { get; set; }
        public virtual DbSet<BorrowItem> BorrowItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=10.170.10.157,1433;Database=KDTH_Borrow;Trusted_Connection=false;User ID=sa;Password=abc123!@#");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<BorrowDb>(entity =>
            {
                entity.HasKey(e => e.BorrowId);


                entity.ToTable("borrow_db");

                entity.Property(e => e.BorrowId)
                    .HasColumnName("borrow_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BorrowStatus)
                    .HasColumnName("borrow_status")
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerName)
                    .HasColumnName("customer_name")
                    .HasMaxLength(50);

                entity.Property(e => e.EntryDate)
                    .HasColumnName("entry_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EntryName)
                    .HasColumnName("entry_name")
                    .HasMaxLength(50);

                entity.Property(e => e.HeadApproverDate)
                    .HasColumnName("head_approver_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.HeadApproverId).HasColumnName("head_approver_id");

                entity.Property(e => e.LogisticApproverDate)
                    .HasColumnName("logistic_approver_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogisticApproverId).HasColumnName("logistic_approver_id");

                entity.Property(e => e.ManagerApproverDate)
                    .HasColumnName("manager_approver_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ManagerApproverId).HasColumnName("manager_approver_id");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasMaxLength(20);

                entity.Property(e => e.RequestDate)
                    .HasColumnName("request_date")
                    .HasColumnType("date");

                entity.Property(e => e.RequestName)
                    .HasColumnName("request_name")
                    .HasMaxLength(50);

                entity.Property(e => e.SerialNo)
                    .HasColumnName("serial_no")
                    .HasMaxLength(20);

                entity.Property(e => e.ServiceCode)
                    .HasColumnName("service_code")
                    .HasMaxLength(20);
                
            });

            modelBuilder.Entity<BorrowItem>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.ToTable("borrow_item");

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BorrowId).HasColumnName("borrow_id");

                entity.Property(e => e.ItemBarcode)
                    .HasColumnName("item_barcode")
                    .HasMaxLength(50);

                entity.Property(e => e.ItemCode)
                    .HasColumnName("item_code")
                    .HasMaxLength(50);

                entity.Property(e => e.ItemDesc)
                    .HasColumnName("item_desc")
                    .HasMaxLength(50);

                entity.Property(e => e.ItemName)
                    .HasColumnName("item_name")
                    .HasMaxLength(50);

                entity.Property(e => e.ItemQty).HasColumnName("item_qty");

                entity.Property(e => e.ItemStatus)
                    .HasColumnName("item_status")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Borrow)
                    .WithMany(p => p.BorrowItem)
                    .HasForeignKey(d => d.BorrowId)
                    .HasConstraintName("FK_borrow_item_borrow_db");
            });
        }
    }
}
