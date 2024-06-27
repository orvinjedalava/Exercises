import React, { Component } from 'react';
import { UserConsumer } from './userContext.js';

class ComponentF extends Component {
    constructor(props) {
        super(props);

        this.state = {
           
        };
    }

    render() {
        return (
            <UserConsumer>
                { 
                    (username) => {
                        return (<div>Hello {username}</div>)
                    }
                }
            </UserConsumer>
            
        );
    }
}

export default ComponentF;