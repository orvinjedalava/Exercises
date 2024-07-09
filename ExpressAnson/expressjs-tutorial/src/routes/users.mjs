import { Router } from 'express';
import { checkSchema, validationResult, matchedData } from 'express-validator';
import { createQueryValidationSchema, createUserValidationSchema } from '../utils/validationSchemas.mjs';
import { mockUsers } from '../utils/constants.mjs';
import { resolveUserIndex } from '../utils/middlewares.mjs'; 
import session from 'express-session';

const router = Router();

router.get('/api/users',
    checkSchema(createQueryValidationSchema, ['query']),
    (request, response) => {
        //console.log(request.session);
        console.log(request.session.id);
        request.sessionStore.get(request.session.id, (err, sessionData) => {
            if (err) {
                console.log(err);
                throw err;
            }
            console.log(sessionData);
        });
        const result = validationResult(request);
        //console.log(result);
        
        if (!result.isEmpty())
            return response.status(400).send({errors: result.array()});

        const { 
            query: { filter, value } 
        } = request;

        if (filter && value) return response.send(
            mockUsers.filter((user) => user[filter].includes(value))
        );

        response.send(mockUsers);
});

router.post('/api/users',
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

router.put("/api/users/:id", 
    checkSchema(createUserValidationSchema, ['body']),
    resolveUserIndex, 
    (request, response) => {
    const { body, userIndex } = request;

    mockUsers[userIndex] = { 
        id: mockUsers[userIndex].id,
        ...body };

    return response.sendStatus(200);
});

router.put("/api/users/:id", 
    checkSchema(createUserValidationSchema, ['body']),
    resolveUserIndex, 
    (request, response) => {
    const { body, userIndex } = request;

    mockUsers[userIndex] = { 
        id: mockUsers[userIndex].id,
        ...body };

    return response.sendStatus(200);
});

router.patch('/api/users/:id', resolveUserIndex, (request, response) => {
    const { body, userIndex } = request;

    console.log(userIndex);

    mockUsers[userIndex] = 
    { 
        ...mockUsers[userIndex], 
        ...body 
    };

    return response.sendStatus(200);
});

router.delete('/api/users/:id', resolveUserIndex, (request, response) => {
    const { userIndex } = request;
    mockUsers.splice(userIndex, 1);

    response.status(200).send('Record deleted.');
});

router.get('/api/users/:id', resolveUserIndex, (request, response) => {
    const { userIndex } = request;
    console.log(userIndex);

    return response.send(mockUsers[userIndex]);
});

export default router;