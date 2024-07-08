import React, { Component } from 'react';

class ClassCounterOne extends Component {
    constructor(props) {
        super(props);

        this.state = {
            count: 0,
            name: ''
        };
    }

    componentDidMount() {
        document.title = `Clicked ${this.state.count} times`; 
    }

    componentDidUpdate(prevProps, prevState) {
        if (prevState.count !== this.state.count) {
            console.log('Updating document title');
            document.title = `Clicked ${this.state.count} times`;
        }
            
    }

    handleOnClick =() => {
        this.setState(prevState => {
            return {
                count: prevState.count + 1
            }
        });
    }

    handleTextOnChange = (event) => {
        this.setState(prevState => {
            return {
                name: event.target.value
            };
        });
    }

    render() {
        const { count, name } = this.state;
        return (
            <div>
                <input type="text" value={name} onChange={this.handleTextOnChange}/>
                <button onClick={this.handleOnClick}>Click {count} times</button>
            </div>
        ); 
    }
}

export default ClassCounterOne;