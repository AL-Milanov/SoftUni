import { html } from "../../node_modules/lit-html/lit-html.js";
import { getUserMemes } from "../../requests/requests.js";

let _router, _render;

const loadUserMemes = (meme) => html`
    <div class="user-meme">
        <p class="user-meme-title">${meme.title}</p>
        <img class="userProfileImage" alt="meme-img" src=${meme.imageUrl}>
        <a class="button" href="/all-memes/${meme._id}">Details</a>
    </div>
`;


const myProfilePageTemplate = (user, memes) => html`
    <!-- Profile Page ( Only for logged users ) -->
    <section id="user-profile-page" class="user-profile">
        <article class="user-info">
            <img id="user-avatar-url" alt="user-profile" src="/images/${user.gender}.png">
            <div class="user-content">
                <p>Username: ${user.username}</p>
                <p>Email: ${user.email}</p>
                <p>My memes count: ${memes.length}</p>
            </div>
        </article>
        <h1 id="user-listings-title">User Memes</h1>
        <div class="user-meme-listings">
            <!-- Display : All created memes by this user (If any) --> 
        ${memes.length > 0 
        ? memes.map(loadUserMemes)
        : html`<p class="no-memes">No memes in database.</p>`}
            <!-- Display : If user doesn't have own memes  --> 
        </div>
    </section>
`;

function init(router, render) {
    _router = router;
    _render = render;
}

function getPage() {

    let user = JSON.parse(localStorage.getItem('user'));

    getUserMemes(user._id).then(memes => _render(myProfilePageTemplate(user, memes))).catch(err => alert(err));

}

export default {
    init,
    getPage,
}