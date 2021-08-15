import { html } from "../../node_modules/lit-html/lit-html.js";
import { getAllCollection } from "../../requests/requests.js";

let _router, _render;

const loadItem = (book) => html`
    <li class="otherBooks">
        <h3>${book.title}</h3>
        <p>Type: ${book.type}</p>
        <p class="img"><img src=${book.imageUrl}></p>
        <a class="button" href="/dashboard/${book._id}">Details</a>
    </li>
`;

const loadAllItems = (books) => html`
<!-- Dashboard Page ( for Guests and Users ) -->
<section id="dashboard-page" class="dashboard">
    <h1>Dashboard</h1>
    <!-- Display ul: with list-items for All books (If any) -->
    
    ${books.length > 0
        ? html`<ul class="other-books-list">
        ${books.map(loadItem)}</ul>`
        : html`<p class="no-books">No books in database!</p>`}
    <!-- Display paragraph: If there are no books in the database -->
</section>

`;


function init(router, render) {
    _router = router;
    _render = render;
}

function getPage() {
    getAllCollection().then(data => {
        _render(loadAllItems(data));

        return data;
    })
        .catch(err => alert(err));
}

export default {
    init,
    getPage,
}