import { render } from "../../node_modules/lit-html/lit-html.js";
import { putRequest } from "../requests/requests.js";
import { loadAddForm } from "../templates/loadAddFormTemplate.js";
import { loadEditForm } from "../templates/loadEditFormTemplate.js";
import { loadForms } from "../templates/structureTemplate.js";
import { loadTitles } from "./loadTitlesHandler.js";


export let editTitle = (e) => {
    render(loadForms(loadEditForm), document.getElementById('forms'));
    let editForm = document.getElementById('edit-form');

    let tr = e.target.closest('tr');

    let title = tr.querySelector('#title').textContent;
    let author = tr.querySelector('#author').textContent;
    
    editForm.querySelector('input[name="author"]').value = author;
    editForm.querySelector('input[name="title"]').value = title;
    
    editForm.addEventListener('submit', (e) => {
        e.preventDefault();
        
        let titleId = tr.id;
        let formData = new FormData(editForm);

        let newTitle = formData.get('title');
        let newAuthor = formData.get('author');

        let newBook = {
            'author': newAuthor,
            'title': newTitle
        };

        putRequest(newBook, titleId);

        loadTitles();
        render(loadForms(loadAddForm), document.getElementById('forms'));

    });
}