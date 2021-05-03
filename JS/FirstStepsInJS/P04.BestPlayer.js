
function solve(input){

    let index = 0;
    let bestPlayerName = '';
    let bestPlayerGoals = 0;

    while(true){

        let footballPlayer = input[index];
        index++;

        if(footballPlayer === 'END'){
            break;
        }

        let goals = Number(input[index]);
        index++;

        if(goals > bestPlayerGoals){
            bestPlayerName = footballPlayer;
            bestPlayerGoals = goals;
        }

        if(goals >= 10){
            break;
        }
    }

    console.log(`${bestPlayerName} is the best player!`)

    if(bestPlayerGoals >= 3){
        console.log(`He has scored ${bestPlayerGoals} goals and made a hat-trick !!!`)
    }
    else{
        console.log(`He has scored ${bestPlayerGoals} goals.`)
    }
}

solve(["Neymar", "2",
"Ronaldo",
"1",
"Messi",
"3",
"END"])
