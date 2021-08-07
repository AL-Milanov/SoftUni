import { html } from "../../node_modules/lit-html/lit-html.js";
import { registerUser } from "../../requests/requests.js";

let _router, _render;

const registerPageTemplate = (registerSubmitHandler) => html`
<!-- Register Page ( Only for guest users ) -->
    <section id="register">
        <form id="register-form" @submit=${registerSubmitHandler}>
            <div class="container">
                <h1>Register</h1>
                <label for="username">Username</label>
                <input id="username" type="text" placeholder="Enter Username" name="username">
                <label for="email">Email</label>
                <input id="email" type="text" placeholder="Enter Email" name="email">
                <label for="password">Password</label>
                <input id="password" type="password" placeholder="Enter Password" name="password">
                <label for="repeatPass">Repeat Password</label>
                <input id="repeatPass" type="password" placeholder="Repeat Password" name="repeatPass">
                <div class="gender">
                    <input type="radio" name="gender" id="female" value="female">
                    <label for="female">Female</label>
                    <input type="radio" name="gender" id="male" value="male" checked>
                    <label for="male">Male</label>
                </div>
                <input type="submit" class="registerbtn button" value="Register">
                <div class="container signin">
                    <p>Already have an account?<a href="/login">Sign in</a>.</p>
                </div>
            </div>
        </form>
    </section>
`;

function init(router, render) {
    _router = router;
    _render = render;
}

function getPage() {
    _render(registerPageTemplate(registerSubmitHandler));
}

const registerSubmitHandler = (e) => {
    e.preventDefault();

    let formData = new FormData(e.currentTarget);

    let username = formData.get('username');
    let email = formData.get('email');
    let password = formData.get('password');
    let repeatPass = formData.get('repeatPass');
    let gender = formData.get('gender');

    if (!(email.trim() && password.trim() && repeatPass.trim() && username.trim())) {
        alert('All fields must be filled');
        return;
    }
    if (password !== repeatPass) {
        alert('Passwords doesnt match');
        return;
    }

    let user = {
        username,
        email,
        password,
        gender
    }

    registerUser(user)
        .then(data => {

            if (data.accessToken === undefined) {
                throw data.message;
            } else {
                
                localStorage.setItem('user', JSON.stringify(data));

                _router.redirect('/all-memes');
            }

            return data;
        })
        .catch(err => alert(err));
};

export default {
    init,
    getPage,
}