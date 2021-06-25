class ChristmasDinner {
    constructor(budget) {
        this._budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }

    get budget() {
        return this._budget;
    }
    set budget(value) {
        if (value < 0) {
            throw new Error('The budget cannot be a negative number');
        }
        this._budget = value;
    }

    shopping(product) {
        let productName = product[0];
        let productPrice = product[1];

        if (productPrice > this._budget) {
            throw new Error('Not enough money to buy this product')
        }

        this.budget -= productPrice;
        this.products.push(productName);
        return `You have successfully bought ${productName}!`
    }

    recipes(recipe) {
        let ingredients = recipe.productsList;
        let haveAllIngredients = true;

        for (const key in ingredients) {
            //remove needed products ???
            if (!this.products.includes(ingredients[key])) {
                haveAllIngredients = false;
            }
        }

        if (!haveAllIngredients) {
            throw new Error('We do not have this product');
        }

        this.dishes.push(recipe);
        return `${recipe.recipeName} has been successfully cooked!`
    }

    inviteGuests(name, dish) {
        let haveFood = false
        let wantedDish = {};
        for (const currentDish of this.dishes) {
            if (currentDish.recipeName == dish) {
                haveFood = true;
                wantedDish[dish] = currentDish.productsList;

            }
        }
        if (!haveFood) {
            throw new Error('We do not have this dish');
        }

        let isInvited = false;
        for (const key in this.guests) {
            if (key == name) {
                isInvited = true;
            }
        }
        if (isInvited) {
            throw new Error('This guest has already been invited');
        }

        this.guests[name] = wantedDish;
        return `You have successfully invited ${name}!`;
    }

    showAttendance() {
        let result = '';
        let products = [];


        for (const [name] of Object.entries(this.guests)) {

            for (const [dish, value] of Object.entries(this.guests[name])) {
                result += `${name} will eat ${dish}, which consists of ${value.join(', ')}\n`
            }
        }

        return result.trimEnd();
    }

}

let dinner = new ChristmasDinner(300);



dinner.shopping(['Salt', 1]);
dinner.shopping(['Beans', 3]);
dinner.shopping(['Cabbage', 4]);
dinner.shopping(['Rice', 2]);
dinner.shopping(['Savory', 1]);
dinner.shopping(['Peppers', 1]);
dinner.shopping(['Fruits', 40]);
dinner.shopping(['Honey', 10]);

dinner.recipes({
    recipeName: 'Oshav',
    productsList: ['Fruits', 'Honey']
});
dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
});
dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
});

dinner.inviteGuests('Ivan', 'Oshav');
dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice');
dinner.inviteGuests('Georgi', 'Peppers filled with beans');

console.log(dinner.showAttendance());
