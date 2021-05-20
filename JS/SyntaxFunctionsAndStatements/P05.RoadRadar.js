function solve(speed, area){

    let isHigher = false;
    let speedLimit = 0;

    if (area == 'motorway') {
        speedLimit = 130;
        if (speed > 130) {
            isHigher = true; 
        }
    } else if (area == 'interstate') {
        speedLimit = 90;
        if (speed > 90) {
            isHigher = true; 
        }
    } else if (area == 'city') {
        speedLimit = 50;
        if (speed > 50) {
            isHigher = true; 
        }
    } else if (area == 'residential') {
        speedLimit = 20;
        if (speed > 20) {
            isHigher = true; 
        }
    }

    if (isHigher == true) {
        let difference = speed - speedLimit;
        let status = null;
        
        if (difference <= 20) {
            status = 'speeding';
        }else if(difference <= 40){
            status = 'excessive speeding';
        }else{
            status = 'reckless driving';
        }

        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
    } else{
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
    }
}

solve(21, 'residential')