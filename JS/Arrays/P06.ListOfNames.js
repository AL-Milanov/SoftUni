function solve(array){
    array.sort((a, b) => a.localeCompare(b));
    for (let index = 0; index < array.length; index++) {
        array[index] = `${index + 1}.` + array[index];
    }
    console.log(array.join('\n'));
}

solve(["John", "bob", "Christina", "Ema"])