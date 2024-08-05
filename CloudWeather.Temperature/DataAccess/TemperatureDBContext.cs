using Microsoft.EntityFrameworkCore;

namespace CloudWeather.Temperature.DataAccess
{
    public class TemperatureDBContext : DbContext
    {
        public TemperatureDBContext() { }
        public TemperatureDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Temperature> Temperatures { get; set; }

        public static void SnakeCaseIdentityTableNames(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Temperature>(b => { b.ToTable("temperature"); });
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SnakeCaseIdentityTableNames(modelBuilder);
        }
    }
}
