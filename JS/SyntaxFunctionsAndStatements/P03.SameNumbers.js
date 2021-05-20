function solve(input){

    input = String(input);

    let isSameNumber = true;
    let sum = Number(0);
    let firstDigit = input[0];

    for (let i = 0; i < input.length; i++) {
        
        sum += Number(input[i]);

        if (firstDigit !== input[i]) {
            isSameNumber = false;
        }
    }

    console.log(isSameNumber);
    console.log(sum);
}

solve(1234)