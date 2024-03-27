import React from 'react';
import { connect } from 'react-redux';
import { fetchExamplePageData } from './ExampleReactPage.action';
import ExampleReactPage from './ExampleReactPage';

class ExampleReactPageContainer extends React.Component {
    constructor(props) {
        super(props);
        this.props.fetchData(this.props.pageId);
    }
    render() {
        return (
            <ExampleReactPage {...this.props} />
        )
    }
}

const mapDispatchToProps = dispatch => {
    return {
        fetchData: (pageId) => dispatch(fetchExamplePageData(pageId))
    }
}
const mapStateToProps = state => {

    return {
        result: state.ExampleReactPageReducer.result
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(ExampleReactPageContainer);
