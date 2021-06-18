function solve(numbersArray, sortType) {
    let inputData = {
        numbersArray,
        sortType,
    }

    function mySort() {
        let sortedArray = [];
        switch (this.sortType) {
            case 'asc':
                sortedArray = this.numbersArray.sort((a, b) => a - b);
                break;
            case 'desc':
                sortedArray = this.numbersArray.sort((a, b) => b - a);
                break;
            default:
                break;
        }
        return sortedArray;
    }
    return mySort.call(inputData);
}

console.log(solve([14, 7, 17, 6, 8], 'desc'));
console.log(solve([14, 7, 17, 6, 8], 'asc'));