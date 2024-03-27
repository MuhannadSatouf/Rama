import { get } from "../../../Services/http";
import { catchError } from "../../../Actions/Error.action";

export const IMAGE_BLOCK_RECEIVE = "IMAGE_BLOCK_RECEIVE";
export const IMAGE_BLOCK_ERROR = 'IMAGE_BLOCK_ERROR';

export const fetchImageBlockModel = (id) => (dispatch) => {
    return get('/api/imageBlock/' + id)
        .then(response => response.json())
        .then(result => dispatch(receive(result)))
        .catch(ex => dispatch(catchError(ex, error => setError(error))));
}

export const receive = result => ({
    type: IMAGE_BLOCK_RECEIVE,
    payload: result
})

export const setError = error => ({
    type: IMAGE_BLOCK_ERROR,
    payload: {
        error,
    },
})