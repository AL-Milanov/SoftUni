function solve(input){
    let output = {};
    
    for (let i = 0; i < input.length; i+=2) {
        const element = input[i];
        const calories = Number(input[i + 1]);

        output[element] = calories;
    }

    return output;
}

console.log(solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']));

console.log(solve(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']));