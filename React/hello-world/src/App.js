import logo from './logo.svg';
import './App.css';
import Greet from './components/Greet.js';
import Welcome from './components/Welcome.js';
import Hello from './components/Hello.js';
import Message from "./components/Message.js";
import Counter from "./components/Counter.js";
import FunctionClick from "./components/FunctionClick.js";
import ClassClick from "./components/ClassClick.js";
import EventBind from "./components/EventBind.js";
import ParentComponent from './components/ParentComponent.js';
import UserGreeting from './components/UserGreeting.js';
import NameList from './components/NameList.js';
import Stylesheet from './components/Stylesheet.js';
import Inline from './components/Inline.js';
import './appStyles.css';
import styles from './appStyles.module.css';
import Form from './components/Form.js';
import LifecycleA from './components/LifecycleA.js';
import FragmentDemo from './components/FragmentDemo.js';
import Table from './components/Table.js';
import PureComp from './components/PureComp.js';
import RegComp from './components/RegComp.js';
import ParentComp from './components/ParentComp.js';

function App() {
  return (
    <div className="App">
      <ParentComp/>
      {/*<Table/>*/}
      {/*<FragmentDemo />*/}
      {/*<LifecycleA/>*/}
      {/*<Form />*/}
      {/*<h1 className='error'>Error</h1>*/}
      {/*<h1 className={styles.success}>Success</h1>*/}
      {/* <Inline /> */}
      {/*<Stylesheet primary={true}/>*/}
      {/*<NameList/>*/}
      {/*<UserGreeting/>*/}
      {/*<ParentComponent/>*/}
      {/*<EventBind/>*/}
      {/*<FunctionClick />*/}
      {/*<ClassClick />*/}
      {/*<Greet name="Diana" heroName="Wonder Woman"/>*/}
      {/*<Counter />*/}
      {/*<Message/>*/}
      {/* <Greet name="Bruce" heroName="Batman">
        <p>This is children props</p>
      </Greet>
      <Greet name="Clark" heroName="Superman">
        <button>Action</button>
      </Greet>
      <Greet name="Diana" heroName="Wonder Woman"/>
      <Welcome name="Bruce" heroName="Batman"/>
      <Welcome name="Clark" heroName="Superman"/>
      <Welcome name="Diana" heroName="Wonder Woman"/> */}
      {/*<Hello/>*/}
    </div>
  );
}

export default App;
