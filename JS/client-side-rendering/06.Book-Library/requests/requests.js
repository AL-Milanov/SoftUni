const baseUrl = 'http://localhost:3030/jsonstore/collections/books';

export let getRequest = () => {
    return fetch(`${baseUrl}`)
        .then(response => response.json())
        .catch(err => alert(err));
}

export let deleteRequest = (id) => {
    return fetch(`${baseUrl}/${id}`, {
        method: 'DELETE'
    })
        .then(response => response.json())
        .catch(err => alert(err));
}

export let postRequest = (newBook) => {
    return fetch(`${baseUrl}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newBook)
    })
        .then(response => response.json())
        .catch(err => alert(err));
}

export let putRequest = (newBook, id) => {
    return fetch(`${baseUrl}/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newBook)
    })
        .then(response => response.json())
        .catch(err => alert(err));
}