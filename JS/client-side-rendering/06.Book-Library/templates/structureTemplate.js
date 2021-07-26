import { html } from "../../node_modules/lit-html/lit-html.js";
import { deleteTitle } from "../buttons/deleteTitleHandler.js";
import { editTitle } from "../buttons/editTitleHandler.js";
import { loadTitles } from "../buttons/loadTitlesHandler.js";

let loadBook = ({ id, title, author }) => html`
    <tr id="${id}">
        <td id="title">${title}</td>
        <td id="author">${author}</td>
        <td>
            <button @click="${editTitle}">Edit</button>
            <button @click="${deleteTitle}">Delete</button>
        </td>
    </tr>
`;

export let loadAllBooks = (data) => html`
        <tbody>${data.map(b => loadBook(b))}</tbody>
`;

export let loadBase = () => html`
    <body>
        <button id="loadBooks" @click=${loadTitles}>LOAD ALL BOOKS</button>
        <table id="container">
            <thead>
                <tr>
                    <th>Title</th>
                    <th>Author</th>
                    <th>Action</th>
                </tr>
            </thead>
        </table>
        <div id="forms"></div>
    </body>
`;

export let loadForms = (loadFrom) => html`
    ${loadFrom()}
`;
