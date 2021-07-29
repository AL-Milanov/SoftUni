import { registerPageTemplate } from "./registerPageTemplate.js";
import { isEmptyOrSpaces } from "../../helpers/isNullOrSpace.js";
import { register } from "../../authServices/authServices.js";
import { userLoginOrRegister } from "../../serverRequests/requests.js";

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

    userLoginOrRegister('register', user).then(data => {
        if (data.code == 409) {
            throw new Error('User exists')
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