import { html } from "../../node_modules/lit-html/lit-html.js";
import { getAllMemes } from "../../requests/requests.js";

let _router, _render;

const loadMeme = (meme) => html`
    <div class="meme">
        <div class="card">
            <div class="info">
                <p class="meme-title">${meme.title}</p>
                <img class="meme-image" alt="meme-img" src="${meme.imageUrl}">
            </div>
            <div id="data-buttons">
                <a class="button" href="/all-memes/${meme._id}">Details</a>
            </div>
        </div>
    </div>
`;

const allMemes = (memes) => html`
    <!-- All Memes Page ( for Guests and Users )-->
    <section id="meme-feed">
        <h1>All Memes</h1>
        <div id="memes">
            <!-- Display : All memes in database ( If any ) -->
            ${memes.length > 0
            ? memes.map(loadMeme)
            : html`<p class="no-memes">No memes in database.</p>`}
            <!-- Display : If there are no memes in database -->
        </div>
    </section>
`;


function init(router, render) {
    _router = router;
    _render = render;
}

function getPage() {
    getAllMemes().then(memes => {
        _render(allMemes(memes));
        
        return memes;
    })
        .catch(err => alert(err));
}

export default {
    init,
    getPage,
}