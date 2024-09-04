import addNumbers, { addStrings, getName } from './functions';

console.log(addNumbers(1, 2)); // 3
console.log(addStrings('Jed', 'Alava')); // Jed Alava
console.log(addStrings('Jed')); // Jed

console.log(getName({ first: 'Jed', last: 'Alava' })); // Jed Alava