import React from 'react';

const ImageBlock = (props) => {
    console.log(props);
    let blockId = props.blockId;
    return (
        blockId && (
            <div>react Image Block, Block id: {props.blockId}</div>
        )
    );
}

export default ImageBlock;