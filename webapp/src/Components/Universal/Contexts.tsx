import {createContext} from "react";
import WebSocketHelper from "../../Utils/WebSocketHelper";

export const LiveFeedContext = createContext<any>(null);
export const WSContext = createContext<WebSocketHelper>(new WebSocketHelper());