import React, { Component } from 'react';
import ComponentF from './ComponentF.js';
import UserContext from './userContext.js';

class ComponentE extends Component {
    static contextType = UserContext;

    constructor(props) {
        super(props);

        this.state = {};
    }
    render() {
        return (
            <div>
                Component E context {this.context}
                <ComponentF />
            </div>
        );
    }
}

export default ComponentE;