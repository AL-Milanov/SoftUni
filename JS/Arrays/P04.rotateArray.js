function solve(array, n){
    for (let index = 0; index < n; index++) {
        rotate(array);
    }

    function rotate(array){
        let lastElement = array.pop();
        array.unshift(lastElement);
    }

    console.log(array.join(' '));
}

solve(['Banana', 
'Orange', 
'Coconut', 
'Apple'], 
15);