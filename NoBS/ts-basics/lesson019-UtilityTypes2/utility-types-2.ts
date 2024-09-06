function myFunction(a: number, b: string):  boolean
{
    return true;
}

function myTestFunction<T extends (...args:any[]) => any>(myFunc: T,a: Parameters<T>[0], b: Parameters<T>[1]): ReturnType<T> {
    return myFunc(a,b);
}

console.log(myTestFunction(myFunction, 1, "2")); // boolean

type Name = {
    first: string;
    last: string;
}

function addFullName(name: Name): Name & { fullName: string } {
    return {
        ...name,
        fullName: `${name.first} ${name.last}`
    }
}

// the template means that it will accept ANY function 
function permuteRows<T extends (...args:any[]) => any>(
    iteratorFunc: T, 
    data: Parameters<T>[0][])
    : ReturnType<T>[] 
{
    return data.map(iteratorFunc);
}

console.log(permuteRows(addFullName, [{ first: 'Jed', last: 'Pogi'}]));

class PersonWithFullName {
    constructor(public name: Name) {}

    get fullName() {
        return `${this.name.first} ${this.name.last}`;
    }
}

function createObjects<T extends new (...args: any[]) => any>(ObjectType: T, data: ConstructorParameters<T>[0][]) : InstanceType<T>[] {
    return data.map(item => new ObjectType(item)) as InstanceType<T>[];
}

console.log(createObjects(PersonWithFullName, [{ first: 'Jed', last: 'Pogi'}]).map(person => person.fullName)); // [ 'Jed Pogi' ]

