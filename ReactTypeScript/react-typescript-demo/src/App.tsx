import React, { useState } from 'react';
import { lstat } from 'fs';
import './App.css';
import { Greet } from './components/Greet';
import { Person } from './components/Person';
import { PersonList } from './components/PersonList';
import { Status } from './components/Status';
import { Heading } from './components/Heading';
import { Oscar } from './components/Oscar';
import { Button } from './components/Button';
import { Input } from './components/Input';
import { Container } from './components/Container';
import { LoggedIn } from './components/state/LoggedIn';
// import { User } from './components/state/User';
// import { UserTypeAssertion } from './components/state/UserTypeAsssertion';
// import { Counter } from './components/reducer/Counter';
import { ThemeContextProvider } from './components/context/ThemeContext';
import { Box } from './components/context/Box';
import { UserContext, UserContextProvider } from './components/context/UserContext';
import { User } from './components/context/User';
import { DomRef } from './components/ref/DomRef';
import { MutableRef } from './components/ref/MutableRef';
import { Counter } from './components/class/Counter';
import { Login } from './components/auth/Login';
import { Profile } from './components/auth/Profile';
import { Private } from './components/auth/Private';
import { List } from './components/generics/List';
import { RandomNumber } from './components/restriction/RandomNumber';
import { Toast } from './components/templateliterals/Toast';
import { CustomButton } from './components/html/Button';
import { Text } from './components/polymorphic/Text';

function App() {
  // const personName = {
  //   first: 'Bruce',
  //   last: 'Wayne'
  // }

  // const nameList = [
  //   {
  //     first: 'Bruce',
  //     last: 'Wayne'
  //   },
  //   {
  //     first: 'Clark',
  //     last: 'Kent'
  //   },
  //   {
  //     first: 'Princess',
  //     last: 'Diana'
  //   }
  // ]
  // const [value, setValue]= useState('');

  return (
    <div className="App">
      {/* <Greet name='Jed' messageCount={20} isLoggedIn={false} />
      <Person name={personName}/>
      <PersonList names={nameList}/> */}
      {/* <Status status='loading'/>
      <Heading>Placeholder text</Heading>
      <Oscar>
        <Heading>Oscar goes to Leonardo Dicaprio</Heading>
      </Oscar>
      <Greet name='Jed' isLoggedIn={true} /> */}
      {/* <Button handleClick={(event, id) => {
        console.log('Button clicked', event, id)
      }}/>
      <Input value={value} handleChange={(event) => {
        console.log(event.target.value)
        setValue(event.target.value)
      }}/> */}
      {/* <Container styles={{border: '1px solid black', padding: '1rem'}}/> */}
      {/* <LoggedIn />
      <User />
      <UserTypeAssertion/> */
      // <Counter />
      }

      {/* <ThemeContextProvider>
        <Box />
      </ThemeContextProvider>

      <UserContextProvider>
        <User />
      </UserContextProvider> */}

      {/* <DomRef/>
      <MutableRef/> */}

      {/* <Counter message='The count value is'/> */}

      {/* <Private isLoggedIn={true} component={Profile}/>
      <Private isLoggedIn={false} component={Profile}/> */}

      {/* <List 
        items={['Batman', 'Superman', 'Wonder Woman' ]} 
        onClick={(item) => {
          console.log(item)}}
      />

      <List 
        items={[1,2,3]} 
        onClick={(item) => {
          console.log(item)}}
      />

      <List 
        items={[
          {
            first: 'Bruce',
            last: 'Wayne'
          },
          {
            first: 'Clark',
            last: 'Kent'
          },
          {
            first: 'Princess',
            last: 'Diana'
          }
        ]} 
        onClick={(item) => {
          console.log(item)}}
      /> */}
      {/* <RandomNumber value={10} isPositive/> */}
      {/* <Toast position='center'/> */}

      {/* Setting <div>Primary Button</div> as children of CustomButton will not work because of Omit. We only allow children of type string */}
      {/* <CustomButton variant='primary' onClick={() => console.log('clicked')}>
        Primary Button
      </CustomButton> */}

      <Text as='h1' size='lg'>Heading</Text>
      <Text as='p' size='md'>Paragraph</Text>
      <Text as='label' htmlFor='someId' size='sm' color='secondary'>
        Label
      </Text>

    </div>
  );
}

export default App;
