function sumTable() {
    let rows = document.querySelectorAll('td:nth-child(2)');
    let sum = 0;
    
    for (const row of rows) {
        sum += Number(row.textContent);
    }

    return document.querySelector('#sum').textContent = sum;
}