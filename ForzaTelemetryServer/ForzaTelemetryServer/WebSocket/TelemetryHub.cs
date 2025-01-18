using ForzaTelemetryServer.Services;
using Microsoft.AspNetCore.SignalR;

namespace ForzaTelemetryServer.WebSocket
{
    public class TelemetryHub : Hub
    {
        public async Task InitTelemetryConnection()
        {
            await Clients.Caller.SendAsync("Recieved Init Connection");
        }

        public async Task StartTracking()
        {
            InteractVars.Tracking = true;
            InteractVars.TrackedSaved = false;

            await Clients.Caller.SendAsync("Started Tracking");
        }

        public async Task EndTracking()
        {
            InteractVars.Tracking = false;

            await Clients.Caller.SendAsync("Ended Tracking");
        }
    }
}
