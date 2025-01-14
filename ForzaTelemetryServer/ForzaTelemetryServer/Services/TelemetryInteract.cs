using ForzaDataManager;
using ForzaTelemetryServer.Objects;
using ForzaTelemetryServer.Objects.TelemetryResponses;
using ForzaTelemetryServer.WebSocket;
using Mapster;
using Microsoft.AspNetCore.SignalR;
using System.Numerics;

namespace ForzaTelemetryServer.Services
{
    public static class InteractVars
    {
        public static bool Tracking { get; set; } = false;
    }

    public class TelemetryInteract : BackgroundService
    {
        private readonly IHubContext<TelemetryHub> HubContext;
        public TelemetryInteract(IHubContext<TelemetryHub> hubContext) { HubContext = hubContext; }

        public DataManager TelemetryManager = new();

        private GForceReturn GetGForce()
        {
            double NormalisedSpeed = Math.Floor(TelemetryManager.Data.Speed);

            if (NormalisedSpeed == 0) { return new(); }

            Vector2 Accel = new(TelemetryManager.Data.AccelerationX, TelemetryManager.Data.AccelerationZ);

            GForceReturn _return = new()
            {
                Accel = Accel.Adapt<Vector2D>().ReturnAsGravity(),
                Value = Accel.Length() / 9.8
            };

            return _return;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            TelemetryManager.Start();

            while (!stoppingToken.IsCancellationRequested)
            {
                LiveFeedResponse response = TelemetryManager.Data.Adapt<LiveFeedResponse>();

                GForceReturn GForce = GetGForce();
                response.GForceValue = GForce.Value;
                response.GForceVector = GForce.Accel;

                if (response.IsRaceOn)
                {
                    await HubContext.Clients.All.SendAsync("LiveFeedSend", response);
                    Console.WriteLine(InteractVars.Tracking);
                }

                await Task.Delay(50, stoppingToken);
            }
        }
    }
}
