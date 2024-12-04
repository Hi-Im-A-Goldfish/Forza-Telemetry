import {Vector2} from "./Universal";

export type LiveFeedResponse = {
    IsRaceOn: boolean,
    EngineMaxRpm: number,
    CurrentEngineRpm: number,
    GForceVector: Vector2,
    GForceValue: number,
    Speed: number,
    Power: number,
    Torque: number,
    Accelerator: number,
    Brake: number
}