import React, { Component } from 'react';
import ComponentE from './ComponentE.js';

class ComponentC extends Component {
    constructor(props) {
        super(props);

        this.state = {};
    }
    render() {
        return (
            <div>
                <ComponentE />
            </div>
        );
    }
}

export default ComponentC;