import React, { Component } from 'react';
import withCounter from './WithCounter.js';

class ClickCounter extends Component {
    constructor(props) {
        super(props);

        this.state = {
            
        };
    }

    handleClick = (event) => {
        this.props.incrementCount();
    }

    render() {
        const { count } = this.props;
        return (
            <div>
                <button onClick={this.handleClick}>
                    Clicked {count} times
                </button>
            </div>
        );
    }
}

export default withCounter(ClickCounter);