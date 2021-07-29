import { getFurnitures } from "../../serverRequests/requests.js";
import { dashboardTemplate } from "./dashboardTemplate.js";

let pageRouter, pageRenderer;

function initialize(router, render) {
    pageRouter = router;
    pageRenderer = render;
}

function loadPage(context, next) {
    
    getFurnitures().then(data => {
        let temp = dashboardTemplate(data);
        pageRenderer(temp);
        return data;
    });
}

export default {
    initialize,
    loadPage
}