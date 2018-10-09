using SoftJail.Data.Models;

namespace SoftJail.Data
{
	using Microsoft.EntityFrameworkCore;

    public class SoftJailDbContext : DbContext
    {
        public SoftJailDbContext()
        {
        }

        public SoftJailDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Prisoner> Prisoners { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<OfficerPrisoner> OfficersPrisoners { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Cell> Cells { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OfficerPrisoner>().HasKey(key => new {key.OfficerId, key.PrisonerId});

            builder.Entity<OfficerPrisoner>()
                .HasOne(x => x.Prisoner)
                .WithMany(x => x.PrisonerOfficers)
                .HasForeignKey(x => x.PrisonerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Prisoner>().Property(x => x.Bail).IsRequired(false);
        }
    }
}