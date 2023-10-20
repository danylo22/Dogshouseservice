using Dogshouseservice.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Dogshouseservice.API
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>()
                .HasIndex(d => d.Name)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dog> Dogs { get; set; }
    }
}
