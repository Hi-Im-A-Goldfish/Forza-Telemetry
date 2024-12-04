import {ReactNode} from "react";

interface ICentralContainer {
    children?: ReactNode
}

export default function CentralContainer({children}: ICentralContainer) {
    return (
        <>
            <div className="w-100 vh-100 d-flex justify-content-center align-items-center">
                <div>
                    {children}
                </div>
            </div>
        </>
    )
}