const baseUrl = 'http://localhost:3030';

export const loginUser = (user) => {
    return fetch(`${baseUrl}/users/login`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    })
        .then(response => response.json());
};

export const registerUser = (user) => {
    return fetch(`${baseUrl}/users/register`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    })
        .then(response => response.json());
};

export const logoutUser = () => {
    let user = JSON.parse(localStorage.getItem('user'));

    return fetch(`${baseUrl}/users/logout`, {
        method: 'GET',
        headers: {
            'X-Authorization': user.accessToken
        }
    })
}

export const getAllCollection = () => fetch(`${baseUrl}/data/books?sortBy=_createdOn%20desc`).then(response => response.json());

export const getUserCollection = (userId) => fetch(`${baseUrl}/data/books?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`)
    .then(response => response.json());

export const getOne = (id) => fetch(`${baseUrl}/data/books/${id}`).then(response => response.json());

export const create = (newFile) => {

    let user = JSON.parse(localStorage.getItem('user'));

    return fetch(`${baseUrl}/data/books`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': user.accessToken
        },
        body: JSON.stringify(newFile)
    })
        .then(response => response.json());
}

export const del = (id) => {

    let user = JSON.parse(localStorage.getItem('user'));

    return fetch(`${baseUrl}/data/books/${id}`, {
        method: 'Delete',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': user.accessToken
        }
    })
        .then(response => response.json());
}

export const edit = (id, editedFile) => {

    let user = JSON.parse(localStorage.getItem('user'));

    return fetch(`${baseUrl}/data/books/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': user.accessToken
        },
        body: JSON.stringify(editedFile)
    })
        .then(response => response.json());
}

export const likesForBook = (book) => {

    let user = JSON.parse(localStorage.getItem('user'));

    return fetch(`${baseUrl}/data/likes`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': user.accessToken
        },
        body: JSON.stringify(book)
    })
        .then(response => response.json());
}

export const getLikesOfBook = (bookId) => fetch(`${baseUrl}/data/likes?where=bookId%3D%22${bookId}%22&distinct=_ownerId&count`)
    .then(response => response.json());

export const getUserLikes = (bookId) => {

    let user = JSON.parse(localStorage.getItem('user'));
    let userId = user !== null ? user._id : undefined;

    return fetch(`${baseUrl}/data/likes?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count`)
        .then(response => response.json());
}