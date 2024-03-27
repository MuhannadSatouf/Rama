import React from 'react';
import ReactDOM from 'react-dom';
import app from "../Scripts/reducers";
import { composeWithDevTools } from 'redux-devtools-extension/developmentOnly';
import { applyMiddleware, createStore } from 'redux';
import thunk from 'redux-thunk';
import { Provider } from 'react-redux';
import DynamicComponent from '../Scripts/Components/DynamicComponent';
import ImageBlockContainer from '../Scripts/Greatit.Cms/Blocks/ImageBlock/ImageBlock.container';
const store = createStore(
    app,
    composeWithDevTools(applyMiddleware(thunk))
);

/*GreatItPageComponents();
GreatItBlockComponents();*/

export const GreatItComponents = () => {

    //Blocks

    if (document.getElementsByClassName('--imageBlock--').length > 0) {
        Array.from(document.getElementsByClassName('--imageBlock--')).forEach((block) => {
            const blockId = block.parentElement.getAttribute("data-block-id");
            if (blockId !== "") {
                ReactDOM.render(
                    <Provider store={store}>
                        <ImageBlockContainer {...{ blockId }} />
                    </Provider>,
                    block
                );
            }
        });
    }


    //Pages

    if (document.getElementById("exampleReactPage")) {
        const ExampleReactPageComponent = DynamicComponent({
            loader: () => import('../Scripts/Greatit.Cms/Pages/exampleReactPage/exampleReactPage.container'),
        });
        const pageId = document.getElementById("exampleReactPage").getAttribute("data-page-id");
        console.log("pageId", pageId)
        ReactDOM.render(
            <Provider store={store}>
                <ExampleReactPageComponent {...{ pageId }} />
            </Provider>,
            document.getElementById('exampleReactPage')
        );
    }
}
document.addEventListener("DOMContentLoaded", function (event) {
    GreatItComponents();
});

