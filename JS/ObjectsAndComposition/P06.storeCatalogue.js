function solve(input) {
    let result = {};

    for (const product of input) {
        let [productName, productPrice] = product.split(' : ');
        result[productName] = productPrice;
    }

    let sortedResult = Object.entries(result).sort((a, b) => a[0].localeCompare(b[0]));

    let lastLetter = '';

    for (const product of sortedResult) {

        let firstLetter = product[0][0];

        if (firstLetter !== lastLetter) {
            console.log(`${firstLetter}`);
            lastLetter = firstLetter;
        }
        console.log(`  ${product[0]}: ${product[1]}`);
    }
}

console.log(solve(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10'],
));
