import React from 'react';
import ReactDOM from 'react-dom/client';
import './Styles/index.css';
import reportWebVitals from './reportWebVitals';
import Routing from "./Components/Routing";
import WebSocketHelper from "./Utils/WebSocketHelper";

const root = ReactDOM.createRoot(
    document.getElementById('root') as HTMLElement
);

const WS: WebSocketHelper = new WebSocketHelper();

WS.Start();

root.render(
    <React.StrictMode>
        <Routing WS={WS}/>
    </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
