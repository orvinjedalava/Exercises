function myForEach<T>(items: T[], forEachFunc: (v: T) => void) {
    items.reduce((a,v) => {
        forEachFunc(v);
        return undefined;
    }, undefined)
}

myForEach([1,2,3], (v) => console.log(`forEach ${v}`));

function myFilter<T>(items: T[], filterFunc: (v: T) => boolean) : T[] {
    return items.reduce<T[]>((a, v) => filterFunc(v) ? [...a,v] : a, []);
}

console.log(myFilter([1,2,3,4,5,6,7,8], (v) => v % 2 === 0));

function myMap<T, K>(items: T[], mapFunc: (v: T) => K): K[] {
    return items.reduce<K[]>((a, v) => [...a, mapFunc(v)], []);
}

console.log(myMap([1,2,3,4,5], (v) => (v * 2).toString()));