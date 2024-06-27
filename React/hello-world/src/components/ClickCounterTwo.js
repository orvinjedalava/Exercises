import React, { Component } from 'react';

class ClickCounterTwo extends Component {
    // constructor(props) {
    //     super(props);

    //     this.state = {
    //         count: 0
    //     };
    // }

    // handleClick = (event) => {
    //     this.setState(prevState => {
    //         return {
    //             count: prevState.count + 1
    //         }
    //     });
    // }

    handleClick = (event) => {
        this.props.incrementCount();
    }

    render() {
        const { count } = this.props; 
        return (
            <button onClick={this.handleClick}>Click {count} times</button>
        );
    }
}

export default ClickCounterTwo;