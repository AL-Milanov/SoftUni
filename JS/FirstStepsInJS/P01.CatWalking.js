
function solve(input){
    
    let index = 0;
    
    let minutesWalk = Number(input[index]);
    index++;

    let walksCount = Number(input[index]);
    index++;

    let calories = Number(input[index]);

    let totalMinutesOfWalks = minutesWalk * walksCount;

    let totalCaloriesBurned = totalMinutesOfWalks * 5;

    let halfCatCalories = calories / 2;

    if(totalCaloriesBurned >= halfCatCalories){
        console.log(`Yes, the walk for your cat is enough. Burned calories per day: ${totalCaloriesBurned}.`)
    }
    else{
        console.log(`No, the walk for your cat is not enough. Burned calories per day: ${totalCaloriesBurned}.`)
    }
}

solve(["15",
"2",
"500"])

