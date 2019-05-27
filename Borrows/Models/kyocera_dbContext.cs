using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Borrows.Models
{
    public partial class kyocera_dbContext : DbContext
    {
        public kyocera_dbContext()
        {
        }

        public kyocera_dbContext(DbContextOptions<kyocera_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MenuL1> MenuL1 { get; set; }
        public virtual DbSet<MenuL2> MenuL2 { get; set; }
        public virtual DbSet<MenuL3> MenuL3 { get; set; }
        public virtual DbSet<MenuL4> MenuL4 { get; set; }
        public virtual DbSet<Nmhmemp> Nmhmemp { get; set; }

        // Unable to generate entity type for table 'dbo.MenuL1'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=10.170.9.12\\KDTH;Database=kyocera_db;Trusted_Connection=false;User ID=sa;Password=g8gvH,mugv=");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<MenuL1>(entity =>
            {
                entity.HasKey(e => e.L1ID);

                entity.Property(e => e.L1Name).HasMaxLength(50);

                entity.Property(e => e.L1Path).HasMaxLength(50);

                entity.Property(e => e.L1Link).HasMaxLength(50);

                entity.Property(e => e.L1Icon).HasMaxLength(50);

                entity.Property(e => e.Inactive).HasMaxLength(1);
            });

            modelBuilder.Entity<MenuL2>(entity =>
            {
                entity.HasKey(e => e.L2ID);

                entity.Property(e => e.L1ID).HasMaxLength(5);

                entity.Property(e => e.L2Name).HasMaxLength(50);

                entity.Property(e => e.L2Path).HasMaxLength(50);

                entity.Property(e => e.L2Link).HasMaxLength(50);

                entity.Property(e => e.L2LinkTarget).HasMaxLength(5);

                entity.Property(e => e.L2Icon).HasMaxLength(50);

                entity.Property(e => e.Inactive).HasMaxLength(1);
            });

            modelBuilder.Entity<MenuL3>(entity =>
            {
                entity.HasKey(e => e.L3ID);

                entity.Property(e => e.L2ID).HasMaxLength(5);

                entity.Property(e => e.L3Name).HasMaxLength(50);

                entity.Property(e => e.L3Path).HasMaxLength(50);

                entity.Property(e => e.L3Link).HasMaxLength(50);

                entity.Property(e => e.L3LinkTarget).HasMaxLength(5);

                entity.Property(e => e.L3Icon).HasMaxLength(50);

                entity.Property(e => e.Inactive).HasMaxLength(1);
            });

            modelBuilder.Entity<MenuL4>(entity =>
            {
                entity.HasKey(e => e.L4ID);

                entity.Property(e => e.L3ID).HasMaxLength(5);

                entity.Property(e => e.L4Name).HasMaxLength(50);

                entity.Property(e => e.L4Path).HasMaxLength(50);

                entity.Property(e => e.L4Link).HasMaxLength(50);

                entity.Property(e => e.L4LinkTarget).HasMaxLength(5);

                entity.Property(e => e.L4Icon).HasMaxLength(50);

                entity.Property(e => e.Inactive).HasMaxLength(1);
            });

            modelBuilder.Entity<Nmhmemp>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.ToTable("NMHMEMP");

                entity.Property(e => e.EmpId)
                    .HasColumnName("EmpID")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Adpass)
                    .HasColumnName("ADPass")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Aduser)
                    .HasColumnName("ADUser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CardId)
                    .HasColumnName("CardID")
                    .HasMaxLength(50);

                entity.Property(e => e.ChiefId)
                    .HasColumnName("ChiefID")
                    .HasMaxLength(5);

                entity.Property(e => e.CitrixPass)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CitrixUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailPass)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpCode).HasMaxLength(5);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FirstNameEng).HasMaxLength(255);

                entity.Property(e => e.ImageContent).HasColumnType("image");

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.LastNameEng).HasMaxLength(255);

                entity.Property(e => e.LevelCode).HasMaxLength(50);

                entity.Property(e => e.LevelEn).HasMaxLength(50);

                entity.Property(e => e.LevelTh).HasMaxLength(50);

                entity.Property(e => e.NickName).HasMaxLength(50);

                entity.Property(e => e.OrgDepName).HasMaxLength(255);

                entity.Property(e => e.OrgUnitCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OrgUnitName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PositionName).HasMaxLength(255);

                entity.Property(e => e.SkypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SkypePass)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.TitleEng).HasMaxLength(50);

                entity.Property(e => e.WorkingStatus).HasMaxLength(50);
            });

        }
    }
}
