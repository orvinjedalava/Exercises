interface DatabaseGeneric<T, K> {
    get(id: K): T;
    set(id: K, value: T): void;
}

interface PersistableGeneric {
    saveToString(): string;
    restoreFromString(storedState: string): void;
}

type DBKeyType = string | number | symbol;

class InMemoryDatabaseGeneric<T, K extends DBKeyType> implements DatabaseGeneric<T, K> {

    protected db: Record<K, T> = {} as Record<K, T>;

    get(id: K): T {
        return this.db[id];
    }
    set(id: K, value: T): void {
        this.db[id] = value;
    }
}

class PersistentMemoryDBGeneric<T, K extends DBKeyType> extends InMemoryDatabaseGeneric<T, K> implements PersistableGeneric {

    saveToString(): string {
        return JSON.stringify(this.db);
    }

    restoreFromString(storedState: string): void {
        this.db = JSON.parse(storedState);
    }
} 

const myDB3 = new PersistentMemoryDBGeneric<number, string>();
myDB3.set('foo',22);
console.log(myDB3.get('foo')); // bar
console.log(myDB3.saveToString()); // {"foo":"bar"}

const myDB4 = new PersistentMemoryDBGeneric<number, string>();
myDB4.restoreFromString(myDB3.saveToString());
console.log(myDB4.get('foo')); // bar