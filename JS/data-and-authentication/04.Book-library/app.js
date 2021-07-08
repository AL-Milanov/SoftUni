const baseUrl = 'http://localhost:3030/jsonstore/collections/books';

let loadBooksBtn = document.getElementById('loadBooks');
let bookTableBodyElement = document.querySelector('#bookTable tbody');

bookTableBodyElement.querySelectorAll('tr').forEach(b => b.remove());

loadBooksBtn.addEventListener('click', () => {
    fetch(baseUrl)
        .then(response => response.json())
        .then(data => {
            /*<tr>
            <td>Harry Poter</td>
            <td>J. K. Rowling</td>
            <td>
                <button>Edit</button>
                <button>Delete</button>
            </td>
        </tr>*/

            Object.keys(data).forEach(key => {

                let titleTd = ce('td', undefined, data[key].title);
                let authorTd = ce('td', undefined, data[key].author);
                let edidBtn = ce('button', undefined, 'Edit');
                let deleteBtn = ce('button', undefined, 'Delete');
                let buttonsTd = ce('td', undefined, edidBtn, deleteBtn);

                let mainTr = ce('tr', { id: key }, titleTd, authorTd, buttonsTd);
                bookTableBodyElement.appendChild(mainTr);
            })
        })
});




function ce(tag, attributes, ...params) {
    let element = document.createElement(tag);
    let firstValue = params[0];
    if (params.length === 1 && typeof (firstValue) !== 'object') {
        if (['input', 'textarea'].includes(tag)) {
            element.value = firstValue;
        } else {
            element.textContent = firstValue;
        }
    } else {
        element.append(...params);
    }

    if (attributes !== undefined) {
        Object.keys(attributes).forEach(key => {
            element.setAttribute(key, attributes[key]);
        })
    }

    return element;
}