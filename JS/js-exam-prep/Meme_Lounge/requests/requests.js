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

export const getAllMemes = () => fetch(`${baseUrl}/data/memes?sortBy=_createdOn%20desc`).then(response => response.json());

export const getUserMemes = (userId) => fetch(`${baseUrl}/data/memes?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`)
    .then(response => response.json());

export const getMeme = (id) => fetch(`${baseUrl}/data/memes/${id}`).then(response => response.json());

export const createMeme = (newMeme) => {

    let user = JSON.parse(localStorage.getItem('user'));

    return fetch(`${baseUrl}/data/memes`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': user.accessToken
        },
        body: JSON.stringify(newMeme)
    })
        .then(response => response.json());
}

export const deleteMeme = (id) => {

    let user = JSON.parse(localStorage.getItem('user'));

    return fetch(`${baseUrl}/data/memes/${id}`, {
        method: 'Delete',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': user.accessToken
        }
    })
        .then(response => response.json());
}

export const editMeme = (id, meme) => {

    let user = JSON.parse(localStorage.getItem('user'));

    return fetch(`${baseUrl}/data/memes/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': user.accessToken
        },
        body: JSON.stringify(meme)
    })
        .then(response => response.json());
}