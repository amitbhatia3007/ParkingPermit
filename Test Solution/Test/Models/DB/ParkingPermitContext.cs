using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SmartParkingPermit.Core.Models.DB
{
    public partial class ParkingPermitContext : DbContext
    {
        public ParkingPermitContext()
        {
        }

        public ParkingPermitContext(DbContextOptions<ParkingPermitContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ParkingPermit> ParkingPermit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=ParkingPermit;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<ParkingPermit>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApprovedBy).HasMaxLength(500);

                entity.Property(e => e.CarParkingId).HasMaxLength(500);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.EntityName).HasMaxLength(500);

                entity.Property(e => e.LicensePlate).HasMaxLength(500);

                entity.Property(e => e.Reason).HasMaxLength(500);

                entity.Property(e => e.ValidFrom).HasMaxLength(500);

                entity.Property(e => e.ValidUntil).HasMaxLength(500);
            });
        }
    }
}
