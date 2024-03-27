import { EXAMPLE_REACT_PAGE_RECEIVE, EXAMPLE_REACT_PAGE_ERROR } from "./ExampleReactPage.action";
import { error as errorReducer } from '../../../Reducers/Error.reducer';

const defaultState = {
    result: []
}
export const ExampleReactPageReducer = (state = defaultState, action) => {
    switch (action.type) {
        case EXAMPLE_REACT_PAGE_RECEIVE:
            return {
                ...state,
                result: [...state.result, action.payload],
            }
        case EXAMPLE_REACT_PAGE_ERROR:
            return {
                ...state, 
                errors: errorReducer(state.errors, action)
            }
        default:
            return state;
    }
}