import logo from './logo.svg';
import './App.css';
import CounterOne from './components/CounterOne.js';
import CounterTwo from './components/CounterTwo.js';
import CounterThree from './components/CounterThree.js';
import ComponentA from './components/ComponentA.js';
import ComponentB from './components/ComponentB.js';
import ComponentC from './components/ComponentB.js';
import React, { useReducer } from 'react';

export const CountContext = React.createContext();

const initialState = 0;
const reducer = (state, action) => {
  switch(action) {
    case 'increment':
      return state + 1;
    case 'decrement':
      return state - 1;
    case 'reset':
      return initialState;
    default:
      return state;
  }
};

function App() {
  const [count, dispatch] = useReducer(reducer, initialState);
  return (
    <CountContext.Provider value={{ countState: count, countDispatch: dispatch }}>
      <div className="App">
        Count - {count}
        {/*<CounterOne/>*/}
        {/*<CounterTwo/>*/}
        {/*<CounterThree/>*/}
        <ComponentA/>
        <ComponentB/>
        <ComponentC/>
      </div>
    </CountContext.Provider>
  );
}

export default App;
