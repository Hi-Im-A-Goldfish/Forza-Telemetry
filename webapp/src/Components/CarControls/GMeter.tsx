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
                    <p className="mb-0 position-absolute top-50 translate-middle-y end-0">{MaxG}</p>
                    <p className="mb-0 position-absolute top-50 translate-middle-y start-0">{-MaxG}</p>
                    <p className="mb-0 position-absolute top-0 translate-middle-x start-50">{MaxG}</p>
                    <p className="mb-0 position-absolute bottom-0 translate-middle-x start-50">{-MaxG}</p>
                </div>
                <h4 className="text-center">{AccelValue?.toFixed(2)}G</h4>
            </div>
        </>
    );
}