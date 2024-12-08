import { Vector2 } from "../../Types/Universal";

interface IGmeter {
    VectorValue: Vector2,
    AccelValue: number,
    MaxG?: number
}

export default function GMeter({ VectorValue, AccelValue, MaxG = 4 }: IGmeter) {
    function GetNormalisedG(_G: number){
        var G = ((_G + MaxG) / (MaxG * 2)) * 100

        if (G > 100) { return "100%"; }
        if (G < 0) { return "0%"; }
        return `${G}%`
    }

    return (
        <>
            <div>
                <div className="position-relative GMeterContainer">
                    <div className="GMeterLineH" />
                    <div className="GMeterLineV" />
                    <div className="GMeterDot translate-middle" style={{ top: GetNormalisedG(VectorValue.y), left: GetNormalisedG(VectorValue.x) }}></div>
                </div>
                <h4 className="text-center">{AccelValue?.toFixed(2)}G</h4>
            </div>
        </>
    );
}