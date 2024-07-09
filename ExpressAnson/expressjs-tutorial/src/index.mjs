import express from 'express';
import { loggingMiddleware } from './utils/middlewares.mjs';
import routes from './routes/index.mjs';
import cookieParser from 'cookie-parser';
import session from 'express-session';

const app = express();

app.use(express.json());
app.use(cookieParser('IAmKeyForSignedCookie'))
app.use(session({
    secret:'IAmSecretKeyForSession',
    saveUninitialized: false,
    resave: false,
    cookie: {
        maxAge: 60000 * 60,
    }
}));
app.use(routes);

// global middleware
app.use(loggingMiddleware, (request, response, next) => {
    console.log('loggingMiddleware done');
    next();
});

const PORT = process.env.PORT || 3000;


app.get('/',
    (request, response) => {
    //response.send('Hello, World!');
    //response.send({ msg: 'Hello!'});
    console.log(request.session);
    console.log(request.sessionID);
    request.session.visited = true;
    response.cookie('hello','world', { maxAge: 60000, signed: true });
    response.status(200).send({ msg: 'Hello!'});
});

app.listen(PORT, () => {
    console.log(`Running on Port ${PORT}`);
});