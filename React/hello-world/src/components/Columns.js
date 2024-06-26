import React from 'react';

function Columns() {
    const items = [
        { id: 1, title: 'Title 1'},
        { id: 2, title: 'Title 2'},
        { id: 3, title: 'Title 3'}
    ];
    return (
        <React.Fragment>
            {
                items.map( item => (
                    <React.Fragment key={item.id}>
                        <td>{item.title}</td>
                    </React.Fragment>
                ))
            }
            <td>Name</td>
            <td>Jed</td>
        </React.Fragment>
    );
}

export default Columns;