import React, { Component } from 'react';

class UserGreeting extends Component {
    constructor(props) {
        super(props);

        this.state = {
            isLoggedIn: true
        };
    }
    render() {
        return this.state.isLoggedIn ? (
            <div>Welcome Jed</div> 
        ): (
            <div>Welcome Guest</div>
        );
        // short circuit
        //return this.state.isLoggedIn && (<div>Welcome Jed</div>);

        // let message;
        // if (this.state.isLoggedIn) {
        //     message = <div>Welcome Jed</div>
        // } else {
        //     message = <div>Welcome Guest</div>
        // }
        
        // return (
        //     <div>{message}</div>
        // );

        // if (this.state.isLoggedIn) {
        //     return (
        //         <div>
        //             Welcome Jed
        //         </div>
        //     );
        // } else {
        //     return (
        //         <div>
        //             Welcome Guest
        //         </div>
        //     );
        // }

        // return (
        //     <div>
        //         <div>Welcome Jed</div>
        //         <div>Welcome Guest</div>
        //     </div>
        // );
    }
}

export default UserGreeting;