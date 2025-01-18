import { HubConnection, HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
import { URLS } from "../Consts/URLS";

export default class WebSocketHelper {
    Connection: HubConnection;

    constructor() {
        this.Connection = new HubConnectionBuilder()
            .withUrl(URLS.WS)
            .withAutomaticReconnect()
            .configureLogging(LogLevel.Information)
            .build();

        this.Connection.onclose(async () => await this.Start())
    }

    async Start() {
        try {
            this.Connection.on("Started Tracking", () => console.log("Started Tracking"))
            this.Connection.on("Ended Tracking", () => console.log("Ended Tracking"))

            await this.Connection.start();
            console.log("Starting websocket server...");
        } catch (err) { setTimeout(this.Start, 5000); }
    }

    async StartTracking(Connection: HubConnection) {
        try {
            await Connection.invoke("startTracking");
            console.log("Starting telemetry tracking...");
        } catch (err) { console.error(err); }
    }

    async EndTracking(Connection: HubConnection) {
        try {
            await Connection.invoke("endTracking");
            console.log("Ending telemetry tracking...");
        } catch (err) { console.error(err); }
    }
}