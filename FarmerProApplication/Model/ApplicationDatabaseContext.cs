using FarmerProApplication.Model.DatabaseModels;
using FarmerProApplication.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace FarmerProApplication.Model
{
    public class ApplicationDatabaseContext : DbContext
    {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Norm> Norms { get; set; }
        public DbSet<Korm> Korms { get; set; }
        public DbSet<Cow> Cows { get; set; }
    }
}
