import { logout } from "../../authServices/authServices.js";

let pageRouter, pageRenderer;

function initialize(router, render) {
    pageRouter = router;
    pageRenderer = render;
}

function loadPage(context, next) {

    logout();

    pageRouter.redirect('/login');
}

export default {
    initialize,
    loadPage
}