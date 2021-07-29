import { logoutRequest, userLoginOrRegister } from "../serverRequests/requests.js";

export let isLoggedIn = () => {
    return localStorage.getItem('accessToken') !== null;
}

export let login = (user) => {
    userLoginOrRegister('login', user).then(data => {
        if (data.accessToken === undefined) {
            throw new Error('Wrong username or password!');
        }
        localStorage.setItem('accessToken', data.accessToken);
        localStorage.setItem('userId', data._id);
        localStorage.setItem('username', data.email);
    })
    .catch(err => alert(err));
}

export let register = (user) => {
    userLoginOrRegister('register', user).then(data => {
        localStorage.setItem('accessToken', data.accessToken);
        localStorage.setItem('userId', data._id);
        localStorage.setItem('username', data.email);
    })
    .catch(err => alert(err));
}

export let logout = () => {
    let user = getUserData();

    logoutRequest(user.accessToken).then(u => { return u });
    localStorage.clear();
}

export let getUserData = () => {

    let accessToken = localStorage.getItem('accessToken');
    let userId = localStorage.getItem('userId');

    let user = {
        accessToken,
        userId
    }

    return user;
}