function extractText() {
    let itemsQuery = document.querySelectorAll('ul#items li');
    let result = document.querySelector('#result');

    for (const item of itemsQuery) {
        result.value += item.textContent + '\n';
    }

    return result;
}