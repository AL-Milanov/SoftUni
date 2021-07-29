import { login } from "../../authServices/authServices.js";
import { isEmptyOrSpaces } from "../../helpers/isNullOrSpace.js";
import { userLoginOrRegister } from "../../serverRequests/requests.js";
import { loginPageTemplate } from "./loginPageTemplate.js";

let pageRouter, pageRenderer;

function initialize(router, render) {
    pageRouter = router;
    pageRenderer = render;

}

function loadPage(context, next) {

    let temp = loginPageTemplate(submitHandler);

    pageRenderer(temp);
}

function submitHandler(e) {
    e.preventDefault();

    let data = new FormData(e.target);

    let email = data.get('email');
    let password = data.get('password');

    if (isEmptyOrSpaces(email) || isEmptyOrSpaces(password)) {
        return;
    }

    let user = {
        email,
        password
    }

    userLoginOrRegister('login', user).then(data => {
        if (data.accessToken === undefined) {
            throw new Error('Wrong username or password!');
        }
        localStorage.setItem('accessToken', data.accessToken);
        localStorage.setItem('userId', data._id);
        localStorage.setItem('username', data.email);

        pageRouter.redirect('/dashboard');
    })
        .catch(err => alert(err));

    e.target.reset();

}


export default {
    initialize,
    loadPage
}
