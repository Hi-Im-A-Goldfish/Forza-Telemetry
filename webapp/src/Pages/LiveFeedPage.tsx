import CentralContainer from "../Components/Universal/CentralContainer";
import {LiveFeedContext, WSContext} from "../Components/Universal/Contexts";
import {useContext, useState} from "react";
import {LiveFeedResponse} from "../Types/LiveFeedTypes";
import PedalSlider from "../Components/LiveFeed/PedalSlider";
import FlexRow from "../Components/Universal/FlexRow";

export default function LiveFeedPage() {
    const [liveFeed, setLiveFeed] = useState<LiveFeedResponse>();
    const {Connection} = useContext(WSContext);

    Connection.on("LiveFeedSend", (response: LiveFeedResponse) => setLiveFeed(response));

    return (
        <>
            <LiveFeedContext.Provider value={{liveFeed}}>
                <CentralContainer>
                    <FlexRow>
                    <PedalSlider Colour={"#00ff00"} Value={liveFeed?.accelerator ?? 0} Title={"Accelerator"} />
                    <PedalSlider Colour={"#ff0000"} Value={liveFeed?.brake ?? 0} Title={"Brake"} />
                    </FlexRow>
                </CentralContainer>
            </LiveFeedContext.Provider>
        </>
    );
}