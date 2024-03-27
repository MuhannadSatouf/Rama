import React from 'react';
import { connect } from 'react-redux';
import { fetchImageBlockModel } from './ImageBlock.action';
import ImageBlock from './ImageBlock';

class ImageBlockContainer extends React.Component {
    constructor(props) {
        super(props);
        this.props.fetchData(this.props.blockId);
    }
    render() {
        return (
            <ImageBlock {...this.props} />
        )
    }
}

const mapDispatchToProps = dispatch => {
    return {
        fetchData: (blockId) => dispatch(fetchImageBlockModel(blockId))
    }

}
const mapStateToProps = state => {
    return {
        result: state.ImageReducer.result,
    }
}
export default connect(mapStateToProps, mapDispatchToProps)(ImageBlockContainer);