import { html } from "../../node_modules/lit-html/lit-html.js";
import { create } from "../../requests/requests.js";

let _router, _render;

const createTemplate = (createSubmitHandler) => html`
        <!-- Create Page ( Only for logged-in users ) -->
        <section id="create-page" class="create">
            <form id="create-form" action="" method="" @submit=${createSubmitHandler}>
                <fieldset>
                    <legend>Add new Book</legend>
                    <p class="field">
                        <label for="title">Title</label>
                        <span class="input">
                            <input type="text" name="title" id="title" placeholder="Title">
                        </span>
                    </p>
                    <p class="field">
                        <label for="description">Description</label>
                        <span class="input">
                            <textarea name="description" id="description" placeholder="Description"></textarea>
                        </span>
                    </p>
                    <p class="field">
                        <label for="image">Image</label>
                        <span class="input">
                            <input type="text" name="imageUrl" id="image" placeholder="Image">
                        </span>
                    </p>
                    <p class="field">
                        <label for="type">Type</label>
                        <span class="input">
                            <select id="type" name="type">
                                <option value="Fiction">Fiction</option>
                                <option value="Romance">Romance</option>
                                <option value="Mistery">Mistery</option>
                                <option value="Classic">Clasic</option>
                                <option value="Other">Other</option>
                            </select>
                        </span>
                    </p>
                    <input class="button submit" type="submit" value="Add Book">
                </fieldset>
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
    let type = formData.get('type');


    if (!(title.trim() && description.trim() && imageUrl.trim())) {
        alert('All fields must be filled');
        return;
    }

    let newBook = {
        title,
        description,
        imageUrl,
        type
    };

    create(newBook).then(() => _router.redirect('/dashboard')).catch(err => alert(err));
}

export default {
    init,
    getPage,
}