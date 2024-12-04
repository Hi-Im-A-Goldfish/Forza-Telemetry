import CentralContainer from "../Components/Universal/CentralContainer";
import {LiveFeedContext, WSContext} from "../Components/Universal/Contexts";
import {useContext, useState} from "react";
import {LiveFeedResponse} from "../Types/LiveFeedTypes";

export default function LiveFeedPage() {
    const [liveFeed, setLiveFeed] = useState<LiveFeedResponse>();
    const {Connection} = useContext(WSContext);

    Connection.on("LiveFeedSend", (response: LiveFeedResponse) => setLiveFeed(response));

    return (
        <>
            <LiveFeedContext.Provider value={{liveFeed}}>
                <CentralContainer>
                    Test
                </CentralContainer>
            </LiveFeedContext.Provider>
        </>
    );
}