function solve() {
    let ingredients = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0,
    }

    let recipes = {
        apple: {
            carbohydrate: 1,
            flavour: 2,
        },
        lemonade: {
            carbohydrate: 10,
            flavour: 20,
        },
        burger: {
            carbohydrate: 5,
            fat: 7,
            flavour: 3,
        },
        eggs: {
            protein: 5,
            fat: 1,
            flavour: 1,
        },
        turkey: {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10,
        },
    }

    return function manager(arg) {
        let argSplitted = arg.split(' ');
        if (argSplitted[0] === 'restock') {
            ingredients[argSplitted[1]] += Number(argSplitted[2]);
            return 'Success';
        } else if (argSplitted[0] === 'report') {
            let result = [];
            Object.entries(ingredients).forEach(([key, value]) => {
                result.push(`${key}=${value}`);
            });

            return result.join(' ');

        } else if (argSplitted[0] === 'prepare') {
            let item = recipes[argSplitted[1]];

            let neededQuantity = argSplitted[2];

            let elementsNeeded = {
                protein: 0,
                carbohydrate: 0,
                fat: 0,
                flavour: 0,
            }
            Object.entries(item).forEach(([key, value]) => {
                if (item[key].name == elementsNeeded[key].name) {
                    elementsNeeded[key] += value * neededQuantity;
                }
            });

            Object.entries(elementsNeeded).forEach(([key, value]) => {
                if (elementsNeeded[key].name == ingredients[key].name) {
                    if (value > ingredients[key]) {

                        throw new Error(`Error: not enough ${key} in stock `);
                    }
                }
            });

            Object.entries(ingredients).forEach(([key, value]) => {
                ingredients[key] -= elementsNeeded[key];
            });

            return 'Success';
        }
    }
}

try {

    let manager = solve();
    console.log(manager("restock flavour 50")); // Success 
    console.log(manager("prepare lemonade 4")); // Error: not enough carbohydrate in stock 
    console.log(manager("prepare turkey 1")); // Error: not enough carbohydrate in stock 
    console.log(manager("restock protein 10")); // Error: not enough carbohydrate in stock 
    console.log(manager("prepare turkey 1")); // Error: not enough carbohydrate in stock 
    console.log(manager("restock carbohydrate 10")); // Error: not enough carbohydrate in stock 
    console.log(manager("prepare apple 1")); // Error: not enough carbohydrate in stock 
    console.log(manager("restock fat 10")); // Error: not enough carbohydrate in stock 
    console.log(manager("prepare turkey 1")); // Error: not enough carbohydrate in stock 
    console.log(manager("restock flavour 10")); // Error: not enough carbohydrate in stock 
    console.log(manager("prepare turkey 1")); // Error: not enough carbohydrate in stock 
    console.log(manager("report")); // Error: not enough carbohydrate in stock 
} catch (error) {
    console.log(error.message);
    return;
} finally {
    return;
}
