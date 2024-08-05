using Microsoft.EntityFrameworkCore;
using Npgsql.NameTranslation;

namespace CloudWeather.Precipitation.DataAccess
{
    public class PrecipitationDBContext : DbContext
    {
        public PrecipitationDBContext() { }
        public PrecipitationDBContext(DbContextOptions opts) : base(opts) { }
    
        public DbSet<Precipitation> Precipitation { get; set; }
        
        public static void SnakeCaseIdentityTableNames(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Precipitation>(b => { b.ToTable("precipitation"); });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SnakeCaseIdentityTableNames(modelBuilder);
        }

    }
}
