function solve(array) {
    let result = [];
    let highestNum = Number.MIN_SAFE_INTEGER;
    for (let index = 0; index < array.length; index++) {
        if (Number(array[index]) >= highestNum) {
            result.push(array[index]);
            highestNum = array[index];
        }
    }
    return result;
}

console.log(solve([-10,
    -2,
    3,
    4,
    2,
]));