using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForzaDataManager
{
    public class DataPacket
    {
        // Sled
        public bool IsRaceOn { get; set; }
        public uint TimestampMS { get; set; }
        public float EngineMaxRpm { get; set; }
        public float EngineIdleRpm { get; set; }
        public float CurrentEngineRpm { get; set; }
        public float AccelerationX { get; set; }
        public float AccelerationY { get; set; }
        public float AccelerationZ { get; set; }
        public float VelocityX { get; set; }
        public float VelocityY { get; set; }
        public float VelocityZ { get; set; }
        public float AngularVelocityX { get; set; }
        public float AngularVelocityY { get; set; }
        public float AngularVelocityZ { get; set; }
        public float Yaw { get; set; }
        public float Pitch { get; set; }
        public float Roll { get; set; }
        public float NormalizedSuspensionTravelFrontLeft { get; set; }
        public float NormalizedSuspensionTravelFrontRight { get; set; }
        public float NormalizedSuspensionTravelRearLeft { get; set; }
        public float NormalizedSuspensionTravelRearRight { get; set; }
        public float TireSlipRatioFrontLeft { get; set; }
        public float TireSlipRatioFrontRight { get; set; }
        public float TireSlipRatioRearLeft { get; set; }
        public float TireSlipRatioRearRight { get; set; }
        public float WheelRotationSpeedFrontLeft { get; set; } // Radians/sec.
        public float WheelRotationSpeedFrontRight { get; set; }
        public float WheelRotationSpeedRearLeft { get; set; }
        public float WheelRotationSpeedRearRight { get; set; }
        public float WheelOnRumbleStripFrontLeft { get; set; }
        public float WheelOnRumbleStripFrontRight { get; set; }
        public float WheelOnRumbleStripRearLeft { get; set; }
        public float WheelOnRumbleStripRearRight { get; set; }
        public float WheelInPuddleDepthFrontLeft { get; set; } // 0 -> 1, where 1 is the deepest puddle
        public float WheelInPuddleDepthFrontRight { get; set; }
        public float WheelInPuddleDepthRearLeft { get; set; }
        public float WheelInPuddleDepthRearRight { get; set; }
        public float SurfaceRumbleFrontLeft { get; set; } // Controller FF Non-dimensional surface rumble values
        public float SurfaceRumbleFrontRight { get; set; }
        public float SurfaceRumbleRearLeft { get; set; }
        public float SurfaceRumbleRearRight { get; set; }
        public float TireSlipAngleFrontLeft { get; set; } // Tire normalized slip angle
        public float TireSlipAngleFrontRight { get; set; }
        public float TireSlipAngleRearLeft { get; set; }
        public float TireSlipAngleRearRight { get; set; }
        public float TireCombinedSlipFrontLeft { get; set; } // Tire normalized combined slip
        public float TireCombinedSlipFrontRight { get; set; }
        public float TireCombinedSlipRearLeft { get; set; }
        public float TireCombinedSlipRearRight { get; set; }
        public float SuspensionTravelMetersFrontLeft { get; set; } // Meters
        public float SuspensionTravelMetersFrontRight { get; set; }
        public float SuspensionTravelMetersRearLeft { get; set; }
        public float SuspensionTravelMetersRearRight { get; set; }
        public uint CarOrdinal { get; set; } // Car Unique ID
        public uint CarClass { get; set; } // 0 -> 7 inclusive
        public uint CarPerformanceIndex { get; set; } // 100 -> 999 inclusive
        public uint DrivetrainType { get; set; } // 0 = FWD, 1 = RWD, 2 = AWD
        public uint NumCylinders { get; set; }

        // Dash
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float PositionZ { get; set; }
        public float Speed { get; set; }
        public float Power { get; set; }
        public float Torque { get; set; }
        public float TireTempFl { get; set; }
        public float TireTempFr { get; set; }
        public float TireTempRl { get; set; }
        public float TireTempRr { get; set; }
        public float Boost { get; set; }
        public float Fuel { get; set; }
        public float Distance { get; set; }
        public float BestLapTime { get; set; }
        public float LastLapTime { get; set; }
        public float CurrentLapTime { get; set; }
        public float CurrentRaceTime { get; set; }
        public uint Lap { get; set; }
        public uint RacePosition { get; set; }
        public uint Accelerator { get; set; } // 0 -> 255
        public uint Brake { get; set; } // 0 -> 255
        public uint Clutch { get; set; } // 0 -> 255
        public uint Handbrake { get; set; }
        public uint Gear { get; set; }
        public int Steer { get; set; }
        public uint NormalDrivingLine { get; set; }
        public uint NormalAiBrakeDifference { get; set; }
    }
}
