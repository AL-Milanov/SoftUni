function solve(array, arg) {
    let result = [];

    array.forEach(el => {
        let splitted = el.split('|');
        let obj = {
            destination: splitted[0],
            price: Number(splitted[1]),
            status: splitted[2],
        };
        result.push(obj);
    });
    if (arg === 'price') {
        result.sort((a, b) => a[arg] - b[arg]);
    } else {
        result.sort((a, b) => a[arg].localeCompare(b[arg]));
    }
    return result;
}

console.log(solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'price'
));