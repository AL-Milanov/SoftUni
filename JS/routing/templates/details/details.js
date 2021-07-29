import { getUserData } from "../../authServices/authServices.js";
import { deleteFurniture, getFurniture } from "../../serverRequests/requests.js";
import { detailsTemplate } from "./detailsTemplate.js";

let pageRouter, pageRenderer;
let currentId;


function initialize(router, render) {
    pageRouter = router;
    pageRenderer = render;
}

function loadPage(context, next) {

    currentId = context.params.id;
    let user = getUserData();

    getFurniture(currentId).then(data => {
        let isOwner = user.userId == data._ownerId;

        let temp = detailsTemplate(data, isOwner, deleteHandler);
        pageRenderer(temp);
    })
}

function deleteHandler(){
    deleteFurniture(currentId);

    pageRouter.redirect('/dashboard');
}

export default {
    initialize,
    loadPage
}