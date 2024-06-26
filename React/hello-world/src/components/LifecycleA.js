import React , { Component } from 'react';
import LifecycleB from './LifecycleB.js';

class LifeCycleA extends Component {
    constructor(props) {
        super(props);

        this.state = {
            name: 'Jed'
        }
        console.log('LifecycleA constructor');
    }

    static getDerivedStateFromProps(props, state) {
        console.log('LifecycleA getDerivedStateFromProps');
        return null;
    }
    
    componentDidMount() {
        console.log('LifecycleA componentDidMount');
    }

    shouldComponentUpdate() {
        console.log('LifecycleA shouldComponentUpdate');
        return true;
    }

    getSnapshotBeforeUpdate(prevProps, prevState) {
        console.log('LifecycleA getSnapshotBeforeUpdate');
        return null;
    }

    componentDidUpdate() {
        console.log('LifecycleA componentDidUpdate');
    }

    changeState = () => {
        this.setState({
            name: 'Codevolution'
        });
    };

    render() {
        console.log('LifecycleA render');
        return (
            <div>
                <div>LifeCycle A</div>
                <button onClick={this.changeState}>Change state</button>
                <LifecycleB />
            </div>
        );
    }
}

export default LifeCycleA;