interface IPedalSlider {
    Colour: string,
    Value: number,
    Title: string
}

export default function PedalSlider({Colour, Value, Title}: IPedalSlider) {
    return (
        <>
            <div>
                <h4>{Title}</h4>
                <div className="border position-relative" style={{height: '100px', width: '30px'}}>
                    <div className="position-absolute bottom-0 w-100"
                         style={{backgroundColor: Colour, height: `${(Value / 255) * 100}%`}}/>
                </div>
            </div>
        </>
    );
}