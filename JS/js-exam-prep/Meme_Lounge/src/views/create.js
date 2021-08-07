import { html } from "../../node_modules/lit-html/lit-html.js";
import { createMeme } from "../../requests/requests.js";

let _router, _render;

const createTemplate = (createSubmitHandler) => html`
    <!-- Create Meme Page ( Only for logged users ) -->
    <section id="create-meme">
        <form id="create-form" @submit=${createSubmitHandler}>
            <div class="container">
                <h1>Create Meme</h1>
                <label for="title">Title</label>
                <input id="title" type="text" placeholder="Enter Title" name="title">
                <label for="description">Description</label>
                <textarea id="description" placeholder="Enter Description" name="description"></textarea>
                <label for="imageUrl">Meme Image</label>
                <input id="imageUrl" type="text" placeholder="Enter meme ImageUrl" name="imageUrl">
                <input type="submit" class="registerbtn button" value="Create Meme">
            </div>
        </form>
    </section>
`;

function init(router, render) {
    _router = router;
    _render = render;
}

function getPage() {
    _render(createTemplate(createSubmitHandler));
}

const createSubmitHandler = (e) => {
    e.preventDefault();
    
    let formData = new FormData(e.currentTarget);

    let title = formData.get('title');
    let description = formData.get('description');
    let imageUrl = formData.get('imageUrl');

    if (!(title.trim() && description.trim() && imageUrl.trim())) {
        alert('All fields must be filled');
        return;
    }

    let newMeme = {
        title,
        description,
        imageUrl
    };

    createMeme(newMeme).then(() => _router.redirect('/all-memes')).catch(err => alert(err));
}

export default {
    init,
    getPage,
}