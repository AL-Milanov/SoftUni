function solve(number, cmdArg1, cmdArg2, cmdArg3, cmdArg4, cmdArg5){
    number = Number(number);

    number = commands(number, cmdArg1); 
    console.log(number);

    number = commands(number, cmdArg2); 
    console.log(number);

    number = commands(number, cmdArg3); 
    console.log(number);

    number = commands(number, cmdArg4); 
    console.log(number);

    number = commands(number, cmdArg5); 
    console.log(number);


    function commands(number, command){

        switch (command) {
            case 'chop':
                number /= 2;
                break;
            case 'dice':
                number = Math.sqrt(number);
                break;
            case 'spice':
                number++;
                break;
            case 'bake':
                number *= 3;
                break;
            case 'fillet':
                number *= 0.8;
                break;
        }
        
        return number;
    }
}

solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');