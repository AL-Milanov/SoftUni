function solve(array){
    array.sort((a, b) => a.length - b.length || a.localeCompare(b))
    return array.join('\n');
}

console.log(solve(['alpha', 
'beta', 
'gamma']
));
console.log('-------------------------');
console.log(solve(['Isacc', 
'Theodor', 
'Jack', 
'Harrison', 
'George']
));
console.log('________________________');
console.log(solve(['test', 
'Deny', 
'omen', 
'Default']
));