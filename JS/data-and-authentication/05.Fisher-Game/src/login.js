const baseUrl = 'http://localhost:3030/users';

let registerForm = document.getElementById('register-form');
let loginForm = document.getElementById('login-form');

loginForm.addEventListener('submit', (e) => {
    e.preventDefault();
    let loginData = new FormData(e.currentTarget);

    let user = {
        email: loginData.get('email'),
        password: loginData.get('password')
    }

    fetch(`${baseUrl}/login`, {
        method: 'POST',
        headers:{
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    })
        .then(response => response.json())
        .then(data => {
            if (data.code !== 200) {
                throw new Error('error');
            }
            setUser(data.accessToken, data._id);
        })
        .catch(error => {
            loginForm.reset();
            alert('Login or password don\'t match');
        });
});


function setUser(token, userId){
    localStorage.setItem('token', token);
    localStorage.setItem('userId', userId);
    location.assign('./index.html');
}