using ForzaDataManager;
using ForzaTelemetryServer.Data;
using ForzaTelemetryServer.Models;
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
        public static List<TrackedRoutePoint> RoutePoints = new();
        public static bool TrackedSaved { get; set; } = true;
    }

    public class TelemetryInteract : BackgroundService
    {
        private readonly IHubContext<TelemetryHub> HubContext;
        private readonly IServiceScopeFactory ScopeFactory;


        public TelemetryInteract(IHubContext<TelemetryHub> hubContext, IServiceScopeFactory scopeFactory)
        {
            HubContext = hubContext;
            ScopeFactory = scopeFactory;
        }

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

        private async Task HandleTrackedDataSave()
        {
            Console.WriteLine("Starting Tracked Data Save");

            using var scope = ScopeFactory.CreateAsyncScope();

            var DbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var Transaction = await DbContext.Database.BeginTransactionAsync();

            try
            {
                TrackedRoute newRoute = new() { Name = $"Route-{DateTime.Now}" };

                await DbContext.AddAsync(newRoute);
                await DbContext.SaveChangesAsync();

                InteractVars.RoutePoints.ForEach((rPoint) => { rPoint.TrackedRouteId = newRoute.Id; });

                await DbContext.AddRangeAsync(InteractVars.RoutePoints);
                await DbContext.SaveChangesAsync();

                await Transaction.CommitAsync();

                InteractVars.RoutePoints = new();
                InteractVars.TrackedSaved = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                await Transaction.RollbackAsync();
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            TelemetryManager.Start();

            while (!stoppingToken.IsCancellationRequested)
            {
                 if (TelemetryManager.Data.IsRaceOn) // Pause Data out on WS when in menu's
                {
                    LiveFeedResponse response = TelemetryManager.Data.Adapt<LiveFeedResponse>();

                    GForceReturn GForce = GetGForce();
                    response.GForceValue = GForce.Value;
                    response.GForceVector = GForce.Accel;

                    if (!InteractVars.Tracking) // Live Feed Data should pause when Tracking is enabled
                    {
                        if (!InteractVars.TrackedSaved) { await HandleTrackedDataSave(); }
                        await HubContext.Clients.All.SendAsync("LiveFeedSend", response);
                    }
                    else
                    {
                        TrackedRoutePoint routePoint = TelemetryManager.Data.Adapt<TrackedRoutePoint>();

                        GForceReturn PointGForce = GetGForce();
                        routePoint.GForceValue = PointGForce.Value;
                        routePoint.GForceVector = PointGForce.Accel;

                        InteractVars.RoutePoints.Add(routePoint);
                    }
                }

                if (!InteractVars.Tracking) await Task.Delay(75, stoppingToken);
                else await Task.Delay(500, stoppingToken);
            }
        }
    }
}
