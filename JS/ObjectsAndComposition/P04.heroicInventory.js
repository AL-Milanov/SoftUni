function solve(inputData){
    let result = [];
    for (const hero of inputData) {
        let [name, level, items] = hero.split(' / ');
        level = Number(level);
        items = items ? items.split(', ') : [];

        result.push({name, level, items});
    }

    function insert(start, cut, text){
        let x = '[]';
        return x.splice(start, cut, text)
    };

    return JSON.stringify(result);
}

console.log(solve(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
));

console.log(solve(['Jake / 1000 / Gauss, HolidayGrenade']));