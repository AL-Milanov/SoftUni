import { html } from "../../node_modules/lit-html/lit-html.js";

let _router, _render;

const userTemplate = (email) => html`
<!-- Logged users -->
    <div class="user">
        <a href="/create">Create Meme</a>
        <div class="profile">
            <span>Welcome, ${email}</span>
            <a href="/my-profile">My Profile</a>
            <a href="/logout">Logout</a>
        </div>
    </div>`;

const guestTemplate = () => html`
    <!-- Guest users -->
    <div class="guest">
        <div class="profile">
            <a href="/login">Login</a>
            <a href="/register">Register</a>
        </div>
        <a class="active" href="/home">Home Page</a>
    </div>
    </nav>`;

const navigationTemplate = (email) => html`
    <!-- Notifications -->
    <section id="notifications">
        <div id="errorBox" class="notification">
            <span>MESSAGE</span>
        </div>
    </section>
    <!-- Navigation -->
    <nav>
        ${email !== undefined 
        ? userTemplate(email)
        : guestTemplate()}
        <a href="/all-memes">All Memes</a>
`;


function init(router, render) {
    _router = router;
    _render = render;
}

function getPage(context, next) {
    let user = JSON.parse(localStorage.getItem('user'));

    let email = user !== null ? user.email : undefined;

    _render(navigationTemplate(email));

    next();
}


export default {
    init,
    getPage,
}