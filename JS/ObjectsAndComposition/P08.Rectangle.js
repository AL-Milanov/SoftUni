function rectangle(width, height, color){
    let colorWithUpperCase = '';
    for (let i = 0; i < color.length; i++) {
        if (i === 0) {
            colorWithUpperCase += color[i].toUpperCase();
        } else {
            colorWithUpperCase += color[i];
        }
    }
    let rectangleObj = {
        width,
        height,
        color : colorWithUpperCase,
        calcArea,
    }

    function calcArea(){
        return width * height;
    }

    return rectangleObj;
}

let rect = rectangle(4, 5, 'red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());
