import { render } from "../../node_modules/lit-html/lit-html.js";
import { getRequest } from "../requests/requests.js";
import { loadAllBooks } from "../templates/structureTemplate.js";

export let loadTitles = () => {

    let containerElement = document.getElementById('container');

    getRequest().then(data => {
        let allBooks = Object.entries(data).map(([key, value]) => {
            let obj = {
                id: key,
                title: value.title,
                author: value.author
            }
            return obj;
        });
        render(loadAllBooks(allBooks), containerElement);
    });
}
