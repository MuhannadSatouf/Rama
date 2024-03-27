import React from 'react';
import ReactDOM from 'react-dom';
import app from "../../reducers";
import { composeWithDevTools } from 'redux-devtools-extension/developmentOnly';
import { applyMiddleware, createStore } from 'redux';
import thunk from 'redux-thunk';
import { Provider } from 'react-redux';
import DynamicComponent from '../../Components/DynamicComponent';

const store = createStore(
    app,
    preloadState,
    composeWithDevTools(applyMiddleware(thunk, historyMiddleware))
);


export const GreatItComponents = () => {

   
}
