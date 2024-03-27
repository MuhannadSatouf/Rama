import { get } from "../../../Services/http";
import { catchError } from "../../../Actions/Error.action";

export const EXAMPLE_REACT_PAGE_RECEIVE = "EXAMPLE_REACT_PAGE_RECEIVE";
export const EXAMPLE_REACT_PAGE_ERROR = 'EXAMPLE_REACT_PAGE_ERROR';

export const fetchExamplePageData = (id) => (dispatch) => {
    return get('/api/exampleReactPage/' + id)
        .then(response => {
            return response.json(); 
        })
        .then(result => {
            dispatch(receive(result)); 
        })
        .catch(ex => {
            dispatch(catchError(ex, error => setError(error))); 
        });
}

export const receive = result => ({
    type: EXAMPLE_REACT_PAGE_RECEIVE,
    payload: result
})

export const setError = error => ({
    type: EXAMPLE_REACT_PAGE_ERROR,
    payload: {
        error,
    },
})