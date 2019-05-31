using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Borrows.Models
{
    public partial class KDTH_1401Context : DbContext
    {
        public virtual DbSet<ItemDetails> itemDetail { get; set; }

        public KDTH_1401Context()
        {
        }

        public KDTH_1401Context(DbContextOptions<KDTH_1401Context> options)
            : base(options)
        {
        }

        public virtual DbSet<ItemDetails> Oitm { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=10.192.66.63;Database=KDTH_1401;Trusted_Connection=false;User ID=TH_Read;Password=Kdth@read");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<ItemDetails>(entity =>
            {
                entity.HasKey(e => e.ItemCode);

            });
        }
    }
}
