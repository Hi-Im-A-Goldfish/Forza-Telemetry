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
            Console.WriteLine("Tracking");
            //InteractVars.Tracking = true;
            await Clients.Caller.SendAsync("Started Tracking");
        }
    }
}
