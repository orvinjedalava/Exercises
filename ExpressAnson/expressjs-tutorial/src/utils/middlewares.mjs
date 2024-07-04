import { mockUsers } from '../utils/constants.mjs';

export const resolveUserIndex = (request, response, next) => {
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

export const loggingMiddleware = (request, response, next) => {
    console.log(`${request.method} - ${request.url}`)
    next();
}