import { useState } from "react";
import FlexRow from "../Universal/FlexRow";

interface IRevCount {
    Rpm: number,
    MaxRpm: number
}

export default function RevCount({ Rpm, MaxRpm }: IRevCount) {
    const [RedLine, setRedLine] = useState(4000);

    function GetRevCountTop() {
        if (Rpm > RedLine) { setRedLine(Rpm); }

        return (Math.ceil(MaxRpm / 1000) * 1000) + 1000;
    }

    function GenerateLimitColour() {
        if (Rpm >= RedLine - 200) {
            return "#ff0000";
        }
        if (Rpm >= RedLine - 400) {
            return "#ff5900";
        }
        if (Rpm >= RedLine - 600) {
            return "#ffa200";
        } else {
            return "#ffffff";
        }
    }

    return (
        <>
            <div>
                <div className="mx-auto border position-relative" style={{ height: '2rem', width: '20rem' }}>
                    <div className="position-absolute start-0 h-100"
                        style={{
                            backgroundColor: `${GenerateLimitColour()}aa`,
                            width: `${(Rpm / GetRevCountTop()) * 100}%`
                        }} />
                    <div className="position-absolute end-0 h-100" style={{
                        backgroundColor: GenerateLimitColour(),
                        width: `${((GetRevCountTop() - RedLine) / GetRevCountTop()) * 100}%`
                    }} />
                </div>
                <div style={{ width: '20rem' }}>
                    <FlexRow style={{ width: `100%` }}>
                        {[...Array(GetRevCountTop() / 1000)].map((rev, key) =>
                            <h4 key={key} className="mb-0 me-auto">{key}</h4>
                        )}
                    </FlexRow>
                    <h3 className="text-center w-100">RPM x1000</h3>
                </div>
            </div>
        </>
    );
}