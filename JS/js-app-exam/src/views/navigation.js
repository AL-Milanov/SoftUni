import { html } from "../../node_modules/lit-html/lit-html.js";

let _router, _render;

const userTemplate = (email) => html`
        <div id="user">
            <span>Welcome, ${email}</span>
            <a class="button" href="/my-profile">My Books</a>
            <a class="button" href="/create">Add Book</a>
            <a class="button" href="/logout">Logout</a>
        </div>
`;

const guestTemplate = () => html`
<!-- Guest users -->
        <div id="guest">
            <a class="button" href="/login">Login</a>
            <a class="button" href="/register">Register</a>
        </div>
`;

const navigationTemplate = (email) => html`
<!-- Navigation -->
    <nav class="navbar">
    <section class="navbar-dashboard">
        <a href="/dashboard">Dashboard</a>
        <!-- Guest users -->
        ${email !== undefined 
        ? userTemplate(email)
        : guestTemplate()}
        <!-- Logged-in users -->
    </section>
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