function solve(array) {
    let result = [];
    let highestNum = -1;
    for (let index = 0; index < array.length; index++) {
        if (array[index] > highestNum) {
            result.push(array[index]);
            highestNum = array[index];
        }
    }
    return result;
}

console.log(solve([10,
    2,
    33,
    45,
    2,
]));