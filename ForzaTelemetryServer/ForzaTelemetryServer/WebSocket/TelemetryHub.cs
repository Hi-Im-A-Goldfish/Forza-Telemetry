using Microsoft.AspNetCore.SignalR;

namespace ForzaTelemetryServer.WebSocket
{
    public class TelemetryHub : Hub
    {
        public async Task InitTeletryConnection()
        {
            await Clients.Caller.SendAsync("Recieved Init Connection");
        }
    }
}
