//import logo from './logo.svg';
import './App.css';
import ClassCounter from './components/ClassCounter.js';
import HookCounter from './components/HookCounter.js';
import HookCounterTwo from './components/HookCounterTwo.js';
import HookCounterThree from './components/HookCounterThree.js';
import ClassCounterThreeJed from './components/ClassCounterThreeJed.js';
import HookCounterFour from './components/HookCounterFour.js';
import ClassCounterFour from './components/ClassCounterFour.js';
import EffectClassCounterOne from './components/EffectClassCounterOne.js';

function App() {
  return (
    <div className="App">
      <EffectClassCounterOne/>
      {/*<ClassCounterFour/>*/}
      {/*<HookCounterFour/>*/}
      {/*<ClassCounterThreeJed />*/}
      {/*<HookCounterThree/>*/}
      {/*<HookCounterTwo />*/}
      {/*<HookCounter />*/}
      {/*<ClassCounter />*/}
      {/* <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header> */}
    </div>
  );
}

export default App;
