import logo from './logo.svg';
import './App.css';
import ClassCounterOne from './components/ClassCounterOne.js';
import HookCounterOne from './components/HookCounterOne.js';
import ClassMouse from './components/ClassMouse.js';
import HookMouse from './components/HookMouse.js';

function App() {
  return (
    <div className="App">
      {/*<ClassCounterOne />*/}
      {/*<HookCounterOne />*/}
      {/*<ClassMouse />*/}
      <HookMouse />
    </div>
  );
}

export default App;
