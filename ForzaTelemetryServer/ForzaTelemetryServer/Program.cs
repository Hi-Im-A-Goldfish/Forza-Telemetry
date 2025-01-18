using ForzaDataManager;
using ForzaTelemetryServer.Data;
using ForzaTelemetryServer.Services;
using ForzaTelemetryServer.WebSocket;
using Microsoft.EntityFrameworkCore;

namespace ForzaTelemetryServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration
                    .SetBasePath(builder.Environment.ContentRootPath)
                    .AddJsonFile("appsettings.json", true, true)
                    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
                    .AddEnvironmentVariables();

            builder.Services.AddCors();

            builder.Services.AddSignalR(o =>
            {
                o.EnableDetailedErrors = true;
            });
            builder.Services.AddHostedService<TelemetryInteract>();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            var app = builder.Build();

            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.SetIsOriginAllowed(_ => true);
                options.AllowCredentials();
            });

            app.UseAuthorization();

            app.MapGet("/", () => "Forza Telemetry Server");
            app.MapHub<TelemetryHub>("/forza/telemetry/ws");

            app.Run();
        }
    }
}
