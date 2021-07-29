import { registerPageTemplate } from "./registerPageTemplate.js";
import { isEmptyOrSpaces } from "../../helpers/isNullOrSpace.js";
import { register } from "../../authServices/authServices.js";

let pageRouter, pageRenderer;

function initialize(router, render) {
    pageRouter = router;
    pageRenderer = render;
}

function loadPage(context, next) {

    let temp = registerPageTemplate(submitHandler);

    pageRenderer(temp);
}


function submitHandler(e) {
    e.preventDefault();

    let data = new FormData(e.target);

    let email = data.get('email');
    let password = data.get('password');
    let rePassword = data.get('rePass');

    if (isEmptyOrSpaces(email) || isEmptyOrSpaces(password)) {
        return;
    }

    if (password !== rePassword) {
        alert('Passwords must match!');
        return;
    }

    let user = {
        email,
        password
    }

    register(user);

    e.target.reset();

    pageRouter.redirect('/dashboard');
}


export default {
    initialize,
    loadPage
}