import logo from './logo.svg';
import './App.css';
import ClassCounterOne from './components/ClassCounterOne.js';
import HookCounterOne from './components/HookCounterOne.js';
import ClassMouse from './components/ClassMouse.js';
import HookMouse from './components/HookMouse.js';
import MouseContainer from './components/MouseContainer.js';
import IntervalClassCounter from './components/IntervalClassCounter.js';
import IntervalHookCounter from './components/IntervalHookCounter.js';
import DataFetching from './components/DataFetching.js';
import ComponentC from './components/ComponentC.js';
import React from 'react';

export const UserContext = React.createContext();
export const ChannelContext = React.createContext();

function App() {
  return (
    <div className="App">
      <UserContext.Provider value={'Jed'}>
        <ChannelContext.Provider value={'Codevolution'}>
          <ComponentC/>
        </ChannelContext.Provider>
      </UserContext.Provider>
      {/*<ClassCounterOne />*/}
      {/*<HookCounterOne />*/}
      {/*<ClassMouse />*/}
      {/*<HookMouse />*/}
      {/*<MouseContainer/>*/}
      {/*<IntervalClassCounter />*/}
      {/*<IntervalHookCounter />*/}
      {/*<DataFetching/>*/}
    </div>
  );
}

export default App;
