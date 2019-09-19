using System;
using Exam.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam.Data
{
    public class ExamDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        public DbSet<Package> Packages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-R2VVJJ2\SQLEXPRESS; Database=Panda; Integrated Security=true");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receipt>().HasOne(r => r.Recipient).WithMany(u => u.Receipts)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
