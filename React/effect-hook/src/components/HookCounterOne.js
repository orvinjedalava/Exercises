import React, { useState, useEffect } from 'react';

function HookCounterOne() {

    const [count, setCount] = useState(0);
    const [name, setName] = useState('');

    useEffect(() => {
        console.log('Updating document title.')
        document.title = `You clicked ${count} times`;
    }, [count]);

    const handleOnClick = () => {
        setCount(prevCount => prevCount + 1);
    };

    const handleTextOnChange = (event) => {
        setName(event.target.value);
    };

    return (
        <div>
            <input type="text" value={name} onChange={handleTextOnChange} />
            <button onClick={handleOnClick}>Click {count} times</button>
        </div>
    );
}

export default HookCounterOne;