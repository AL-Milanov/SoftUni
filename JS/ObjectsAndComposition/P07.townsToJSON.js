function solve(townsInfo){
    townsInfo.shift();
    let townsData = [];

    for (const townInfo of townsInfo) {
        let [empty, town, latitude, longitude] = townInfo.split(/\s*\|\s*/gm);
        let townObj = {
            Town : town,
            Latitude : Number(Number(latitude).toFixed(2)),
            Longitude : Number(Number(longitude).toFixed(2)),
        }
        townsData.push(townObj);
    }


    return JSON.stringify(townsData);
}

console.log(solve(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |',
'| Random Town | 0.00 | 0.00 |',
'| New York | 40.730610 | -73.935242 |',
'| Must be fake | -22.13 | 68.17 |',]
));