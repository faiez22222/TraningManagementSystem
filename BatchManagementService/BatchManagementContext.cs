using BatchManagementService.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BatchManagementService
{
    public class BatchManagementContext : DbContext
    {
        public BatchManagementContext(DbContextOptions<BatchManagementContext> options) : base(options)
        {
        }

        public DbSet<Batch> Batches { get; set; }
        public DbSet<BatchEnrollment> BatchEnrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Batch to BatchEnrollment relationship (one-to-many)
            modelBuilder.Entity<Batch>()
                .HasMany(b => b.Enrollments)
                .WithOne()
                .HasForeignKey(be => be.BatchId)
                .OnDelete(DeleteBehavior.Cascade); // Configure delete behavior

            base.OnModelCreating(modelBuilder);
        }
    }
}
