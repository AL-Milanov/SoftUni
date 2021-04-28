
function solve(input){
    
    let index = 0;
    let tournamentDays = Number(input[index]);

    index++;

    let totalWins = 0;
    let totalLoses = 0;
    let totalMoneys = 0;

    for(let i = 0; i < tournamentDays; i++){

        let wins = 0;
        let loses = 0;
        let moneyForDay = 0;

        while(true){
            
            let sport = input[index];
            index++;

            if(sport === 'Finish'){
                break;
            }

            let result = input[index];
            index++;

            if(result === 'win'){
                wins++;
                moneyForDay += 20;
            }
            else if(result === 'lose'){
                loses++;
            }

        }

        if(wins > loses){
            moneyForDay += moneyForDay * 0.10;
            totalMoneys += moneyForDay;
            totalWins++;
        }
        else{
            totalMoneys += moneyForDay;
            totalLoses++;
        }
    }

    if(totalWins > totalLoses){
        totalMoneys += totalMoneys * 0.20;
        console.log(`You won the tournament! Total raised money: ${totalMoneys.toFixed(2)}`);
    }
    else{
        console.log(`You lost the tournament! Total raised money: ${totalMoneys.toFixed(2)}`);
    }
}

    if(totalWins > totalLoses){
        totalMoneys += totalMoneys * 0.20;
        console.log(`You won the tournament! Total raised money: ${totalMoneys.toFixed(2)}`);
    }
    else{
        console.log(`You lost the tournament! Total raised money: ${totalMoneys.toFixed(2)}`);
    }
}

solve(["3",
"darts",
"lose",
"handball",
"lose",
"judo",
"win",
"Finish",
"snooker",
"lose",
"swimming",
"lose",
"squash",
"lose",
"table tennis",
"win",
"Finish",
"volleyball",
"win",
"basketball",
"win",
"Finish"])

