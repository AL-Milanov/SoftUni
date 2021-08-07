import { html, nothing } from "../../node_modules/lit-html/lit-html.js";
import { deleteMeme, getMeme } from "../../requests/requests.js";

let _router, _render;
let memeId = undefined;


const detailsPageTemplate = (meme, userId, deleteMemeHandler) => html`
    <!-- Details Meme Page (for guests and logged users) -->
    <section id="meme-details">
        <h1>Meme Title: ${meme.title}
        </h1>
        <div class="meme-details">
            <div class="meme-img">
                <img alt="meme-alt" src="${meme.imageUrl}">
            </div>
            <div class="meme-description">
                <h2>Meme Description</h2>
                <p>${meme.description}</p>
                <!-- Buttons Edit/Delete should be displayed only for creator of this meme  -->
                ${meme._ownerId === userId
                ? html`
                <a class="button warning" href="/edit/${meme._id}">Edit</a>
                <button class="button danger" @click=${deleteMemeHandler}>Delete</button>`
                : nothing}
            </div>
        </div>
    </section>
`;


function init(router, render) {
    _router = router;
    _render = render;
}

function getPage(context, next) {
    memeId = context.params.id;
    let user = JSON.parse(localStorage.getItem('user'));

    let userId = user !== null ? user._id : undefined;

    getMeme(memeId).then(meme => _render(detailsPageTemplate(meme, userId, deleteMemeHandler))).catch(err => alert(err));
}

const deleteMemeHandler = () => {
    if (confirm('Are you sure you want to delete it ?')) {
        deleteMeme(memeId);
        _router.redirect('/all-memes');
    }
}

export default {
    init,
    getPage,
}