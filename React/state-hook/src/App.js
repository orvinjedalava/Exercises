//import logo from './logo.svg';
import './App.css';
import ClassCounter from './components/ClassCounter.js';
import HookCounter from './components/HookCounter.js';
import HookCounterTwo from './components/HookCounterTwo.js';

function App() {
  return (
    <div className="App">
      <HookCounterTwo />
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
