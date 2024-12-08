interface IPedalSlider {
    Colour: string,
    Value: number,
    Title: string
}

export default function PedalSlider({Colour, Value, Title}: IPedalSlider) {
    return (
        <>
            <div className="mx-4">
                <div className="mx-auto border position-relative" style={{height: '4rem', width: '2rem'}}>
                    <div className="position-absolute bottom-0 w-100"
                         style={{backgroundColor: Colour, height: `${(Value / 255) * 100}%`}}/>
                </div>
                <h4>{Title}</h4>
            </div>
        </>
    );
}