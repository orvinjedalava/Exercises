import { Router } from 'express';

const router = Router();

router.get('/api/products', (request, response) => {
    console.log(`This is my header cookie:${request.headers.cookie}`);
    console.log(request.cookies);
    console.log(request.signedCookies);
    if (request.signedCookies.hello && request.signedCookies.hello==='world')
        return response.send([ {id: 123, name: 'chicken breast', price: 12.99}]);

    return response.send({ msg: 'Sorry. You need the correct cookie.'});
});

export default router;