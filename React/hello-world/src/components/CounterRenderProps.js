import React, { Component } from 'react';

class CounterRenderProps extends Component {
    constructor(props) {
        super(props);

        this.state = {
            count: 0
        };
    }

    incrementCount = (event) => {
        this.setState(prevState => {
            return {
                count: prevState.count + 1
            };
        });
    }

    render() {
        // IMPORTANT: We can also use this.props.children instead of this.props.render
        return (
            <div>
                {this.props.render(this.state.count, this.incrementCount)}
            </div>
        );
    }
}

export default CounterRenderProps;