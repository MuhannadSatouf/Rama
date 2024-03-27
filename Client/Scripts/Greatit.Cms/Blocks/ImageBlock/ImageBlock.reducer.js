import { IMAGE_BLOCK_RECEIVE, IMAGE_BLOCK_ERROR } from './ImageBlock.action';
import { error as errorReducer } from '../../../Reducers/Error.reducer';

const defaultState = {
    result: []
}
export const ImageReducer = (state = defaultState, action) => {
    switch (action.type) {
        case IMAGE_BLOCK_RECEIVE:
            return {
                ...state,
                result: [...state.result, action.payload],
            }
        case IMAGE_BLOCK_ERROR:
            return {
                ...state,
                errors: errorReducer(state.errors, action)
            }
        default:
            return state;
    }
}