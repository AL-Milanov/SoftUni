import { render } from "../node_modules/lit-html/lit-html.js";

export const myRenderer = (domElement) => {
    return function (template) {
        render(template, domElement);
    }
}