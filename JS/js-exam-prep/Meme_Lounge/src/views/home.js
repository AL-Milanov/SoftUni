import { html } from "../../node_modules/lit-html/lit-html.js";

let _router, _render;

const homePageTemplate = () => html`
    <!-- Welcome Page ( Only for guest users ) -->
    <section id="welcome">
        <div id="welcome-container">
            <h1>Welcome To Meme Lounge</h1>
            <img src="/images/welcome-meme.jpg" alt="meme">
            <h2>Login to see our memes right away!</h2>
            <div id="button-div">
                <a href="/login" class="button">Login</a>
                <a href="/register" class="button">Register</a>
            </div>
        </div>
    </section>
`;

function init(router, render) {
    _router = router;
    _render = render;
}

function getPage() {
    _render(homePageTemplate());
}

export default {
    init,
    getPage,
}