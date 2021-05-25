function solve(array, n){
    n = Number(n);
    let result = [];

    for (let index = 0; index < array.length; index+=n) {
        result.push(array[index]);
    }

    return result;
}

console.log(solve(['5', 
'20', 
'31', 
'4', 
'20'], 
2
));
