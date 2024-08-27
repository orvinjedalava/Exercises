import React, { useState } from 'react';

type InputProps = {
    value: string;
    handleChange: (event: React.ChangeEvent<HTMLInputElement>) => void;
}

export const Input = (props: InputProps) => {
    return <input type="text" value={props.value} onChange={(event) => props.handleChange(event)}/>
}