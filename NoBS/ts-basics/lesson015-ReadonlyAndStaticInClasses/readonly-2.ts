class Doggy {
    constructor(public readonly name: string, public readonly age: number) {}
}

const lgg = new Doggy('LG', 13);
console.log(lgg.name);

class DogList {
    private doggies: Doggy[] = [];

    static instance: DogList = new DogList();

    private constructor() {}

    static addDog(dog: Doggy): void {
        DogList.instance.doggies.push(dog);
    }

    getDogs(): Doggy[] {
        return this.doggies;
    }
}

DogList.addDog(lgg);
console.log(DogList.instance.getDogs());