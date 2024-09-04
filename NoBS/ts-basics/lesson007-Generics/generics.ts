function simpleState<T>(initial: T): [() => T, (value: T) => void] {
    let val: T = initial;
    return [
        () => val, // if lambda has no parenthesis, it means it returns the value
        (value: T) => {
            val = value;
        }
    ]
}

const [numberGetter, numberSetter] = simpleState<number | null>(10);
console.log(numberGetter()); // 10
numberSetter(62);
console.log(numberGetter()); // 62

const [stringGetter, stringSetter] = simpleState<string | null>(null);
console.log(stringGetter()); // null
stringSetter('str');
console.log(stringGetter()); // str

interface Rank<T> {
    item: T;
    rank: number;
}

function ranker<T>(items: T[], rank: (v: T) => number): T[] {

    const ranks: Rank<T>[] = items.map(item => ({
        item,
        rank: rank(item)
    }));

    ranks.sort((a,b) => a.rank - b.rank); // if lamda has no curly braces, it means it returns the value

    return ranks.map(rank => rank.item); // if lamda has no curly braces, it means it returns the value
}

interface Pokemon {
    name: string;
    hp: number;
}

const pokemons: Pokemon[] = [
    {
        name: 'Bulbasaur',
        hp: 20
    },
    {
        name: 'Megasaur',
        hp: 100
    }
];

const ranks = ranker(pokemons, ({ hp }) => hp);
console.log(ranks);
