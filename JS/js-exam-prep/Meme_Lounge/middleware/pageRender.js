import { render } from "../node_modules/lit-html/lit-html.js";

export const pageRender = (domElement) => {
    return function (template) {
        render(template, domElement);
    }
}