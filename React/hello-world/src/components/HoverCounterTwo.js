import React, { Component } from 'react';

class HoverCounterTwo extends Component {
    // constructor(props) {
    //     super(props);

    //     this.state = {
    //         count: 0
    //     }
    // }

    // handleMouseOver = (event) => {
    //     this.setState(prevState => {
    //         return {
    //             count: prevState.count + 1
    //         };
    //     });
    // }

    handleMouseOver = (event) => {
        this.props.incrementCount();
    }

    render() {
        const { count } = this.props; 
        return (
            <h2 onMouseOver={this.handleMouseOver}>Hovered {count} Times</h2>
        );
    }
}

export default HoverCounterTwo;