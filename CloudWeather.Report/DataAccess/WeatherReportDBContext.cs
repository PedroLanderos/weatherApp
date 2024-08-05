using Microsoft.EntityFrameworkCore;

namespace CloudWeather.Report.DataAccess
{
    public class WeatherReportDBContext : DbContext
    {
        public WeatherReportDBContext() { }
        public WeatherReportDBContext(DbContextOptions options) : base(options) { }
        public DbSet<WeatherReport> WeatherReports { get; set; }
        public static void SnakeCaseIdentityTableNames(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherReport>(b => { b.ToTable("weather_report"); });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SnakeCaseIdentityTableNames(modelBuilder);  
        }
    }
}
