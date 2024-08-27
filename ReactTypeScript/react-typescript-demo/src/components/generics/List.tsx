import React, { ReactNode } from 'react';

type ListProps<T> = {
    items: T[];
    onClick: (value: T) => void;
}

// you can restrict in many ways
// e.g. T extends string | number 
// or T extends { id: number } to only allow objects with id property
export const List = <T extends {}>({items, onClick}: ListProps<T>) => {
    return (
        <div>
            <h2>List of items</h2>
            {items.map((item, index) => (
                <div key={index} onClick={() => onClick(item)}>
                    {String(item)}
                </div>
            ))}
        </div>
    )
}