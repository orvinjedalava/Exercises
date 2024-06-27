import React, { Component } from 'react';
import withCounter from './WithCounter.js';

class HoverCounter extends Component {
    constructor(props) {
        super(props);

        this.state = {
            
        };
    }

    handleMouseOver = (event) => {
        this.props.incrementCount();
    }

    render() {
        const { count } = this.props;
        return (
            <div>
                <h2 onMouseOver={this.handleMouseOver}>
                    Hovered {count} times
                </h2>
            </div>
        );
    }
}

export default withCounter(HoverCounter);