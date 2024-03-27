import { combineReducers } from 'redux';
import { ImageReducer } from '../Scripts/Greatit.Cms/Blocks/ImageBlock/ImageBlock.reducer';
import { ExampleReactPageReducer } from '../Scripts/Greatit.Cms/Pages/exampleReactPage/ExampleReactPage.reducer'; 

const staticReducers = {
    ImageReducer,
    ExampleReactPageReducer
};

const app = combineReducers(staticReducers);

export const createReducer = (asyncReducers) => {
    return combineReducers({
        ...staticReducers,
        ...asyncReducers,
    });
};

export default app;
