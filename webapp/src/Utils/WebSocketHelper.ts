import {HubConnection, HubConnectionBuilder, LogLevel} from "@microsoft/signalr";
import {URLS} from "../Consts/URLS";

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

    async Start(){
        try{
            await this.Connection.start();
            console.log("Starting websocket server...");
        } catch(err){ setTimeout(this.Start, 5000);}
    }
}