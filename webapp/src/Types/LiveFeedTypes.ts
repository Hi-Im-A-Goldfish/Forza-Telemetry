import {Vector2} from "./Universal";

export type LiveFeedResponse = {
    isRaceOn: boolean,
    engineMaxRpm: number,
    currentEngineRpm: number,
    gForceVector: Vector2,
    gForceValue: number,
    speed: number,
    power: number,
    torque: number,
    accelerator: number,
    brake: number
}