using System.Numerics;

namespace ForzaTelemetryServer.Objects
{
    public class GForceReturn
    {
        public double Value { get; set; } = 0;
        public Vector2 Accel {  get; set; } = new();
    }
}
