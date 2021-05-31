function solve(input) {

    let car = {
        model : input.model,
        engine : getEngine(input.power),
        carriage : getCarriage(input.carriage),
        wheels : getWheels(input.wheelsize)
    }

    function getWheels(size){
        let wheels = [];
        if (size % 2 == 0) {
            size--;
        }
        for (let index = 0; index < 4; index++) {
            wheels.push(size);
        }
        return wheels;
    }

    function getCarriage(carriage){
        let carriageType = {};
        if (carriage === 'hatchback') {
            carriageType = { type: 'hatchback', color: input.color};
        } else {
            carriageType = { type: 'coupe', color: input.color};
        }
        return carriageType;
    }

    function getEngine(power){
        power = Number(power);
        let engine = {};
        if (power <= 90) {
            engine = { power: 90, volume: 1800 };
        } else if (power <= 120) {
            engine = { power: 120, volume: 2400 };
        } else {
            engine = { power: 200, volume: 3500 };
        }
        return engine;
    }

    return car;
}

console.log(solve({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}
));

console.log(solve({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
}
));