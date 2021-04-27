
function solve(input){
    let index = 0;
    let bitcoin = Number(input[index]);
    index++;
    let chineeseJuan = Number(input[index]);
    index++;
    let commision = Number(input[index]) / 100;

    let dollarToBGN = 1.76;
    let euroToBGN = 1.95;
    let bitcoinToBGN = 1168;

    let bitcoinSum = bitcoin * bitcoinToBGN;
    let chineeseJuanToDollars = chineeseJuan * 0.15;
    let dollarsSum = chineeseJuanToDollars * dollarToBGN;

    let totalSum = bitcoinSum + dollarsSum;
    let sumInEuro = totalSum / euroToBGN;

    let sumMinusCommision = sumInEuro * commision;
    let result = Number(0);
    if(commision > 0){
        result = sumInEuro - sumMinusCommision;
    }
    else{
        result = sumInEuro;
    }
    console.log(result.toFixed(2));
}

solve(["20",
"5678",
"2.4"])

