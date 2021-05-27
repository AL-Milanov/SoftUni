function solve(arr){
    arr.sort((a, b) => a - b);
    let result = [];

    while(arr.length !== 0){
        
        let smallerNum = arr.shift();
        let biggerNum;
        
        if (arr.length !== 0) {
            biggerNum = arr.pop();
        }
        
        biggerNum !== undefined ? result.push(smallerNum, biggerNum) : result.push(smallerNum);
    }

    return result;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));