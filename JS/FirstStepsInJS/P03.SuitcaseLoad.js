
function solve(input){

    let index = 0;
    let capacity = Number(input[index]);
    index++;

    let suitcaseLoaded = 0;
    let count = 1;

    while(true){

        let command = input[index];
        index++;

        if(command == "End"){
            console.log("Congratulations! All suitcases are loaded!");
            break;
        }

        let suitcase = Number(command);

        if(count % 3 == 0){
            suitcase += suitcase * 0.10;
        }

        if(capacity >= suitcase){
            capacity -= suitcase;
            suitcaseLoaded++;
        }
        else{
            console.log("No more space!");
            break;
        }

        count++;
    }

    console.log(`Statistic: ${suitcaseLoaded} suitcases loaded.`);
}

solve(["700",
"698",
"1",
"1",
"End"])

