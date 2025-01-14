import CentralContainer from "../Components/Universal/CentralContainer";
import { LiveFeedContext, WSContext } from "../Components/Universal/Contexts";
import { useContext, useState } from "react";
import { LiveFeedResponse } from "../Types/LiveFeedTypes";
import PedalSlider from "../Components/CarControls/PedalSlider";
import FlexRow from "../Components/Universal/FlexRow";
import RevCount from "../Components/CarControls/RevCount";
import GMeter from "../Components/CarControls/GMeter";
import { URLS } from "../Consts/URLS";

export default function LiveFeedPage() {
    const [liveFeed, setLiveFeed] = useState<LiveFeedResponse>();
    const { Connection } = useContext(WSContext);


    Connection.on("LiveFeedSend", (response: LiveFeedResponse) => setLiveFeed(response));

    return (
        <>
            <LiveFeedContext.Provider value={{ liveFeed }}>
                <CentralContainer>
                    <FlexRow>
                        <GMeter AccelValue={liveFeed?.gForceValue ?? 0} VectorValue={liveFeed?.gForceVector ?? { x: 0, y: 0 }} />
                        <RevCount Rpm={liveFeed?.currentEngineRpm ?? 0} MaxRpm={liveFeed?.engineMaxRpm ?? 0} />
                        <PedalSlider Colour={"#00ff00"} Value={liveFeed?.accelerator ?? 0} Title={"Accel"} />
                        <PedalSlider Colour={"#ff0000"} Value={liveFeed?.brake ?? 0} Title={"Brake"} />
                    </FlexRow>
                </CentralContainer>
            </LiveFeedContext.Provider>
        </>
    );
}