import { html } from "../../node_modules/lit-html/lit-html.js";
import { registerUser } from "../../requests/requests.js";

let _router, _render;

const registerPageTemplate = (registerSubmitHandler) => html`
        <!-- Register Page ( Only for Guest users ) -->
        <section id="register-page" class="register">
            <form id="register-form" action="" method="" @submit=${registerSubmitHandler}>
                <fieldset>
                    <legend>Register Form</legend>
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
                    <p class="field">
                        <label for="repeat-pass">Repeat Password</label>
                        <span class="input">
                            <input type="password" name="confirm-pass" id="repeat-pass" placeholder="Repeat Password">
                        </span>
                    </p>
                    <input class="button submit" type="submit" value="Register">
                </fieldset>
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

    let email = formData.get('email');
    let password = formData.get('password');
    let repeatPass = formData.get('confirm-pass');

    if (!(email.trim() && password.trim() && repeatPass.trim())) {
        alert('All fields must be filled');
        return;
    }
    if (password !== repeatPass) {
        alert('Passwords doesnt match');
        return;
    }

    let user = {
        email,
        password,
    }

    registerUser(user)
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