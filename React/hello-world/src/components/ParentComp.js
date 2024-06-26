import React, { Component } from 'react';
import RegComp from './RegComp.js';
import PureComp from './PureComp.js';
import MemoComp from './MemoComp.js';

class ParentComp extends Component {
    constructor(props) {
        super(props);

        this.state = {
            name: 'Jed'
        };
    }

    componentDidMount() {
        setInterval(() => {
            this.setState({
                name: 'Jed'
            });
        }, 2000);
    }

    render() {
        console.log('*** Parent Comp render ***');
        return (
            <div>
                Parent Component
                <MemoComp name={this.state.name}/>
                {/*<RegComp name={this.state.name}></RegComp>*/}
                {/*<PureComp name={this.state.name}></PureComp>*/}
            </div>
        );
    }
}

export default ParentComp;