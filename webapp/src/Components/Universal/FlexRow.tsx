import {CSSProperties, ReactNode} from "react";

interface IFlexRow {
    children: ReactNode,
    className?: string,
    style?: CSSProperties
}

export default function FlexRow({children, className, style}: IFlexRow) {
    return (
        <>
            <div className={`d-flex ${className}`} style={style}>
                {children}
            </div>
        </>
    );
}