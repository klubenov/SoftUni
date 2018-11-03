using System;
using Microsoft.EntityFrameworkCore;
using Torshia.Models;

namespace Torshia.Data
{
    public class TorshiaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<TaskSector> TaskSectors { get; set; }

        public DbSet<Sector> Sectors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=Torshia; Integrated Security=true");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskSector>()
                .HasKey(ts => new {ts.SectorId, ts.TaskId});
        }
    }
}
