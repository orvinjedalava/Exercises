import React, { Component } from 'react';

class ClassCounterThreeJed extends Component {
    constructor(props) {
        super(props);

        this.state = {
            firstName: '',
            lastName: ''
        };
    }

    handleFirstNameOnChange = (event) => {
        this.setState(prevState => {
            return {
                ...prevState,
                firstName: event.target.value
            }
        });
    }

    handleLastNameOnChange = (event) => {
        this.setState(prevState => {
            return {
                ...prevState,
                lastName: event.target.value
            }
        });
    }

    render() {
        const { firstName, lastName } = this.state;
        return (
            <form>
                <input 
                    type="text"
                    value={firstName}
                    onChange={this.handleFirstNameOnChange}
                />
                <input 
                    type="text"
                    value={lastName}
                    onChange={this.handleLastNameOnChange} />

                <h2>Your first name is : {firstName}</h2>
                <h2>Your last name is : {lastName}</h2>

                <h2>{JSON.stringify(this.state)}</h2>
            </form>
        );
    }
}

export default ClassCounterThreeJed;