namespace ForzaTelemetryServer.Objects
{
    public class Vector2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector2D ReturnAsGravity()
        {
            return new() { X = X / 9.8, Y = Y / 9.8 };
        }
    }
}
