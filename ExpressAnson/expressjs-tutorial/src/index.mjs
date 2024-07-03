import express from 'express';
import { query, validationResult, body, matchedData, checkSchema } from 'express-validator';
import { createUserValidationSchema } from './utils/validationSchemas.mjs';

const app = express();

app.use(express.json());

const PORT = process.env.PORT || 3000;

const mockUsers = [
    { id: 1, username: 'anson', displayName: 'Anson'},
    { id: 2, username: 'mel', displayName: 'Mel' },
    { id: 3, username: 'jed', displayName: 'Jed'}];


const loggingMiddleware = (request, response, next) => {
    console.log(`${request.method} - ${request.url} `);
    next();
}

const resolveUserIndex = (request, response, next) => {
    const { params: { id } } = request;

    const parsedId = parseInt(id);
    if (isNaN(parsedId))
        return response.status(404).send('Bad request.');

    const findUserIndex = mockUsers.findIndex(user => user.id === parsedId);

    if (findUserIndex === -1)
        return response.status(400).send(`Cannot find user for provided id: ${id}`);

    request.userIndex = findUserIndex;

    next();
}

// global middleware
app.use(loggingMiddleware, (request, response, next) => {
    console.log('loggingMiddleware done');
    next();
});


app.get('/',
    (request, response) => {
    //response.send('Hello, World!');
    //response.send({ msg: 'Hello!'});
    response.status(201).send({ msg: 'Hello!'});
});

app.get('/api/users', 
    query('filter')
        .isString()
        .notEmpty().withMessage('Must not be empty')
        .isLength({ min: 3, max: 10 }).withMessage('Must be at least 3-10 characters'),
    (request, response) => {
        //console.log(request['express-validator#contexts']);
        const result = validationResult(request);
        console.log(result);
        const data = matchedData(request);
        console.log(`matchedData: ${JSON.stringify(data)}`);

        const { 
            query: { filter, value } 
        } = request;

        if (filter && value) return response.send(
            mockUsers.filter((user) => user[filter].includes(value))
        );

        response.send(mockUsers);
    });

app.post('/api/users',
    // [ 
    //     body('username')
    //         .notEmpty().withMessage('Username cannot be empty')
    //         .isString().withMessage('Username must be a string')
    //         .isLength({ min: 5, max: 32}).withMessage('Username must be at least 5-32 characters'),
    //     body('displayName')
    //         .notEmpty().withMessage('DisplayName should not be empty')
    // ],
    checkSchema(createUserValidationSchema, ['body']),
    (request, response) => {
        // validationResult extracts all error messages performed from middleware ( body, query )
        const result = validationResult(request);
        console.log(result);

        if (!result.isEmpty())
            return response.status(400).send({ errors: result.array()});

        // get all data that has been validated by body() and query()
        const data = matchedData(request);
        console.log(data);

        const newUser = { id: mockUsers[mockUsers.length - 1].id + 1, ...data };
        mockUsers.push(newUser);

        return response.status(201).send(newUser);
    }
);

app.put("/api/users/:id", resolveUserIndex, (request, response) => {
    const { body, userIndex } = request;

    mockUsers[userIndex] = { 
        id: mockUsers[userIndex].id,
        ...body };

    return response.sendStatus(200);
});

app.patch('/api/users/:id', resolveUserIndex, (request, response) => {
    const { body, userIndex } = request;

    console.log(userIndex);

    mockUsers[userIndex] = 
    { 
        ...mockUsers[userIndex], 
        ...body 
    };

    return response.sendStatus(200);
});

app.delete('/api/users/:id', resolveUserIndex, (request, response) => {
    const { userIndex } = request;
    mockUsers.splice(userIndex, 1);

    response.status(200).send('Record deleted.');
});

app.get('/api/users/:id', resolveUserIndex, (request, response) => {
    const { userIndex } = request;
    console.log(userIndex);

    return response.send(mockUsers[userIndex]);
});

app.get('/api/products', (request, response) => {
    response.send([ {id: 123, name: 'chicken breast', price: 12.99}]);
});

app.listen(PORT, () => {
    console.log(`Running on Port ${PORT}`);
});