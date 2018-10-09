namespace CNet.Data
{
    using System;

    using Microsoft.EntityFrameworkCore;

    using Models;

    public class CNetContext : DbContext
    {
        public CNetContext()
        {
            
        }

        public CNetContext(DbContextOptions options)
            :base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(e =>
            {
                e.HasOne(x => x.Manager)
                 .WithMany(x => x.ManagerEmployees)
                 .HasForeignKey(x => x.ManagerId);
            });
        }
    }
}
