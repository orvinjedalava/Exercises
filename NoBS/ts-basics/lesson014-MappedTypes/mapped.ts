type MyFlexibleDogInfo = {
    name: string;
    [key: string]: string | number;
};

// Name is required, but any other properties can be added.
const dog: MyFlexibleDogInfo = {
    name: 'Lassie',
    breed: 'Collie',
    age: 22
};

interface DogInfo {
    name: string;
    age: number;
}

type OptionsFlags<Type> = { 
    [Property in keyof Type]: null 
};

type DogInfoOptions = OptionsFlags<DogInfo>;

type Listeners<T> = { 
    [Property in keyof T as `on${Capitalize<string & Property>}Change`]?: (v: T[Property]) => void
} & {
    [Property in keyof T as `on${Capitalize<string & Property>}Delete`]?: () => void
};

function listenToObject<T>(obj: T, listeners: Listeners<T>): void {
    throw new Error('Function not implemented.');
}

const lg: DogInfo = {
    name: 'LG',
    age: 13
};

type DogInfoListeners = Listeners<DogInfo>;

listenToObject(lg, {
    onNameChange: (v: string) => {},
    onAgeChange: (v: number) => {},
    onAgeDelete: () => {}
});