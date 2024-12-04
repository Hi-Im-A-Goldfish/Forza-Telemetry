import {BrowserRouter, Route, Routes} from "react-router";
import LiveFeedPage from "../Pages/LiveFeedPage";

export default function Routing(){
    return (
        <>
            <BrowserRouter>
                <Routes>
                    <Route>
                        <Route index element={<LiveFeedPage />} />
                    </Route>
                </Routes>
            </BrowserRouter>
        </>
    )
}