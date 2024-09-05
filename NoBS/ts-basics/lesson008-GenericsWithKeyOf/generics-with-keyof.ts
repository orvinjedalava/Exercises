function pluck<DataType, KeyType extends keyof DataType>(items: DataType[], key: KeyType): DataType[KeyType][] {
    return items.map((item) => item[key]);
}

const dogs = [
    { name: 'Lassie', age: 12 },
    { name: 'Rex', age: 13 },
    { name: 'Snoopy', age: 10 },
];

console.log(pluck(dogs, 'age')); // [12, 13, 10]
console.log(pluck(dogs, 'name')); // ['Lassie', 'Rex', 'Snoopy']

// event maps
interface BaseEvent {
    time: number;
    user: string;
}
interface EventMap {
    addToCart: BaseEvent & { quantity: number, productID: string };
    checkout: BaseEvent;
}

function sendEvent<T extends keyof EventMap>(name: T, data: EventMap[T]): void {
    console.log([name, data]);
}

sendEvent('addToCart', { productID: 'foo', user: 'baz', quantity: 1, time: 10 });
sendEvent('checkout', { user: 'bob', time: 20 });