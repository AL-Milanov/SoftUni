function solve(input){
    let productsData = {};

    for (const item of input) {
        let [town, product, price] = item.split(' | ');
        price = Number(price);

        if (productsData[product]) {
            productsData[product] = productsData[product].price <= price ? productsData[product] : { town, price: price };
        } else {
            productsData[product] = { town, price: price }
        }

    }

    let output = [];
    for (const product in productsData) {
        output.push(`${product} -> ${productsData[product].price} (${productsData[product].town})`)
    }

    return output.join('\n');
}

console.log(solve(['Sample Town | Sample Product | 1000',
'Sample Town | Orange | 2',
'Sample Town | Peach | 1',
'Sofia | Orange | 3',
'Sofia | Peach | 2',
'New York | Sample Product | 1000.1',
'New York | Burger | 10']
));