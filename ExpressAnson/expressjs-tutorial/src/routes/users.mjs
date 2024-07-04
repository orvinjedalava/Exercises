import { Router } from 'express';
import { checkSchema, validationResult, matchedData } from 'express-validator';
import { createQueryValidationSchema, createUserValidationSchema } from '../utils/validationSchemas.mjs';
import { mockUsers } from '../utils/constants.mjs';

const router = Router();

router.get('/api/users',
    checkSchema(createQueryValidationSchema, ['query']),
    (request, response) => {
        const result = validationResult(request);
        console.log(result);
        
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

export default router;