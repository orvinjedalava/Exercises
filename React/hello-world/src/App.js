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
import RefsDemo from './components/RefsDemo.js';
import FocusInput from './components/FocusInput.js';
import FRParentInput from './components/FRParentInput.js';
import PortalDemo from './components/PortalDemo.js';
import Hero from './components/Hero.js';
import ErrorBoundary from './components/ErrorBoundary.js';
import ClickCounter from './components/ClickCounter.js';
import HoverCounter from './components/HoverCounter.js';
import ClickCounterTwo from './components/ClickCounterTwo.js';
import HoverCounterTwo from './components/HoverCounterTwo.js';
import User from './components/User.js';
import CounterRenderProps from './components/CounterRenderProps.js';

function App() {
  return (
    <div className="App">
      <CounterRenderProps render={ 
        (count, incrementCount) => 
          (<ClickCounterTwo count={count} incrementCount={incrementCount}/>)
      }/>
      <CounterRenderProps render={ 
        (count, incrementCount) => 
          (<HoverCounterTwo count={count} incrementCount={incrementCount}/>)
      }/>

      {/*<ClickCounterTwo />
      <HoverCounterTwo />
      <User render={ (isLoggedIn) => isLoggedIn ? "Jed" : "Guest"}/>*/}
      {/*<ClickCounter name="Jed"/>
      <HoverCounter />*/}
      {/*<ErrorBoundary>
        <Hero heroName="Batman"/>
      </ErrorBoundary>
      <ErrorBoundary>
        <Hero heroName="Superman"/>
      </ErrorBoundary>
      <ErrorBoundary>
        <Hero heroName="Joker"/>
      </ErrorBoundary>*/}
      {/*<PortalDemo />*/}
      {/*<FRParentInput />*/}
      {/*<FocusInput />*/}
      {/*<RefsDemo />*/}
      {/*<ParentComp/>*/}
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
