export function printToFile(text: string, callback: () => void): void {
    console.log(text);
    callback();
}

export type MutationFunction = (i: number) => number;
export type AdderFunction = (i: number) => number;

export function arrayMutate(
    numbers: number[], 
    mutate: MutationFunction
): number[] {
    return numbers.map(mutate);
}

const myNewMutationFunction: MutationFunction = (i: number) => i * 100;

console.log(arrayMutate([1, 2, 3], (i) => i * 10));

export function createAdder(num: number): AdderFunction {
    return (val: number) => num + val;
}

const addOne = createAdder(1);
console.log(addOne(55));