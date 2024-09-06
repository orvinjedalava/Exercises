interface PokemonResults {
    count: number;
    next?: string;
    previous?: string;
    results: {
        name: string;
        url: string;
    }[];
    
}

function fetchPokemonRedone(
    url: string, 
    cb: (data: PokemonResults) => void
): void;
function fetchPokemonRedone(
    url: string
): Promise<PokemonResults>;
function fetchPokemonRedone(
    url: string, 
    cb?: (data: PokemonResults) => void
): unknown {
    if (cb) {
        fetch(url)
            .then((resp: Response) => resp.json())
            .then((data) => cb(data as PokemonResults));
        return undefined;
    } else {
        return fetch(url)
            .then((resp: Response) => resp.json());
    }
}

fetchPokemonRedone("https://pokeapi.co/api/v2/pokemon?limit-10", (data: PokemonResults) => {
    data.results.forEach((pokemon) => { console.log(pokemon.name) });
});

(async function () {
    const data = await fetchPokemonRedone("https://pokeapi.co/api/v2/pokemon?limit-10");
    data.results.forEach((pokemon) => { console.log(pokemon.name) });
})();

