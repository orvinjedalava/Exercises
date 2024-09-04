let userName: string = 'Jed';
let hasLoggedIn: boolean = true;

let hasLoggedInMsg: string = hasLoggedIn + ' Alava';

console.log(hasLoggedInMsg);

let myNUmber: number = 10;

let myRegex: RegExp = /foo/;

const names: string[] = userName.split(' ');
const mvValues: Array<number> = [1, 2, 3];

interface Person {
    first: string;
    last: string;
}

const myPerson: Person = {
    first: 'Jed',
    last: 'Alava'
};

const ids: Record<number, string> = {
    10: 'a',
    20: 'b'
}
ids[30] = 'c';

if (ids[30] === 'D') {
    console.log('ids 30 is D');
}

for (let i: number = 0; i < 10; i++) {
    console.log(i);
}

[1,2,3].forEach((i: number) => console.log(i));
// type inference
const out = [4,5,6].map((i: number) => `${i * 10}`);