interface Coordinate {
    x: number;
    y: number;
}

function parseCoordinate(obj: Coordinate): Coordinate;
function parseCoordinate(x: number, y: number): Coordinate;
function parseCoordinate(str: string): Coordinate;
function parseCoordinate(arg1: unknown, arg2?: unknown): Coordinate {
    let result: Coordinate = {
        x: 0,
        y: 0
    };

    if (typeof arg1 === 'object') {
        const obj: Coordinate = arg1 as Coordinate;
        return {
            ...obj
        }
    }

    if (typeof arg1 === 'number' && typeof arg2 === 'number') {
        result.x = arg1 as number;
        result.y = arg2 as number;
        return result;
    }

    if (typeof arg1 === 'string') {
        
        (arg1 as string).split(',').forEach(str => {
            const [key, value] = str.split(':');
            result[key as keyof Coordinate] = parseInt(value, 10);
            
        })
        return result;
    }

    throw new Error('Invalid input');
}

console.log(parseCoordinate(10, 20));
console.log(parseCoordinate({ x: 52, y: 35 }));
console.log(parseCoordinate('x:12,y:22'));