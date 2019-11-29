using Microsoft.EntityFrameworkCore;
using webapp.Data.Entities;

namespace webapp.Data
{
    public class ValueDbContext : DbContext
    {
        public ValueDbContext(DbContextOptions<ValueDbContext> options) : base(options)
        {
            
        }

        public DbSet<ValueEntity> Values { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ValueEntity>()
                .HasKey(p => p.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
