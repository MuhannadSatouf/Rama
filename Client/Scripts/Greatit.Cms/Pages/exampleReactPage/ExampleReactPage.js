import React from 'react';

const ExampleReactPage = (props) => {
    const result = props.result[0];
    return (
        <div>
            <div>React Part</div>
            {result &&
                <div>
                    <p>{result.pageTitle}</p>
                    <p>{result.pageBody}</p>
                </div>
            }
        </div>
    )
}

export default ExampleReactPage;