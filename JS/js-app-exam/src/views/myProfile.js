import { html } from "../../node_modules/lit-html/lit-html.js";
import { getUserCollection } from "../../requests/requests.js";

let _router, _render;

const loadUserBooks = (book) => html`
    <li class="otherBooks">
        <h3>${book.title}</h3>
        <p>Type: ${book.type}</p>
        <p class="img"><img src=${book.imageUrl}></p>
        <a class="button" href="/dashboard/${book._id}">Details</a>
    </li>
`;

const myProfilePageTemplate = (books) => html`
        <!-- My Books Page ( Only for logged-in users ) -->
        <section id="my-books-page" class="my-books">
            <h1>My Books</h1>
            <!-- Display ul: with list-items for every user's books (if any) -->
            ${books.length > 0
            ? html`<ul class="my-books-list">${books.map(loadUserBooks)}</ul>`
            : html`<p class="no-books">No books in database!</p>`}
        </section>
`;

function init(router, render) {
    _router = router;
    _render = render;
}

function getPage() {

    let user = JSON.parse(localStorage.getItem('user'));

    getUserCollection(user._id).then(data => _render(myProfilePageTemplate(data))).catch(err => alert(err));

}

export default {
    init,
    getPage,
}