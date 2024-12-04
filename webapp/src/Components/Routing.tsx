import {BrowserRouter, Route, Routes} from "react-router";
import LiveFeedPage from "../Pages/LiveFeedPage";
import WebSocketHelper from "../Utils/WebSocketHelper";
import {WSContext} from "./Universal/Contexts";

interface IRouting {
    WS: WebSocketHelper;
}

export default function Routing({WS}: IRouting) {
    return (
        <>
            <WSContext.Provider value={WS}>
                <BrowserRouter>
                    <Routes>
                        <Route>
                            <Route index element={<LiveFeedPage/>}/>
                        </Route>
                    </Routes>
                </BrowserRouter>
            </WSContext.Provider>
        </>
    )
}