function solve(matrix) {
    let isMagical = true;
    let isMagicNumberFound = false;

    let magicSum = 0;

    for (let row = 0; row < matrix.length; row++) {
        let rowSum = 0;
        let colSum = 0;

        for (let col = 0; col < matrix.length; col++) {
            rowSum += matrix[row][col];
            colSum += matrix[col][row];
        }
        if (!isMagicNumberFound) {
            magicSum = rowSum;
            isMagicNumberFound = true;
        }
        if (magicSum !== rowSum || magicSum !== colSum) {
            isMagical = false;
            break;
        }
    }
    return isMagical;
}

console.log(solve([[4, 5, 6],
[6, 5, 4],
[5, 5, 5]]
));
console.log(solve([[11, 32, 45],
[21, 0, 1],
[21, 1, 1]]
));
console.log(solve([[1, 0, 0],
[0, 0, 1],
[0, 1, 0]]
));