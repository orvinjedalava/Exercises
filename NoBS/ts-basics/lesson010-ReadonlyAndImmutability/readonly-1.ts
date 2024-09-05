interface Cat {
    name: string;
    breed: string;
}

function makeCat(name: string, breed: string): Readonly<Cat> {
    return {
        name,
        breed
    };
}

const usul = makeCat('Usul', 'Tabby');

// NOTE: Tuple is an array with a fixed number of elements whose types are known.
function makeCoordinate(
    x: number,
    y: number,
    z: number
): readonly [number, number, number] {
    return [x, y, z];
}

const c1 = makeCoordinate(10, 20, 30);

// As const makes a readonly array literal.
const reallyConst = [1,2,3,4] as const;