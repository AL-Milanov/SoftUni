import { getMyFurnitures } from "../../serverRequests/requests.js";
import { myFurnituresTemplate } from "./myFurnituresTemplate.js";

let pageRouter, pageRenderer;

function initialize(router, render) {
    pageRouter = router;
    pageRenderer = render;
}

function loadPage(context, next) {

    getMyFurnitures().then(data => {
        
        let temp = myFurnituresTemplate(data);
        pageRenderer(temp);
    });
}

export default {
    initialize,
    loadPage
}