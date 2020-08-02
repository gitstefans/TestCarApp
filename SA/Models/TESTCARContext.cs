using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SA.Models
{
    public partial class TESTCARContext : DbContext
    {
        public virtual DbSet<Car> Car { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-CK711NU\SQLExpress;Database=TESTCAR;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Body_Type)
                    .HasColumnName("body_type")
                    .HasMaxLength(50);

                entity.Property(e => e.Contact)
                    .HasColumnName("contact")
                    .HasMaxLength(50);

                entity.Property(e => e.Engine_Size)
                    .HasColumnName("engine_size")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Fuel_Type)
                    .HasColumnName("fuel_type")
                    .HasMaxLength(50);

                entity.Property(e => e.Is_Deleted).HasColumnName("is_deleted");

                entity.Property(e => e.Make)
                    .HasColumnName("make")
                    .HasMaxLength(50);

                entity.Property(e => e.Model)
                    .HasColumnName("model")
                    .HasMaxLength(50);

                entity.Property(e => e.Power_Kw).HasColumnName("power_kw");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.Year).HasColumnName("year");
            });
        }
    }
}
