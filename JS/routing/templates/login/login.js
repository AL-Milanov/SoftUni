import { login } from "../../authServices/authServices.js";
import { isEmptyOrSpaces } from "../../helpers/isNullOrSpace.js";
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

    login(user);
    e.target.reset();

    pageRouter.redirect('/dashboard');
}


export default {
    initialize,
    loadPage
}
