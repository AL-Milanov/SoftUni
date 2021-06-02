function colorize() {
    let table = document.querySelectorAll('table tr');
    let index = 1;
    for (const obj of table) {
        if (index % 2 == 0) {
            obj.style.background = 'teal';
        }
        index++;
    }
}