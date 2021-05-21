function solve(firstNumber, secondNumber){

    if (secondNumber > firstNumber) {
        let dummy = firstNumber;
        firstNumber = secondNumber;
        secondNumber = dummy;
    }

    let divisor = 1;
    let greatestCommonDivisor = 1;

    while (true) {
    
        if (firstNumber % divisor == 0 && secondNumber % divisor == 0) {
            greatestCommonDivisor = divisor;
        }

        if (divisor == secondNumber) {
            break;
        }
        
        divisor++;
    }

    console.log(greatestCommonDivisor);
}

solve(15, 5)