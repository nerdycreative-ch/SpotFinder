using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SpotFinder.Domain.IdentityModels;

namespace SpotFinder.Domain.Models
{
    public partial class SpotFinderDBContext : IdentityDbContext<ApplicationUser>
    {
        public SpotFinderDBContext()
        {
        }

        public SpotFinderDBContext(DbContextOptions<SpotFinderDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<SpotTypes> SpotTypes { get; set; }
        public virtual DbSet<Spots> Spots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Spots>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
