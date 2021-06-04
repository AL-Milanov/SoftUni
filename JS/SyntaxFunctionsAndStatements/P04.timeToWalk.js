function solve(steps, footprint, speedInKmh){
    let distance = steps * footprint;

    let speedInMps = speedInKmh / 3.6;

    let time = distance / speedInMps;
    let breaks = Math.trunc(distance/ 500);

    time += breaks * 60;
    let hours = Math.trunc(time /3600);
    let minutes = Math.trunc((time % 3600) / 60 );
    let seconds = Math.round(time % 60);

    return `${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`;
}

console.log(solve(4000, 0.60, 5));