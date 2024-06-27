import React, { Component } from 'react';
import ComponentF from './ComponentF.js';

class ComponentE extends Component {
    constructor(props) {
        super(props);

        this.state = {};
    }
    render() {
        return (
            <div>
                <ComponentF />
            </div>
        );
    }
}

export default ComponentE;