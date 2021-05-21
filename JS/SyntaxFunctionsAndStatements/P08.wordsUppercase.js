function solve(text){
    text = text.toUpperCase().split(/\W+/gim);
    let output = [];

    for (const words of text) {
        if (words !== '') {
            output.push(words);
        }
    }

    console.log(output.join(', '));
}

solve('Hi, how are you?');