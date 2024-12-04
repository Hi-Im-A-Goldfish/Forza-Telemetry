import {ReactNode} from "react";

interface IFlexRow {
    children: ReactNode
}

export default function FlexRow({children}: IFlexRow) {
    return (
        <>
            <div className="d-flex">
                {children}
            </div>
        </>
    );
}