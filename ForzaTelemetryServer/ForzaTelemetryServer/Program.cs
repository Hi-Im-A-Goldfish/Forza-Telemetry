using ForzaDataManager;
using ForzaTelemetryServer.Services;
using ForzaTelemetryServer.WebSocket;

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

            builder.Services.AddSignalR();
            builder.Services.AddHostedService<TelemetryInteract>();

            var app = builder.Build();

            WebSocketOptions webSocketOpts = new() { KeepAliveInterval = TimeSpan.FromMinutes(5) };

            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.SetIsOriginAllowed(_ => true);
                options.AllowCredentials();
            });

            app.UseAuthorization();

            app.UseWebSockets(webSocketOpts);

            app.MapGet("/", () => "Forza Telemetry Server");
            app.MapHub<TelemetryHub>("/forza/temetry/ws");

            app.Run();
        }
    }
}
