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

            builder.Services.AddSignalR();
            builder.Services.AddHostedService<TelemetryInteract>();

            var app = builder.Build();

            WebSocketOptions webSocketOpts = new() { KeepAliveInterval = TimeSpan.FromMinutes(5) };

            app.UseWebSockets(webSocketOpts);

            app.MapGet("/", () => "Forza Telemetry Server");
            app.MapHub<TelemetryHub>("/forza/temetry/ws");

            app.Run();
        }
    }
}
