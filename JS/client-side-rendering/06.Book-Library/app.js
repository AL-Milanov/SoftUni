import { render } from "../node_modules/lit-html/lit-html.js";
import { loadTitles } from "./buttons/loadTitlesHandler.js";
import { postRequest } from "./requests/requests.js";
import { loadAddForm } from "./templates/loadAddFormTemplate.js";
import { loadBase, loadForms } from "./templates/structureTemplate.js";

render(loadBase(), document.body);
render(loadForms(loadAddForm), document.getElementById('forms'));

let addForm = document.getElementById('add-form');

addForm.addEventListener('submit', addFormHandler);

function addFormHandler(e){
    e.preventDefault();

    let formData = new FormData(addForm);

    let title = formData.get('title');
    let author = formData.get('author');

    let newBook = {
        title,
        author
    };
    postRequest(newBook);

    addForm.reset();
    loadTitles();
};