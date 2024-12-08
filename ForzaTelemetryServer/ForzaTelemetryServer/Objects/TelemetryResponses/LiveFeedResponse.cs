using System.Numerics;

namespace ForzaTelemetryServer.Objects.TelemetryResponses
{
    public class LiveFeedResponse
    {
        private double _EngineMaxRpm;
        private double _CurrentEngineRpm;
        private float _Power;

        public bool IsRaceOn { get; set; }
        public float EngineMaxRpm { get => (float)_EngineMaxRpm; set => _EngineMaxRpm = Math.Ceiling(value); }
        public float CurrentEngineRpm { get => (float)_CurrentEngineRpm; set => _CurrentEngineRpm = Math.Floor(value); }
        public Vector2D GForceVector { get; set; }
        public double GForceValue { get; set; }
        public float Speed { get; set; }
        public float Power { get => _Power; set => _Power = value > 0 ? (value / 745.7f) : 0; }
        public float Torque { get; set; }
        public float Accelerator { get; set; }
        public float Brake { get; set; }

        public LiveFeedResponse()
        {
            CurrentEngineRpm = (float)Math.Floor(CurrentEngineRpm);
        }

        public override string ToString()
        {
            string _return = $"\nRace On: {IsRaceOn}\nEngine Max RPM: {EngineMaxRpm}\nEngine Current RPM: {CurrentEngineRpm}\nGForce Vector: {GForceVector}\nGForce Value: {GForceValue}\nSpeed: {Speed}\nPower: {Power}\nTorque: {Torque}\nAccelerator: {Accelerator}\nBrake: {Brake}\n";

            return _return;
        }
    }
}
