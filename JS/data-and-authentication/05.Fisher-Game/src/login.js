const baseUrl = 'http://localhost:3030/users';

let registerForm = document.getElementById('register-form');
let loginForm = document.getElementById('login-form');


registerForm.addEventListener('submit', (e) => {
    e.preventDefault();

    let loginData = new FormData(e.currentTarget);

    let email = loginData.get('email');
    let password = loginData.get('password');
    let rePass = loginData.get('rePass');

    if (password !== rePass) {
        alert('Passwords don\'t match');
        registerForm.reset();
        return;
    }

    let newUser = {
        email,
        password,
    }

    fetch(`${baseUrl}/register`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newUser)
    })
        .then(response => response.json())
        .then(data => { console.log(data); setUser(data.accessToken, data._id); registerForm.reset(); })
        .catch(error => console.log('SOMETHING BAD HAPPEND'));
})

loginForm.addEventListener('submit', (e) => {
    e.preventDefault();
    let loginData = new FormData(e.currentTarget);

    let user = {
        email: loginData.get('email'),
        password: loginData.get('password')
    }

    fetch(`${baseUrl}/login`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    })
        .then(response => response.json())
        .then(data => {
            if (data.accessToken === undefined) {
                throw new Error('No!!!');
            }
            setUser(data.accessToken, data._id);
            loginForm.reset();
        })
        .catch(error => {
            loginForm.reset();
            alert('E-mail or password don\'t match');
        });
});


function setUser(token, userId) {
    localStorage.setItem('token', token);
    localStorage.setItem('userId', userId);
    location.assign('./index.html');
}