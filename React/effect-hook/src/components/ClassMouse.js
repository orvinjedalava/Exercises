import React, { Component } from 'react';

class ClassMouse extends Component {
    constructor(props) {
        super(props);

        this.state = {
            x: 0,
            y: 0
        };
    }

    logMousePosition = (event) => {
        this.setState(prevState => {
            return {
                x: event.clientX,
                y: event.clientY
            }
        });
    }

    componentDidMount() {
        window.addEventListener('mousemove', this.logMousePosition);
    }
    render() {
        const { x, y } = this.state;
        return (
            <div>
                X:{x} Y:{y} 
            </div>
        );
    }
}

export default ClassMouse;