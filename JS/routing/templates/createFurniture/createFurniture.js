import { createFurintureTemplate } from "./createFurnitureTemplate.js";
import { isEmptyOrSpaces } from "../../helpers/isNullOrSpace.js"
import { postFurniture } from "../../serverRequests/requests.js";

let pageRouter, pageRenderer;

function initialize(router, render) {
    pageRouter = router;
    pageRenderer = render;
}

function loadPage(context, next) {

    let invalid = {
        make: true,
        model: true,
        year: true,
        description: true,
        price: true,
        img: true
    };

    let temp = createFurintureTemplate(submitHandler, invalid);

    pageRenderer(temp);

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

    if (Object.keys(invalid).length > 0) {
        let temp = createFurintureTemplate(submitHandler, invalid);
        return pageRenderer(temp);
    }

    let newFurniture = {
        make,
        model,
        year,
        description,
        price,
        img,
        material
    }

    postFurniture(newFurniture).then(data => {
        return data;
    });

    pageRouter.redirect('/dashboard');
}

export default {
    initialize,
    loadPage
}