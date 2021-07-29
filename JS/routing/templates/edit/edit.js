import { getFurniture, updateFurniture } from "../../serverRequests/requests.js";
import { editTemplate } from "./editTemplate.js";
import { isEmptyOrSpaces } from "../../helpers/isNullOrSpace.js";

let pageRouter, pageRenderer;

let currentId = undefined;

function initialize(router, render) {
    pageRouter = router;
    pageRenderer = render;
}

function loadPage(context, next) {

    let id = context.params.id;
    let invalid = {
        make: false,
        model: false,
        year: false,
        description: false,
        price: false,
        img: false,
        material: false
    }

    getFurniture(id).then(data => {
        currentId = data._id;
        let temp = editTemplate(data, submitHandler, invalid);
        pageRenderer(temp);
    })
}

function submitHandler(e) {
    e.preventDefault();

    let formData = new FormData(e.target);

    let invalid = {};

    let make = formData.get('make');

    if (make.length < 4) {
        invalid.make = true;
    }

    let model = formData.get('model');

    if (model.length < 4) {
        invalid.model = true;
    }

    let year = Number(formData.get('year'));

    if (year < 1950 || year > 2050) {
        invalid.year = true;
    }

    let description = formData.get('description');

    if (description.length < 10) {
        invalid.description = true;
    }

    let price = Number(formData.get('price'));

    if (price <= 0) {
        invalid.price = true;
    }

    let img = formData.get('img');

    if (isEmptyOrSpaces(img)) {
        invalid.img = true;
    }

    let material = formData.get('material');
    
    let current = {
        make,
        model,
        year,
        description,
        price,
        img,
        material
    }

    if (Object.keys(invalid).length > 0) {
        let temp = editTemplate(current ,submitHandler, invalid);
        return pageRenderer(temp);
    }


    let updatedFurniture = {
        make,
        model,
        year,
        description,
        price,
        img,
        material
    };

    updateFurniture(currentId, updatedFurniture);
    e.target.reset();
    
    pageRouter.redirect('/dashboard');
}

export default {
    initialize,
    loadPage
}