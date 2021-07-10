const baseUrl = 'http://localhost:3030/jsonstore/collections/books';
let changeBookId = '';

let formElement = document.getElementById('form');
let loadBooksBtn = document.getElementById('loadBooks');
let bookTableBodyElement = document.querySelector('#bookTable tbody');

bookTableBodyElement.querySelectorAll('tr').forEach(b => b.remove());

loadBooksBtn.addEventListener('click', () => {
    fetch(baseUrl)
        .then(response => response.json())
        .then(data => {
            bookTableBodyElement.textContent = '';
            Object.entries(data).forEach(([key, value]) => bookTableBodyElement.appendChild(createBookTr(key, value)));
        })
});

formElement.addEventListener('submit', formHandler);


function createBookTr(key, value) {

    let titleTd = ce('td', undefined, value.title);
    let authorTd = ce('td', undefined, value.author);

    let editBtn = ce('button', undefined, 'Edit');
    editBtn.addEventListener('click', (e) => {

        changeBookId = e.currentTarget.closest('tr').dataset.id;
        formElement.dataset.isEdit = true;

        formElement.querySelector('h3').textContent = 'Edit FORM';
        formElement.querySelector('button').textContent = 'Save';

        formElement.querySelector('#title').value = value.title;
        formElement.querySelector('#author').value = value.author;

    });

    let deleteBtn = ce('button', undefined, 'Delete');
    deleteBtn.addEventListener('click', () => {
        fetch(`${baseUrl}/${key}`, {
            method: 'DELETE'
        })
            .then(response => response.json)
            .catch(err => console.error(err));

        mainTr.remove();
    });

    let buttonsTd = ce('td', undefined, editBtn, deleteBtn);

    let mainTr = ce('tr', { class: 'book' }, titleTd, authorTd, buttonsTd);
    mainTr.dataset.id = key;

    return mainTr;
}

function formHandler(e) {
    e.preventDefault();

    let bookData = new FormData(e.currentTarget);

    let bookObject = {
        author: bookData.get('author'),
        title: bookData.get('title')
    };

    let form = e.currentTarget;

    if (form.dataset.isEdit !== undefined) {
        fetch(`${baseUrl}/${changeBookId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(bookObject)
        })
            .then(response => response.json())
            .then(data => {
                let elToReplace = bookTableBodyElement.querySelector(`.book[data-id="${changeBookId}"]`);
                elToReplace.replaceWith(createBookTr(changeBookId, { title: data.title, author: data.author }));
            })
            .catch(err => console.log(err));
    } else {
        fetch(baseUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(bookObject),
        })
            .then(response => response.json())
            .then(data => bookTableBodyElement.appendChild(createBookTr(data._id, bookObject)))
            .catch(err => console.error(err));

    }
    formElement.reset();
}

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