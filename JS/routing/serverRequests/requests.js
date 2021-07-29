import { getUserData } from "../authServices/authServices.js";

const baseUrl = 'http://localhost:3030';

export let getFurnitures = () => {
    return fetch(`${baseUrl}/data/catalog`)
        .then(response => response.json())
        .catch(err => alert(err));
}

export let getMyFurnitures = () => {
    let user = getUserData();
    return fetch(`${baseUrl}/data/catalog?where=_ownerId%3D%22${user.userId}%22`)
    .then(response => response.json())
    .catch(err => alert(err));
}

export let getFurniture = (id) => {
    return fetch(`${baseUrl}/data/catalog/${id}`).then(response => response.json()).catch(err => alert(err));
}

export let postFurniture = (furniture) => {
    let user = getUserData();
    furniture._ownerId = user.userId;
    return fetch(`${baseUrl}/data/catalog`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': user.accessToken
        },
        body: JSON.stringify(furniture)
    })
        .then(response => response.json())
        .catch(err => alert(err));
}

export let updateFurniture = (id, furniture) => {

    let user = getUserData();

    return fetch(`${baseUrl}/data/catalog/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': user.accessToken
        },
        body: JSON.stringify(furniture)
    })
        .then(response => response.json())
        .catch(err => alert(err));
}


export let deleteFurniture = (id) => {

    let user = getUserData();

    return fetch(`${baseUrl}/data/catalog/${id}`, {
        method: 'DELETE',
        headers: {
            'X-Authorization': user.accessToken
        }
    })
        .then(response => response.json())
        .catch(err => alert(err));
}

export let userLoginOrRegister = (action, user) => {
    return fetch(`${baseUrl}/users/${action}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    })
        .then(response => response.json())
        .catch(err => alert(err));
}

export let logoutRequest = (token) => {
    return fetch(`${baseUrl}/users/logout`, {
        method: 'GET',
        headers: {
            'X-Authorization': token
        }
    }).catch(err => alert(err));
}