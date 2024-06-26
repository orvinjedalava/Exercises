import React, { Component } from 'react';
import Input from './Input.js';

class FocusInput extends Component {
    constructor(props) {
        super(props);

        this.componentRef = React.createRef();

        this.state = {

        };
    }

    handleClick = (event) => {
        this.componentRef.current.focusInput();
    } 

    render() {
        return (
            <div>
                <Input ref={this.componentRef}/>
                <button onClick={this.handleClick}>Focus Input</button>
            </div>
        );
    }
}

export default FocusInput;