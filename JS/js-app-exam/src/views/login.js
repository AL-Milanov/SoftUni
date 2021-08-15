import { html } from "../../node_modules/lit-html/lit-html.js";
import { loginUser } from "../../requests/requests.js";

let _router, _render;

const loginPageTemplate = (loginSubmitHandler) => html`
        <!-- Login Page ( Only for Guest users ) -->
        <section id="login-page" class="login">
            <form id="login-form" action="" method="" @submit=${loginSubmitHandler}>
                <fieldset>
                    <legend>Login Form</legend>
                    <p class="field">
                        <label for="email">Email</label>
                        <span class="input">
                            <input type="text" name="email" id="email" placeholder="Email">
                        </span>
                    </p>
                    <p class="field">
                        <label for="password">Password</label>
                        <span class="input">
                            <input type="password" name="password" id="password" placeholder="Password">
                        </span>
                    </p>
                    <input class="button submit" type="submit" value="Login">
                </fieldset>
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

                _router.redirect('/dashboard');
            }

            return data;
        })
        .catch(err => alert(err));
};

export default {
    init,
    getPage,
}