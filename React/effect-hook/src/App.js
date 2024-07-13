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

function App() {
  return (
    <div className="App">
      {/*<ClassCounterOne />*/}
      {/*<HookCounterOne />*/}
      {/*<ClassMouse />*/}
      {/*<HookMouse />*/}
      {/*<MouseContainer/>*/}
      {/*<IntervalClassCounter />*/}
      {/*<IntervalHookCounter />*/}
      <DataFetching/>
    </div>
  );
}

export default App;
