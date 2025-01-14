using ForzaTelemetryServer.Objects.TelemetryResponses;
using System.ComponentModel.DataAnnotations;

namespace ForzaTelemetryServer.Models
{
    public class TrackedRoute : Base
    {
        public string? Name { get; set; }

        public List<TrackedRoutePoint> TrackedRoutePoints { get; set; }
    }

    public class TrackedRoutePoint : LiveFeedResponse
    {
        [Key]
        public int Id { get; set; }
        [Timestamp]
        public DateTime Created { get; set; }
        [Timestamp]
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }

        public int TrackedRouteId { get; set; }

        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float PositionZ { get; set; }

        public float TireTempFl { get; set; }
        public float TireTempFr { get; set; }
        public float TireTempRl { get; set; }
        public float TireTempRr { get; set; }

        public float TireSlipAngleFrontLeft { get; set; }
        public float TireSlipAngleFrontRight { get; set; }
        public float TireSlipAngleRearLeft { get; set; }
        public float TireSlipAngleRearRight { get; set; }

        public uint TimestampMS { get; set; }
    }
}
