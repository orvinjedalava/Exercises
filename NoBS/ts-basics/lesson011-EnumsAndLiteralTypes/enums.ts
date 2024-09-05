enum LoadingState {
    beforeLoad,
    loading,
    loaded
}

const englishLoadingStates = {
    [LoadingState.beforeLoad]: 'Before Load',
    [LoadingState.loading]: 'Loading',
    [LoadingState.loaded]: 'Loaded'
};


const isLoading = (state: LoadingState): boolean => state === LoadingState.loading;

console.log(isLoading(LoadingState.beforeLoad)); // false

// Literal Types
function rollDice(dice: 1 | 2 | 3): number {
    let pip = 0;
    for(let i = 0; i <dice; i++) {
        pip += Math.floor(Math.random() * 5) + 1;
    }

    return pip;
}

console.log(rollDice(3));

function sendEventLiterals(name: 'addToCart', data: { productId: number }): void;
function sendEventLiterals(name: 'checkout', data: { cartCount: number }): void;
function sendEventLiterals(name: string, data: unknown): void {
    console.log(`${name}: ${JSON.stringify(data)}`);
}

sendEventLiterals('addToCart', { productId: 123});