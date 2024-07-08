import React, { useState, useEffect } from 'react';

function HookCounterOne() {

    const [count, setCount] = useState(0);

    useEffect(() => {
        document.title = `You clicked ${count} times`;
    });

    const handleOnClick = () => {
        setCount(prevCount => prevCount + 1);
    };

    return (
        <div>
            <button onClick={handleOnClick}>Click {count} times</button>
        </div>
    );
}

export default HookCounterOne;