function extract(content) {
    const regex = /\(([^)]+)\)/gm;
    let paragraph = document.getElementById(content).textContent;
    let text = [];

    let match = regex.exec(paragraph);
    while(match){
        text.push(match[1]);
        match = regex.exec(paragraph);
    }

    return text.join('; ')
}

console.log(extract('content'));