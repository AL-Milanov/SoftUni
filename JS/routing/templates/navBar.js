import { isLoggedIn } from "../authServices/authServices.js";
import { navBarTemplate } from "./navBarTemplate.js";


let pageRouter, pageRenderer;

function initialize(router, render) {
    pageRouter = router;
    pageRenderer = render;
}

function loadPage(context, next) {

    let isLogged = isLoggedIn();
    
    let temp = navBarTemplate(isLogged);

    pageRenderer(temp);

    next();
}

export default {
    initialize,
    loadPage
}