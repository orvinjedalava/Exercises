import React, { Component } from 'react';

class ClassCounterOne extends Component {
    constructor(props) {
        super(props);

        this.state = {
            count: 0
        };
    }

    componentDidMount() {
        document.title = `Clicked ${this.state.count} times`; 
    }

    componentDidUpdate(prevProps, prevState) {
        document.title = `Clicked ${this.state.count} times`;
    }

    handleOnClick =() => {
        this.setState(prevState => {
            return {
                count: prevState.count + 1
            }
        });
    }

    render() {
        const { count } = this.state;
        return (
            <div>
                <button onClick={this.handleOnClick}>Click {count} times</button>
            </div>
        ); 
    }
}

export default ClassCounterOne;