class Restaurant {
    constructor(budgetMoney) {
        this.budgetMoney = budgetMoney;
        this.menu = {};
        this.stockProducts = {};
        this.history = [];

        this.mealCount = 0;
    }

    loadProducts(products) {

        while (products.length !== 0) {

            let currProduct = products.shift();
            let splitted = currProduct.split(' ');

            let productName = splitted[0];
            let productQuantity = Number(splitted[1]);
            let totalPrice = Number(splitted[2]);


            if (totalPrice > this.budgetMoney) {
                this.history.push(`There was not enough money to load ${productQuantity} ${productName}`)
            } else {
                this.budgetMoney -= totalPrice;
                if (this.stockProducts[productName]) {
                    this.stockProducts[productName] += productQuantity;
                } else {
                    this.stockProducts[productName] = productQuantity;
                }

                this.history.push(`Successfully loaded ${productQuantity} ${productName}`);
            }
        }

        return this.history.join('\n');
    }

    addToMenu(meal, neededProducts, price) {

        if (this.menu[meal]) {
            return `The ${meal} is already in the our menu, try something different.`;
        } else {
            this.menu[meal] = {};
            this.menu[meal].products = neededProducts;
            this.menu[meal].price = price;
            this.mealCount++;

            if (this.mealCount === 1) {
                return `Great idea! Now with the ${meal} we have ${this.mealCount} meal in the menu, other ideas?`;
            }
            return `Great idea! Now with the ${meal} we have ${this.mealCount} meals in the menu, other ideas?`;
        }
    }

    showTheMenu() {
        let result = '';

        for (const meal in this.menu) {

            result += `${meal} - $ ${this.menu[meal].price}\n`;
        }

        if (result === '') {
            return `Our menu is not ready yet, please come later...`;
        }

        return result.trim();
    }

    makeTheOrder(meal) {
        let isMealFound = false;
        let product = {};

        for (const currentMeal in this.menu) {
            if (currentMeal == meal) {
                isMealFound = true;
            }
        }

        if (!isMealFound) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }


        for (const product of this.menu[meal].products) {
            let splitted = product.split(' ');
            let isProductSupplied = false;

            for (const stock in this.stockProducts) {
                
                if (stock == splitted[0]) {
                    if (this.stockProducts[stock] >= splitted[1]) {
                        isProductSupplied = true;
                        break;
                    }
                }
            }

            if (!isProductSupplied) {
                return `For the time being, we cannot complete your order (${meal}), we are very sorry...`
            }
        }

        
        for (const product of this.menu[meal].products) {
            let splitted = product.split(' ');

            for (const stock in this.stockProducts) {
                if (stock == splitted[0]) {

                    this.stockProducts[stock] -= Number(splitted[1]);
                }
            }

        }

        this.budgetMoney += this.menu[meal].price;
        return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.`
    }
}


let kitchen = new Restaurant(1000);

kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 2 50']);
//kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99);
//kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55);
console.log(kitchen.showTheMenu());
console.log(kitchen.makeTheOrder('frozenYogurt'));
console.log(kitchen.makeTheOrder('frozenYogurt'));