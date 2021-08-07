import { html } from "../../node_modules/lit-html/lit-html.js";
import { loginUser } from "../../requests/requests.js";

let _router, _render;

const loginPageTemplate = (loginSubmitHandler) => html`
    <!-- Login Page ( Only for guest users ) -->
    <section id="login">
        <form id="login-form" @submit=${loginSubmitHandler}>
            <div class="container">
                <h1>Login</h1>
                <label for="email">Email</label>
                <input id="email" placeholder="Enter Email" name="email" type="text">
                <label for="password">Password</label>
                <input id="password" type="password" placeholder="Enter Password" name="password">
                <input type="submit" class="registerbtn button" value="Login">
                <div class="container signin">
                    <p>Dont have an account?<a href="/register">Sign up</a>.</p>
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
    _render(loginPageTemplate(loginSubmitHandler));
}

const loginSubmitHandler = (e) => {
    e.preventDefault();

    let formData = new FormData(e.currentTarget);

    let email = formData.get('email');
    let password = formData.get('password');

    if (!(email.trim() && password.trim())) {
        alert('All fields must be filled');
        return;
    }

    let user = {
        email,
        password
    }

    loginUser(user)
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