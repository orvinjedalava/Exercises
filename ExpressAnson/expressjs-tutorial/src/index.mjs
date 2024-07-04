import express from 'express';
import { loggingMiddleware } from './utils/middlewares.mjs';
import routes from './routes/index.mjs';

const app = express();

app.use(express.json());

// global middleware
app.use(loggingMiddleware, (request, response, next) => {
    console.log('loggingMiddleware done');
    next();
});

app.use(routes);

const PORT = process.env.PORT || 3000;


app.get('/',
    (request, response) => {
    //response.send('Hello, World!');
    //response.send({ msg: 'Hello!'});
    response.status(201).send({ msg: 'Hello!'});
});

app.listen(PORT, () => {
    console.log(`Running on Port ${PORT}`);
});