function solve(array){
    let result = [];

    for (let index = 0; index < array.length; index++){
        switch (array[index]) {
            case 'add':
                result.push(index + 1);
                break;
            case 'remove':
                result.pop();
                break;
        }
    }

    return result.length == 0 ? 'Empty' : result.join('\n');
}

console.log(solve(['add', 
'add', 
'add',]
));