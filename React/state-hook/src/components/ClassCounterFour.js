import React, { Component } from 'react';

class ClassCounterFour extends Component {
    constructor(props) {
        super(props);

        this.state = {
            items: []
        }
    }

    handleOnClick = () => {
        this.setState(prevState => {
            return {
                items: [...prevState.items, {
                    id: prevState.items.length + 1,
                    value: Math.floor(Math.random() * 10) + 1
                }]
            };
        });
    }

    render() {
        const { items } = this.state;
        return (
            <div>
                <button onClick={this.handleOnClick}>Add random number</button>
                <ul>
                    {items.map(item => <li key={item.id}>{item.value}</li>)}
                </ul>
            </div>
        );
    }
}

export default ClassCounterFour;