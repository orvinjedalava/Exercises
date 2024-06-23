const PizzaShop = require("./pizza-shop.js");
const DrinkMachine = require("./drink-machine.js");

const pizzaShop = new PizzaShop();
const drinkMachine = new DrinkMachine();

pizzaShop.on("order", (size, topping)=> {
    console.log(`Baking ${size} pizza with ${topping}`);
    drinkMachine.serveDrink(size);
});

pizzaShop.order("large", "mushroom");
pizzaShop.displayOrderNumber();