type ThreeDCoordinate = [x: number, y: number, z: number];

function add3DCoordinate(c1: ThreeDCoordinate, c2: ThreeDCoordinate) : ThreeDCoordinate {
    return [
        c1[0] + c2[0],
        c1[1] + c2[1],
        c1[2] + c2[2]
    ]
}

console.log(add3DCoordinate([0,0,0,], [10,20,30])); // [10,20,30]

function simpleStringState(initial: string): [() => string, (str: string) => void] {
    let str: string = initial;
    return [
        () => str, // if lambda has no parenthesis, it means it returns the value
        (value: string) => {
            str = value;
        }
    ]
}

const [str1getter, str1setter] = simpleStringState('hello');
const [str2getter, str2setter] = simpleStringState('hello');
console.log(str2getter()); // hello
console.log(str1getter()); // hello
str1setter('goodbye');
console.log(str2getter()); // hello
console.log(str1getter()); // goodbye