using ForzaDataManager;
using ForzaTelemetryServer.Objects;
using ForzaTelemetryServer.Objects.TelemetryResponses;
using Mapster;
using System.Numerics;

namespace ForzaTelemetryServer.Services
{
    public class TelemetryInteract : BackgroundService
    {public DataManager TelemetryManager = new();

        private GForceReturn GetGForce()
        {
            double NormalisedSpeed = Math.Floor(TelemetryManager.Data.Speed);

            if (NormalisedSpeed == 0) { return new(); }

            Vector2 Accel = new(TelemetryManager.Data.AccelerationX, TelemetryManager.Data.AccelerationZ);

            GForceReturn _return = new()
            {
                Accel = Accel,
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
                response.GForceValue = GetGForce().Value;
                response.GForceVector = GetGForce().Accel;

                Console.WriteLine(response.ToString());

                await Task.Delay(20, stoppingToken);
            }
        }
    }
}
