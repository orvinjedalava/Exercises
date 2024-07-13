import React, { Component } from 'react';

class IntervalClassCounter extends Component {
    constructor(props) {
        super(props);

        this.state = {
            count: 0
        };
    }

    componentDidMount() {
        this.interval = setInterval(this.tick, 1000);
    }

    componentWillUnmount() {
        clearInterval(this.interval);
    }

    tick = () => {
        this.setState(prevState => {
            return {
                count: prevState.count + 1
            };
        });
    }

    render() {
        const { count } = this.state; 
        return (
            <h1>{count}</h1>
        );
    }
}

export default IntervalClassCounter;