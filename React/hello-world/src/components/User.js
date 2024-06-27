import React, { Component } from 'react';

class User extends Component {
    constructor(props) {
        super(props);

        this.state = {
            count: 0
        };
    }
    render() {
        return (
            <div>{this.props.render(false)}</div>
        );
    }
}

export default User;