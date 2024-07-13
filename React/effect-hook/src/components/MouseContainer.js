import React, {useState} from 'react';
import HookMouse from './HookMouse.js';

function MouseContainer() {
    const [display, setDisplay] = useState(true);

    const handleOnClick = (event) => {
        setDisplay(!display);
    };
    return (
        <div>
            <button onClick={handleOnClick}>Toggle Display</button>
            {display && <HookMouse/>}
        </div>
    );
}

export default MouseContainer;