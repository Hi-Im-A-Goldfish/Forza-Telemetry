using ForzaTelemetryServer.Models;
using ForzaTelemetryServer.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ForzaTelemetryServer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TrackedRoute> TrackedRoutes { get; set; }
        public DbSet<TrackedRoutePoint> TrackedRoutePoints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var Vector2DConverter = new ValueConverter<Vector2D, string>(
                v => $"{v.X};{v.Y}",
                s => string.IsNullOrWhiteSpace(s) ? new Vector2D() : new Vector2D(s.Split(new[] { ';' }).Select(v => double.Parse(v)).ToList())
            );

            modelBuilder.Entity<TrackedRoutePoint>().Property(x => x.GForceVector).HasConversion(Vector2DConverter);
        }
    }
}
